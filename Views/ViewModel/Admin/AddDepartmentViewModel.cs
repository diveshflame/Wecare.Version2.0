using MVVM_App.ViewModels;
using System.Windows.Input;

namespace Views.ViewModel.Admin
{
    public class AddDepartmentViewModel : ViewModelBase
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    OnPropertyChanged(nameof(Text));
                }
            }

        }
        public ICommand AddDepartment { get; }
        public AddDepartmentViewModel() 
        {
            AddDepartment = new ViewModelCommand(ExecuteAddDepartment);
        }

        private void ExecuteAddDepartment(object obj)
        {
        
        }
    }
}
