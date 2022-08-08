using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;

namespace CaliburnXamarin.ViewModels
{
    public class ShellViewModel : Screen
    {
        #region Fields
        private readonly INavigationService _navService;
        #endregion

        #region Properties
        public string PageInformation { get; set; }
        #endregion

        public ShellViewModel(INavigationService navService)
        {
            _navService = navService;

            PageInformation = "Welcome to Xamarin.Forms!";
        }


        #region User Navigation Methods
        public async void NavOtherButton( )
        {
            await _navService.NavigateToViewModelAsync<SimpleCounterViewModel>( );
        }

        public async void NavSingleton( )
        {
            Screen newView = IoC.Get<SingletonCounterViewModel>( );
            await _navService.NavigateToViewModelAsync<SingletonCounterViewModel>(newView);
        }
        #endregion
    }
}
