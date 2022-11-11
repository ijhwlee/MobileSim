using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass01
{
    public class CompassViewModel : INotifyPropertyChanged
    {
        private double _heading = 0;
        public double Heading
        {
            get => _heading;
            set
            {
                _heading = 360-value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Heading)));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
