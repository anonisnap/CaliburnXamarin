using Caliburn.Micro;

namespace CaliburnXamarin.ViewModels
{
    public class OtherButtonViewModel : Screen
    {
        private int _count;

        public string CountNumber
        {
            get => $"Click Count: {_count}";
            private set => _ = value;
        }

        public OtherButtonViewModel( )
        {
            _count = 0;
        }

        public void OnButtonPressed( )
        {
            _count++;
            NotifyOfPropertyChange(( ) => CountNumber);
        }
    }
}
