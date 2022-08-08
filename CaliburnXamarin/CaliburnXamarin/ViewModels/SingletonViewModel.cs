using Caliburn.Micro;

namespace CaliburnXamarin.ViewModels
{
    public class SingletonViewModel : Screen
    {
        private int _count;

        public string CountNumber
        {
            get => $"Click Count: {_count}";
            private set => _ = value;
        }

        public SingletonViewModel( )
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
