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
        public string Text { get; set; } = "Welcome to Xamarin.Forms!";
        #endregion

        public ShellViewModel(INavigationService navService)
        {
            _navService = navService;
        }


        #region User Navigation Methods
        public async void NavOtherButton( )
        {
            await _navService.NavigateToViewModelAsync<OtherButtonViewModel>( );
        }

        public async void NavSingleton( )
        {
            Screen newView = IoC.Get<SingletonViewModel>( );
            await _navService.NavigateToViewModelAsync<SingletonViewModel>(newView);
        }
        #endregion
    }
}
