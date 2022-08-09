using Caliburn.Micro.Xamarin.Forms;
using CaliburnXamarin.ViewModels;
using CaliburnXamarin.Views;
using Unity;
using Xamarin.Forms;

namespace CaliburnXamarin {
	public class App : FormsApplication {
		/// <summary>
		/// <b>Inversion of Control</b> (IoC) Container<br/>
		/// <br/>
		/// Used to access a seperate storage area for Classes
		/// </summary>
		private readonly IUnityContainer _unityContainer;

		public App(IUnityContainer container) {
			// Initializes the FormsApplication Framework
			Initialize( );

			_unityContainer = container;

			// Registers a NavigationPane as a Singleton
			_unityContainer.RegisterType<NavigationPage>(TypeLifetime.Singleton);

			// Register all the Views and ViewModels needed
			RegisterViewsAndViewModels( );

			// Create the Base View and show the View to the User
			//_ = DisplayRootView<NavigationView>( );
			_ = DisplayRootView<NavigationView>( );
		}

		/// <summary>
		/// Registers all needed Views and ViewModels to the IoC Container
		/// </summary>
		private void RegisterViewsAndViewModels( ) {
			// Navigation
			//_unityContainer.RegisterType<NavigationViewModel>(TypeLifetime.Singleton, Invoke.Constructor(Resolve.Parameter( )));
			//_unityContainer.RegisterType<NavigationView>(TypeLifetime.Singleton);

			// Singleton Counter
			_unityContainer.RegisterType<SingletonCounterViewModel>(TypeLifetime.Singleton);
			_unityContainer.RegisterType<SingletonCounterView>(TypeLifetime.Singleton);
		}

		protected override void PrepareViewFirst(NavigationPage navigationPage) {
			_unityContainer.RegisterInstance<INavigationService>(new NavigationPageAdapter(navigationPage));
		}
	}
}
