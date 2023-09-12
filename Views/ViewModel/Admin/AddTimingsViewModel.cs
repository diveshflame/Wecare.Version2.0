using MVVM_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace Views.ViewModel.Admin
{
   public class AddTimingsViewModel : ViewModelBase
    {
        public ICommand SelectionChangedCommand { get; }
        public AddTimingsViewModel() 
        {

            SelectionChangedCommand = new RelayCommand<EventArgs>(ExecuteSelectionChanged);
        }
        private void ExecuteSelectionChanged(EventArgs e)
        {
        }
        }
}
