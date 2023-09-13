using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Views.ViewModel.Admin;
using Autofac;
using Wecare.Services.Interfaces;
using Wecare.Services.Service;
using WeCare.Data.Data.Doctor;

namespace Views.View
{
    /// <summary>
    /// Interaction logic for AddDoctor.xaml
    /// </summary>
    public partial class AddDoctor : UserControl
    {
        public AddDoctor()
        {
         
           
            InitializeComponent();
            
            
        }
      
    }
}
