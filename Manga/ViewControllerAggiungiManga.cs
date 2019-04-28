using System;
using UIKit;
namespace Manga {
    public partial class ViewControllerAggiungiManga : UIViewController {
        public ViewControllerAggiungiManga (IntPtr handle) : base (handle) { }
        public override void ViewDidLoad() {
            ((AppDelegate)UIApplication.SharedApplication.Delegate).CurrentOrientation = UIInterfaceOrientationMask.Portrait;
            base.ViewDidLoad();
            View.AddGestureRecognizer(new UITapGestureRecognizer(() => View.EndEditing(true)));
        }
        partial void BtnAggiungi_TouchUpInside(UIButton sender) {
            try {
                DataBase.AddManga(txtNomeManga.Text, txtLinkImg.Text, int.Parse(txtNumeroVolumi.Text), swcCompletato.On, swcTuttiVolumi.On);
                UIAlertView alert = new UIAlertView()
                { Title = "Operazione completata", Message = "Manga aggiunto con successo al database" };
                alert.AddButton("OK");
                alert.Show();
            }
            catch (Exception e) {
                UIAlertView alert = new UIAlertView()
                { Title = "Operazione non riuscita", Message = e.Message };
                alert.AddButton("OK");
                alert.Show();
            }
        }
    }
}