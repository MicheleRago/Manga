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
    [Register ("ViewControllerMangaInfo")]
    partial class ViewControllerMangaInfo
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnModifica { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgManga { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblNomeManga { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView scrViewVolumi { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewVolumi { get; set; }

        [Action ("BtnModifica_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnModifica_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnModifica != null) {
                btnModifica.Dispose ();
                btnModifica = null;
            }

            if (imgManga != null) {
                imgManga.Dispose ();
                imgManga = null;
            }

            if (lblNomeManga != null) {
                lblNomeManga.Dispose ();
                lblNomeManga = null;
            }

            if (scrViewVolumi != null) {
                scrViewVolumi.Dispose ();
                scrViewVolumi = null;
            }

            if (viewVolumi != null) {
                viewVolumi.Dispose ();
                viewVolumi = null;
            }
        }
    }
}