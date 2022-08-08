using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;

namespace CaliburnXamarin.ViewModels {
    public class NavigationViewModel : Screen {
        #region Fields
        private readonly INavigationService _navService;
        #endregion

        #region Properties
        public string PageInformation {
            get; set;
        }
        public string NavSimpleCounterButton {
            get; set;
        }
        public string NavSingletonCounterButton {
            get; set;
        }
        #endregion

        public NavigationViewModel(INavigationService navigationService) {
            _navService = navigationService;

            PageInformation = "This is the Main Navigation Screen";
            NavSimpleCounterButton = "Simple Counter";
            NavSingletonCounterButton = "Singleton Counter";
        }

        #region User Navigation Methods
        public async void NavSimpleCounter( ) {
            await _navService.NavigateToViewModelAsync<SimpleCounterViewModel>( );
        }

        public async void NavSingletonCounter( ) {
            Screen newView = IoC.Get<SingletonCounterViewModel>( );
            await _navService.NavigateToViewModelAsync<SingletonCounterViewModel>(newView);
        }
        #endregion
    }
}
