using Lab19WpfApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab19WpfApp.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string PropertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private double radius;
        public double Radius
        {
            get => radius;
            set
            {
                radius = value;
                OnPropertyChanged();
            }
        }

        private double length;
        public double Length
        {
            get => length;
            set
            {
                length = value;
                OnPropertyChanged();
            }
        }

        public ICommand LengthCommand { get; }
        private void OnLengthCommandExecute(object p)
        {
            Length = CircleLength.GetCircleLength(Radius);
        }
        private bool CanLengthCommandExecuted(object p)
        {
            if (Radius > 0)
                return true;
            else
                return false;
        }
        public MainWindowViewModel()
        {
            LengthCommand = new RelayCommand(OnLengthCommandExecute, CanLengthCommandExecuted);
        }
    }
}
