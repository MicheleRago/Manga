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
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAggiungi { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView scrViewManga { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCerca { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewMangaList { get; set; }

        [Action ("BtnAggiungi_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnAggiungi_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnAggiungi != null) {
                btnAggiungi.Dispose ();
                btnAggiungi = null;
            }

            if (scrViewManga != null) {
                scrViewManga.Dispose ();
                scrViewManga = null;
            }

            if (txtCerca != null) {
                txtCerca.Dispose ();
                txtCerca = null;
            }

            if (viewMangaList != null) {
                viewMangaList.Dispose ();
                viewMangaList = null;
            }
        }
    }
}