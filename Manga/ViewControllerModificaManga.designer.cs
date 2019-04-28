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
    [Register ("ViewControllerModificaManga")]
    partial class ViewControllerModificaManga
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAggiungi { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnModifica { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch swcCompletato { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch swcPosseduto { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch swcTuttiVolumi { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtLinkImg { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtNomeManga { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtNomeVolume { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtNumeroVolumi { get; set; }

        [Action ("BtnAggiungi_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnAggiungi_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnModifica_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnModifica_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnAggiungi != null) {
                btnAggiungi.Dispose ();
                btnAggiungi = null;
            }

            if (btnModifica != null) {
                btnModifica.Dispose ();
                btnModifica = null;
            }

            if (swcCompletato != null) {
                swcCompletato.Dispose ();
                swcCompletato = null;
            }

            if (swcPosseduto != null) {
                swcPosseduto.Dispose ();
                swcPosseduto = null;
            }

            if (swcTuttiVolumi != null) {
                swcTuttiVolumi.Dispose ();
                swcTuttiVolumi = null;
            }

            if (txtLinkImg != null) {
                txtLinkImg.Dispose ();
                txtLinkImg = null;
            }

            if (txtNomeManga != null) {
                txtNomeManga.Dispose ();
                txtNomeManga = null;
            }

            if (txtNomeVolume != null) {
                txtNomeVolume.Dispose ();
                txtNomeVolume = null;
            }

            if (txtNumeroVolumi != null) {
                txtNumeroVolumi.Dispose ();
                txtNumeroVolumi = null;
            }
        }
    }
}