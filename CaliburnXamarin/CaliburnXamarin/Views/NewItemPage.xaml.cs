﻿using CaliburnXamarin.Models;
using CaliburnXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CaliburnXamarin.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item
        {
            get; set;
        }

        public NewItemPage( )
        {
            InitializeComponent( );
            BindingContext = new NewItemViewModel( );
        }
    }
}