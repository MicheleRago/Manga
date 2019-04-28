using Foundation;
using System;
using UIKit;

namespace Manga {
    public partial class ViewControllerModificaVolume : UIViewController {
        public ViewControllerModificaVolume (IntPtr handle) : base (handle) { }
        public override void ViewDidLoad() {
            base.ViewDidLoad();
            View.AddGestureRecognizer(new UITapGestureRecognizer(() => View.EndEditing(true)));
            txtNomeVolume.Text = ClasseAppoggio.volume.nomeVolume;
            swcPosseduto.On = ClasseAppoggio.volume.isAcquistato;
        }

        partial void BtnAggiungi_TouchUpInside(UIButton sender) {
            try {
                DataBase.ModificaVolume(ClasseAppoggio.volume, swcPosseduto.On, ClasseAppoggio.manga.nomeManga);
                UIAlertView alert = new UIAlertView()
                { Title = "Operazione completata", Message = "Manga aggiornato con successo al database" };
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