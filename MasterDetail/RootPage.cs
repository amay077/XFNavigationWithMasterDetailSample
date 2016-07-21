using System;
using Xamarin.Forms;
using System.Linq;

namespace MasterDetail
{
	public class RootPage : MasterDetailPage
	{
		MenuPage menuPage;

		public RootPage ()
		{
			menuPage = new MenuPage ();

			menuPage.Menu.ItemSelected += (sender, e) => NavigateTo (e.SelectedItem as MenuItem);

			Master = menuPage;
			Detail = new ContractsPage();

            NavigationPage.SetHasBackButton(this, false);
            Effects.Add(Effect.Resolve("mycompany.CustomMasterDetailEffect"));
		}

		void NavigateTo (MenuItem menu)
		{
			if (menu == null)
				return;
			
			Page displayPage = (Page)Activator.CreateInstance (menu.TargetType);

			Detail = displayPage;

			menuPage.Menu.SelectedItem = null;
			IsPresented = false;
		}
	}
}