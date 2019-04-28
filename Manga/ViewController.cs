using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using UIKit;
namespace Manga {
    public partial class ViewController : UIViewController {
        public List<Manga> MangaList;
        public ViewController (IntPtr handle) : base (handle) { }
        public override void DidReceiveMemoryWarning()
        { base.DidReceiveMemoryWarning(); }
        public override void ViewDidLoad () {
            base.ViewDidLoad ();
            SettxtCerca();
            Foundation.NSNotificationCenter.DefaultCenter.AddObserver(new NSString("UIDeviceOrientationDidChangeNotification"), DeviceRotated);
            CheckDB();
            CheckImg();
            SetButton();
        }
        public void SettxtCerca() {
            txtCerca.ShouldReturn = (textField) => {
                textField.ResignFirstResponder();
                return true;
            };
            View.AddGestureRecognizer(new UITapGestureRecognizer(() => View.EndEditing(true)));
            NSNotificationCenter.DefaultCenter.AddObserver(UITextField.TextFieldTextDidChangeNotification, TextChangedEvent);
        }
        void DeviceRotated(NSNotification notification)
        {
            SetButton();
        }
        public override void ViewDidAppear(Boolean animated)
        {
            ((AppDelegate)UIApplication.SharedApplication.Delegate).CurrentOrientation = UIInterfaceOrientationMask.All;
        }
        private void TextChangedEvent(NSNotification notification) {
            UITextField sender = (UITextField)notification.Object;
            if (sender.Text.ToLower() == "mangaconclusi" || sender.Text.ToLower() == "manganonconclusi") {
                MangaList = (sender.Text.ToLower() == "mangaconclusi") ? DataBase.GetMangaFinitiList() : DataBase.GetMangaInCorsoList();
                SetButton();
            }
            else if (sender.Text.ToLower() == "mangaposseduti" || sender.Text.ToLower() == "manganonposseduti") {
                MangaList = (sender.Text.ToLower() == "mangaposseduti") ? DataBase.GetMangaPossedereTuttiVolumi() : DataBase.GetMangaNonPossedereTuttiVolumi();
                SetButton();
            }
            else if (sender.Text == "") {
                MangaList = DataBase.GetMangaList();
                SetButton();
            }
            else
            {
                MangaList = DataBase.GetMangaList().Where(o => o.nomeManga.ToLower().StartsWith(sender.Text.ToLower())).ToList();
                SetButton();
            }
        }
        public void CheckDB() {
            scrViewManga.ContentSize = new CoreGraphics.CGSize(scrViewManga.Frame.Width, scrViewManga.Frame.Height + 1000);
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string file = "DataBase/Manga.db";
            string pathDB = Path.Combine(folderPath, file);
            if (!File.Exists(pathDB)) {
                Directory.CreateDirectory(Path.Combine(folderPath, "DataBase"));
                File.Copy(file, pathDB);
            }
            DataBase.Connect(pathDB);
        }
        public void CheckImg() {
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Img");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            MangaList = DataBase.GetMangaList();
            for (int i = 0; i < MangaList.Count; i++)
                if (!File.Exists(Path.Combine(folderPath, $"{MangaList[i].nomeManga}.jpg")))
                    DownloadImg(MangaList[i].imgLink, Path.Combine(folderPath, $"{MangaList[i].nomeManga}.jpg"));
        }
        public void DownloadImg(string url, string pathFile) {
            WebClient wc = new WebClient();
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            wc.DownloadFile(url, pathFile);
        }
        public void SetButton() {
            foreach (UIView view in viewMangaList.Subviews)
                view.RemoveFromSuperview();
            System.Diagnostics.Debug.WriteLine(scrViewManga.Frame.Width);
            int width = 80, height = 100, y = 0, numeroIcone = ((int)(scrViewManga.Frame.Width / width)), widthDist = width + ((int)scrViewManga.Frame.Width - (numeroIcone * width)) / (numeroIcone - 1), heightDist = height + 20;
            for (int i = 0; i < MangaList.Count; y += heightDist)
                for (int x = 0, k = 0; i < MangaList.Count && k < numeroIcone; i++, k++, x += widthDist)
                    viewMangaList.AddSubview(CreateButton(MangaList[i], x, y, width, height));
            scrViewManga.ContentSize = new CGSize(scrViewManga.Frame.Width, y - 20);
            viewMangaList.Frame = new RectangleF(0, 0, (float)scrViewManga.Frame.Width, y);
        }
        public UIButton CreateButton(Manga manga, int x, int y, float width, float height) {
            UIButton myButton = new UIButton(UIButtonType.System);
            myButton.Frame = new CGRect(x, y, width, height);
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Img");
            myButton.SetBackgroundImage(UIImage.FromFile(Path.Combine(folderPath, $"{manga.nomeManga}.jpg")), UIControlState.Normal);
            myButton.TouchUpInside += (object sender, EventArgs e) => {
                ClasseAppoggio.manga = manga;
                ViewControllerMangaInfo controller = Storyboard.InstantiateViewController("ViewControllerMangaInfo") as ViewControllerMangaInfo;
                if (controller != null)
                    NavigationController.PushViewController(controller, true);
            };
            return myButton;
        }
        partial void BtnAggiungi_TouchUpInside(UIButton sender) {
            ViewControllerAggiungiManga controller = Storyboard.InstantiateViewController("ViewControllerAggiungiManga") as ViewControllerAggiungiManga;
            if (controller != null)
                NavigationController.PushViewController(controller, true);
        }
    }
}