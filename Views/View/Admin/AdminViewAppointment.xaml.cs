﻿using Autofac.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Views.ViewModel.Admin;

namespace Views.View.Admin
{
    /// <summary>
    /// Interaction logic for AdminViewAppointment.xaml
    /// </summary>
    public partial class AdminViewAppointment : UserControl
    {
        public AdminViewAppointment()
        {
            InitializeComponent();

          //  this.DataContext = container.Resolve<AdminViewAppointmentViewModel>();
        }
    }
}
