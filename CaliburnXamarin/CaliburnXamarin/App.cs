using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;
using CaliburnXamarin.ViewModels;
using CaliburnXamarin.Views;
using System;
using System.Threading.Tasks;
using Unity;
using Xamarin.Forms;

namespace CaliburnXamarin
{
    public class App : FormsApplication
    {
        private readonly IUnityContainer _unityContainer;

        public App(IUnityContainer container)
        {
            // Initialize the FormsApplication Framework
            Initialize( );

            // # UnityContainer is an IoC object. Inversion of Control Objet #

            // Set the Container Field to the injected Container
            _unityContainer = container;

            // Register a NavigationPane as a Singleton
            _unityContainer.RegisterType<NavigationPage>(TypeLifetime.Singleton);

            // Register the Views and ViewModels to the IoC Container
            // Allows access to the Views and ViewModels through the IoC Container
            _unityContainer.RegisterType<ShellViewModel>(TypeLifetime.Singleton);
            _unityContainer.RegisterType<ShellView>(TypeLifetime.Singleton);

            // Not adding OtherButtonViewModel / OtherButtonView as Singletons
            /*
             * _unityContainer.RegisterType<OtherButtonViewModel>(TypeLifetime.Singleton);
             * _unityContainer.RegisterType<OtherButtonView>(TypeLifetime.Singleton);
             */

            // Adding SingletonViewModel and SingletonView to the IoC Container to access them later
            _unityContainer.RegisterType<SingletonCounterViewModel>(TypeLifetime.Singleton);
            _unityContainer.RegisterType<SingletonCounterView>(TypeLifetime.Singleton);


            // Create the Base View as a ShellView
            // Show the View to the User
            DisplayRootView<ShellView>( );
        }

        protected override void PrepareViewFirst(NavigationPage navigationPage)
        {
            _unityContainer.RegisterInstance<INavigationService>(new NavigationPageAdapter(navigationPage));
        }
    }
}
