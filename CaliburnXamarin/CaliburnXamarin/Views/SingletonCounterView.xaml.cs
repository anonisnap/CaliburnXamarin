﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CaliburnXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SingletonCounterView : ContentPage
    {
        public SingletonCounterView( )
        {
            InitializeComponent( );
        }
    }
}