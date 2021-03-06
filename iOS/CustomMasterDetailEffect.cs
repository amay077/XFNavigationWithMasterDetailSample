﻿using System;
using MasterDetail.iOS;
using MonoTouch.UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("mycompany")]
[assembly: ExportEffect(typeof(CustomMasterDetailEffect), "CustomMasterDetailEffect")]
namespace MasterDetail.iOS
{
    public class CustomMasterDetailEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var page = Element as MasterDetailPage;
            NavigationPage.SetHasBackButton(page, false);
            page.Appearing += Page_Appearing;
        }

        protected override void OnDetached()
        {
            var page = Element as MasterDetailPage;
            page.Appearing -= Page_Appearing;
        }

        void Page_Appearing(object sender, EventArgs e)
        {
            var vc = GetParentViewController();
            var page = Element as MasterDetailPage;

            var navigationItem = vc.NavigationController.TopViewController.NavigationItem;
            navigationItem.LeftBarButtonItems = new UIBarButtonItem[]
            {
                new UIBarButtonItem("MENU", UIBarButtonItemStyle.Plain, (s, _) => { page.IsPresented = !page.IsPresented; })
            };
        }

        UIViewController GetParentViewController()
        {
            UIResponder responder = this.Container;
            while ((responder = responder.NextResponder) != null)
            {
                if (responder is UIViewController)
                {
                    return (UIViewController)responder;
                }
            }
            return null;
        }
    }
}

