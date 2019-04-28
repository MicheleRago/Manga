using CoreGraphics;
using Foundation;
using System;
using System.Drawing;
using System.IO;
using UIKit;
namespace Manga {
    public partial class ViewControllerMangaInfo : UIViewController {
        public ViewControllerMangaInfo (IntPtr handle) : base (handle) { }
        public override void ViewDidLoad() {
            base.ViewDidLoad();
            ((AppDelegate)UIApplication.SharedApplication.Delegate).CurrentOrientation = UIInterfaceOrientationMask.Portrait;
            this.NavigationItem.Title = ClasseAppoggio.manga.nomeManga;
            string imgPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Img", $"{ClasseAppoggio.manga.nomeManga}.jpg");
            imgManga.Image = UIImage.FromFile(imgPath);
            lblNomeManga.Text = ClasseAppoggio.manga.nomeManga;
        }
        public UIInterfaceOrientationMask CurrentOrientation = UIInterfaceOrientationMask.Portrait;

      

        public void SetLabel() {
            foreach (UIView view in viewVolumi.Subviews)
                view.RemoveFromSuperview();
            var mangaInfo = DataBase.GetListaVolumi(ClasseAppoggio.manga.nomeManga);
            int k = 5;
            for (int i = 0; i < mangaInfo.Count; i++, k += 20)
                viewVolumi.AddSubview(CreateLabel(mangaInfo[i], mangaInfo[i].isAcquistato, 5, k, 360, 20));
            scrViewVolumi.ContentSize = new CoreGraphics.CGSize(scrViewVolumi.Frame.Width, k);
            viewVolumi.Frame = new RectangleF(0, 0, (float)scrViewVolumi.Frame.Width, k);
        }
        public override void ViewDidAppear(Boolean animated) {
            SetLabel();
        }

        public UILabel CreateLabel(Volume volume, bool isAcquistato, int x, int y, float width, float height) {
            UILabel myLbl = new UILabel();
            myLbl.Frame = new CGRect(x, y, width, height);
            myLbl.Text = volume.nomeVolume;
            myLbl.TextColor = (isAcquistato) ? UIColor.Green : UIColor.Red;
            UITapGestureRecognizer labelTap = new UITapGestureRecognizer(() => {
                ClasseAppoggio.volume = volume;
                ViewControllerModificaVolume controller = Storyboard.InstantiateViewController("ViewControllerModificaVolume") as ViewControllerModificaVolume;
                if (controller != null)
                    NavigationController.PushViewController(controller, true);
            });
            myLbl.UserInteractionEnabled = true;
            myLbl.AddGestureRecognizer(labelTap);
            return myLbl;
        }
        partial void BtnModifica_TouchUpInside(UIButton sender) {
            ViewControllerModificaManga controller = Storyboard.InstantiateViewController("ViewControllerModificaManga") as ViewControllerModificaManga;
            if (controller != null)
                NavigationController.PushViewController(controller, true);
        }
    }
}