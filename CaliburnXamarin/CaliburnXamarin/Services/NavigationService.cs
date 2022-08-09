using Caliburn.Micro.Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CaliburnXamarin.Services
{
	public class NavigationService : NavigationPageAdapter, INavigationService
	{
		private readonly NavigationPage _navPage;
		private Page _curPage;


		public NavigationService(NavigationPage navigationPage) : base(navigationPage)
		{
			_navPage = navigationPage;
			_curPage = navigationPage.CurrentPage;

			// Adds the Methods below to the Corresponding methods in the NavigationPane
			// Means these are called as well, when the NavigationPane Methods are called
			_navPage.Pushed += onPushed;
			_navPage.Popped += onPopped;
			_navPage.PoppedToRoot += onPoppedToRoot;
		}

		private void onPushed(object sender, NavigationEventArgs e)
		{
			_curPage = _navPage.CurrentPage;
		}

		private void onPopped(object sender, NavigationEventArgs e)
		{
			_curPage = _navPage.CurrentPage;
		}

		private void onPoppedToRoot(object sender, NavigationEventArgs e)
		{
			_curPage = _navPage.CurrentPage;
		}

		public Task NavigateToPopupViewModelAsync(object viewModel, bool animated = true)
		{
			try
			{
				// Find the View for the given ViewModel
				var view = ViewLocator.LocateForModelType(viewModel.GetType( ), null, null);

				// Bind the View and ViewModel together
				ViewModelBinder.Bind(viewModel, view, null);

				// if the View is NOT a PopupPage -> Throw an Exception
				if ( !( view is PopupPage page ) )
				{
					throw new NotSupportedException($"{view.GetType( )} does not inherit from either {typeof(Page)} or {typeof(PopupPage)}.");
				}

				return _curPage.Navigation.PushPopupAsync(page, animated);
			}
			catch ( Exception )
			{
				throw;
			}
		}

		public Task NavigateToPopupAsync(PopupPage view, bool animated = true)
		{
			// Find the ViewModel for the given View
			var viewModel = ViewModelLocator.LocateForView(view);

			// Bind the ViewModel and View
			ViewModelBinder.Bind(viewModel, view, null);

			return _navPage.Navigation.PushPopupAsync(view, animated);
		}
	}
}
