using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
namespace Manga
{
    public class Manga
    {
        public int id { get; set; }
        public string nomeManga { get; set; }
        public string imgLink { get; set; }
        public int volumiTotali { get; set; }
        public bool isCompletato { get; set; }
        public bool isPossedereTuttiVolumi { get; set; }
    }
    public class Volume
    {
        public int id { get; set; }
        public string nomeVolume { get; set; }
        public bool isAcquistato { get; set; }
    }
    public static class DataBase
    {
        static SQLiteConnection db;
        public static void Connect(string pathDB)
        { db = new SQLiteConnection(pathDB); }
        public static void Close()
        { db.Dispose(); }
        public static List<Manga> GetMangaList()
        { return db.Query<Manga>("Select * From ListaManga"); }
        public static List<Manga> GetMangaFinitiList()
        { return db.Query<Manga>("Select * From ListaManga Where isCompletato=1"); }
        public static List<Manga> GetMangaInCorsoList()
        { return db.Query<Manga>("Select * From ListaManga Where isCompletato=0"); }
        public static List<Manga> GetMangaPossedereTuttiVolumi()
        { return db.Query<Manga>("Select * From ListaManga Where isPossedereTuttiVolumi=1"); }
        public static List<Manga> GetMangaNonPossedereTuttiVolumi()
        { return db.Query<Manga>("Select * From ListaManga Where isPossedereTuttiVolumi=0"); }
        public static List<Volume> GetListaVolumi(String nomeManga)
        { return db.Query<Volume>($"Select * From '{nomeManga}'"); }
        public static List<Volume> GetVolumiAcquistati(String nomeManga)
        { return db.Query<Volume>($"Select * From '{nomeManga}' Where isAcquistato=1"); }
        public static List<Volume> GetVolumiNonAcquistati(String nomeManga)
        { return db.Query<Volume>($"Select * From '{nomeManga}' Where isAcquistato=0"); }
        public static List<Manga> AddManga(Manga nuovoManga)
        {
            db.CreateCommand($"INSERT INTO `ListaManga` (nomeManga,imgLink,volumiTotali,isCompletato,isPossedereTuttiVolumi) VALUES ('{nuovoManga.nomeManga}','{nuovoManga.imgLink}', {nuovoManga.volumiTotali}, {(nuovoManga.isCompletato ? 1 : 0)}, {(nuovoManga.isPossedereTuttiVolumi ? 1 : 0)})").ExecuteNonQuery();
            db.CreateCommand($"CREATE TABLE \"{nuovoManga.nomeManga}\"( `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `nomeVolume` TEXT NOT NULL,`isAcquistato` INTEGER NOT NULL)").ExecuteNonQuery();
            return SortDB(GetMangaList());
        }
        public static List<Manga> AddManga(string nomeManga, string imgLink, int volumiTotali, bool isCompletato, bool isPossedereTuttiVolumi)
        {
            Manga nuovoManga = new Manga();
            nuovoManga.nomeManga = nomeManga;
            nuovoManga.imgLink = imgLink;
            nuovoManga.volumiTotali = volumiTotali;
            nuovoManga.isCompletato = isCompletato;
            nuovoManga.isPossedereTuttiVolumi = isPossedereTuttiVolumi;
            return AddManga(nuovoManga);
        }
        public static List<Volume> AddVolume(Volume nuovoVolume, string nomeManga)
        {
            db.CreateCommand($"INSERT INTO `{nomeManga}` (nomeVolume,isAcquistato) VALUES ('{nuovoVolume.nomeVolume}',{(nuovoVolume.isAcquistato ? 1 : 0)})").ExecuteNonQuery();
            return SortDB(GetListaVolumi(nomeManga), nomeManga);
        }
        public static List<Volume> AddVolume(string nomeManga, string nomeVolume, bool isAcquistato)
        {
            Volume nuovoVolume = new Volume();
            nuovoVolume.nomeVolume = nomeVolume;
            nuovoVolume.isAcquistato = isAcquistato;
            return AddVolume(nuovoVolume, nomeManga);
        }
        public static List<Manga> RemoveManga(Manga mangaDaRimuovere)
        {
            db.CreateCommand($"DELETE FROM ListaManga WHERE nomeManga = '{mangaDaRimuovere.nomeManga}'").ExecuteNonQuery();
            db.CreateCommand($"DROP TABLE \"{mangaDaRimuovere.nomeManga}\"").ExecuteNonQuery();
            return SortDB(GetMangaList());
        }
        public static List<Manga> RemoveManga(string nomeManga)
        {
            Manga nuovoManga = new Manga();
            nuovoManga.nomeManga = nomeManga;
            return RemoveManga(nuovoManga);
        }
        public static List<Volume> RemoveVolume(string nomeManga, Volume volume)
        {
            db.CreateCommand($"DELETE FROM `{nomeManga}` WHERE nomeVolume = '{volume.nomeVolume}'").ExecuteNonQuery();
            return SortDB(GetListaVolumi(nomeManga), nomeManga);
        }
        public static List<Volume> RemoveVolume(string nomeManga, string nomeVolume)
        {
            Volume nuovoVolume = new Volume();
            nuovoVolume.nomeVolume = nomeVolume;
            return RemoveVolume(nomeManga, nuovoVolume);
        }
        //SortDB Si occupa di fixare gli id e ordinare la tabella per nome
        public static List<Manga> SortDB(List<Manga> listaManga)
        {
            List<Manga> listaMangaOrdinata = listaManga.OrderBy(o => o.nomeManga).ToList();
            db.CreateCommand($"DROP TABLE \"ListaManga\"").ExecuteNonQuery();
            db.CreateCommand($"CREATE TABLE \"ListaManga\" ( `id` INTEGER NOT NULL UNIQUE, `nomeManga` TEXT NOT NULL, `imgLink` TEXT NOT NULL, `volumiTotali` INTEGER NOT NULL, `isCompletato` INTEGER NOT NULL, `isPossedereTuttiVolumi` INTEGER NOT NULL, PRIMARY KEY(`id`) )").ExecuteNonQuery();
            foreach (Manga lm in listaMangaOrdinata)
                db.CreateCommand($"INSERT INTO `ListaManga` (nomeManga,imgLink,volumiTotali,isCompletato,isPossedereTuttiVolumi) VALUES ('{lm.nomeManga}','{lm.imgLink}', {lm.volumiTotali}, {(lm.isCompletato ? 1 : 0)}, {(lm.isPossedereTuttiVolumi ? 1 : 0)})").ExecuteNonQuery();
            return GetMangaList();
        }
        public static List<Volume> SortDB(List<Volume> listaVolumi, string nomeManga)
        {
            List<Volume> listaVolumiOrdinata = listaVolumi.OrderBy(o => o.nomeVolume.Length).ToList();
            db.CreateCommand($"DROP TABLE \"{nomeManga}\"").ExecuteNonQuery();
            db.CreateCommand($"CREATE TABLE \"{nomeManga}\"( `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `nomeVolume` TEXT NOT NULL, `isAcquistato` INTEGER NOT NULL)").ExecuteNonQuery();
            foreach (Volume lv in listaVolumiOrdinata)
                db.CreateCommand($"INSERT INTO `{nomeManga}` (nomeVolume,isAcquistato) VALUES ('{lv.nomeVolume}',{(lv.isAcquistato ? 1 : 0)})").ExecuteNonQuery();
            return GetListaVolumi(nomeManga);
        }
        public static List<Volume> ModificaVolume(Volume volume, bool isAcquistato, string nomeManga){
            db.CreateCommand($"UPDATE \"{nomeManga}\" SET isAcquistato = {((isAcquistato) ? 1 : 0)} WHERE nomeVolume = '{volume.nomeVolume}'").ExecuteNonQuery();
            return GetListaVolumi(nomeManga);

        }
        public static List<Manga> ModificaManga(Manga manga, string nomeManga)
        {
            db.CreateCommand($"UPDATE ListaManga SET imgLink = '{manga.imgLink}' , volumiTotali = {manga.volumiTotali}, isCompletato = {((manga.isCompletato) ? 1 : 0)}, isPossedereTuttiVolumi = {((manga.isPossedereTuttiVolumi) ? 1 : 0)} WHERE nomeManga = '{nomeManga}'").ExecuteNonQuery();
            return GetMangaList();
        }
    }
}