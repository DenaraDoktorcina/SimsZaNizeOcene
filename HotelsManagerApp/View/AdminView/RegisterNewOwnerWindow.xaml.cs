﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HotelsManagerApp.Models;
using HotelsManagerApp.View.AdminViewModel;

namespace HotelsManagerApp.View.AdminView
{
    /// <summary>
    /// Interaction logic for RegisterNewOwnerWindow.xaml
    /// </summary>
    public partial class RegisterNewOwnerWindow : Window
    {
        public RegisterNewOwnerWindow(User logged)
        {
            InitializeComponent();
            DataContext = new RegisterNewOwnerViewModel(logged);
        }
    }
}
