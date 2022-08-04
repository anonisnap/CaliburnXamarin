using CaliburnXamarin.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CaliburnXamarin.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage( )
        {
            InitializeComponent( );
            BindingContext = new ItemDetailViewModel( );
        }
    }
}