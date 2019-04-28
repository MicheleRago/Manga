using System;
using UIKit;
namespace Manga
{
    public partial class ViewControllerModificaManga : UIViewController {
        public ViewControllerModificaManga (IntPtr handle) : base (handle) { }
        public override void ViewDidLoad() {
            base.ViewDidLoad();
            View.AddGestureRecognizer(new UITapGestureRecognizer(() => View.EndEditing(true)));
            txtNomeManga.Text = ClasseAppoggio.manga.nomeManga;
            txtNumeroVolumi.Text = ClasseAppoggio.manga.volumiTotali.ToString();
            txtLinkImg.Text = ClasseAppoggio.manga.imgLink;
            swcCompletato.On = ClasseAppoggio.manga.isCompletato;
            swcTuttiVolumi.On = ClasseAppoggio.manga.isPossedereTuttiVolumi;
        }
        //        public static List<Volume> AddVolume(string nomeManga, string nomeVolume, bool isAcquistato)

        partial void BtnAggiungi_TouchUpInside(UIButton sender)
        {
            try
            {
                DataBase.AddVolume(ClasseAppoggio.manga.nomeManga, txtNomeVolume.Text, swcPosseduto.On);
                UIAlertView alert = new UIAlertView()
                { Title = "Operazione completata", Message = "Manga aggiornato con successo al database" };
                alert.AddButton("OK");
                alert.Show();
            }
            catch (Exception e)
            {
                UIAlertView alert = new UIAlertView()
                { Title = "Operazione non riuscita", Message = e.Message };
                alert.AddButton("OK");
                alert.Show();
            }
        }

        partial void BtnModifica_TouchUpInside(UIButton sender)
        {
            try
            {
                string nomeManga = ClasseAppoggio.manga.nomeManga;
                ClasseAppoggio.manga.nomeManga = txtNomeManga.Text;
                ClasseAppoggio.manga.isCompletato = swcCompletato.On;
                ClasseAppoggio.manga.imgLink = txtLinkImg.Text;
                ClasseAppoggio.manga.isPossedereTuttiVolumi = swcTuttiVolumi.On;
                ClasseAppoggio.manga.volumiTotali = int.Parse(txtNumeroVolumi.Text);
                DataBase.ModificaManga(ClasseAppoggio.manga, nomeManga); UIAlertView alert = new UIAlertView()
                { Title = "Operazione completata", Message = "Manga modificato con successo al database" };
                alert.AddButton("OK");
                alert.Show();
            }
            catch (Exception e)
            {
                UIAlertView alert = new UIAlertView()
                { Title = "Operazione non riuscita", Message = e.Message };
                alert.AddButton("OK");
                alert.Show();
            }
        }
    }
}