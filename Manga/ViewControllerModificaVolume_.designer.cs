// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Manga
{
    [Register ("ViewControllerModificaVolume")]
    partial class ViewControllerModificaVolume
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAggiungi { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch swcPosseduto { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtNomeVolume { get; set; }

        [Action ("BtnAggiungi_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnAggiungi_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnAggiungi != null) {
                btnAggiungi.Dispose ();
                btnAggiungi = null;
            }

            if (swcPosseduto != null) {
                swcPosseduto.Dispose ();
                swcPosseduto = null;
            }

            if (txtNomeVolume != null) {
                txtNomeVolume.Dispose ();
                txtNomeVolume = null;
            }
        }
    }
}