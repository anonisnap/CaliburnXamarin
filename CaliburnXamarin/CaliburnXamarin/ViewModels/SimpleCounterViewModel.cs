using Caliburn.Micro;

namespace CaliburnXamarin.ViewModels
{
    public class SimpleCounterViewModel : Screen
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

        public SimpleCounterViewModel( )
        {
            PageInformation = "This view is a Simple Counter View. It has been set up with each opening being a new instance. This does not keep track of counts";

            _count = 0;
        }

        public void OnButtonPressed( )
        {
            _count++;
            NotifyOfPropertyChange(( ) => CountNumber);
        }
    }
}
