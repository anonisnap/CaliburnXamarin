using Caliburn.Micro.Xamarin.Forms;
using CaliburnXamarin.Services;
using CaliburnXamarin.ViewModels;
using CaliburnXamarin.ViewModels.Popups;
using CaliburnXamarin.Views;
using CaliburnXamarin.Views.Popups;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;
using Unity;
using Xamarin.Forms;

namespace CaliburnXamarin
{
	public class App : FormsApplication
	{
		/// <summary>
		/// <b>Inversion of Control</b> (IoC) Container<br/>
		/// <br/>
		/// Used to access a seperate storage area for Classes
		/// </summary>
		private readonly IUnityContainer _unityContainer;

		public App(IUnityContainer container)
		{
			// Initializes the FormsApplication Framework
			Initialize( );

			_unityContainer = container;

			// Registers a NavigationPane as a Singleton
			_ = _unityContainer.RegisterType<NavigationPage>(TypeLifetime.Singleton);

			// Register all the Views and ViewModels needed
			RegisterViewsAndViewModels( );

			// Create the Base View and show the View to the User
			_ = DisplayRootView<NavigationView>( );
		}

		/// <summary>
		/// Registers all needed Views and ViewModels to the IoC Container
		/// </summary>
		private void RegisterViewsAndViewModels( )
		{
			// Singleton Counter
			_ = _unityContainer.RegisterType<SingletonCounterViewModel>(TypeLifetime.Singleton);
			_ = _unityContainer.RegisterType<SingletonCounterView>(TypeLifetime.Singleton);

			// Note List
			_ = _unityContainer.RegisterType<NotesViewModel>(TypeLifetime.Singleton, Invoke.Constructor(Resolve.Parameter( )));
			_ = _unityContainer.RegisterType<NotesView>(TypeLifetime.Singleton);

			// New Note Popup | Does this do anything?
			_ = _unityContainer.RegisterType<NewNotePopupViewModel>( );
			_ = _unityContainer.RegisterType<NewNotePopupView>( );
		}

		protected override void PrepareViewFirst(NavigationPage navigationPage)
		{
			NavigationService service = new NavigationService(navigationPage);
			_ = _unityContainer.RegisterInstance<INavigationService>(service, InstanceLifetime.Singleton);
			_ = _unityContainer.RegisterInstance(service, InstanceLifetime.Singleton);
		}
	}
}
