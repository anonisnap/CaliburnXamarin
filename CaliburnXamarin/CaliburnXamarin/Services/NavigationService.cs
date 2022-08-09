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
				var view = ViewLocator.LocateForModelType(viewModel.GetType( ), null, null);

				ViewModelBinder.Bind(viewModel, view, null);


				if ( !( view is PopupPage page ) )
				{
					throw new NotSupportedException($"{view.GetType( )} does not inherit from either {typeof(Page)} or {typeof(PopupPage)}.");
				}

				return _curPage.Navigation.PushPopupAsync(page, animated); // This is null?
			}
			catch ( Exception )
			{

				throw;
			}
		}

		public Task NavigateToPopupAsync(PopupPage view, bool animated = true)
		{
			var model = ViewModelLocator.LocateForView(view);
			ViewModelBinder.Bind(model, view, null);
			return _navPage.Navigation.PushPopupAsync(view, animated);
		}
	}
}
