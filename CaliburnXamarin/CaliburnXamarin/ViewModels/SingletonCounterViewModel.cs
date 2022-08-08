using Caliburn.Micro;

namespace CaliburnXamarin.ViewModels
{
    public class SingletonCounterViewModel : Screen
    {
        #region Field Variables
        private int _count;
        #endregion

        #region Properties
        public string PageInformation { get; set; }

        public string CountNumber
        {
            get => $"Click Count: {_count}";
            private set => _ = value;
        }
        #endregion

        public SingletonCounterViewModel( )
        {
            PageInformation = "This view is a Counter View, that has been set up using a Singleton Class. Meaning this will keep it's value saved between reloads";
            
            _count = 0;
        }

        public void OnButtonPressed( )
        {
            _count++;
            NotifyOfPropertyChange(( ) => CountNumber);
        }
    }

}
