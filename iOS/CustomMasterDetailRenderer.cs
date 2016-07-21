using System;
using MasterDetail.iOS;
using MonoTouch.UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

//TODO [assembly: ExportRenderer(typeof(MasterDetailPage), typeof(CustomMasterDetailRenderer))]
namespace MasterDetail.iOS
{
    public class CustomMasterDetailRenderer : PhoneMasterDetailRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var page = Element as MasterDetailPage;

            var navigationItem = this.NavigationController.TopViewController.NavigationItem;
            navigationItem.LeftBarButtonItems = new UIBarButtonItem[]
            {
                new UIBarButtonItem("MENU", UIBarButtonItemStyle.Plain, (s, _) => { page.IsPresented = !page.IsPresented; })
            };
        }
    }
}

