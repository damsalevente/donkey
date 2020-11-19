using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WeCanCSharp
{
    public class MySimulation : INotifyPropertyChanged
    {
        public MyCar myCar;

        public int refreshRate { get; set; }

        /* TODO: Overflow protection is not implemented. Could be... */
        private UInt64 time = 0;

        public MySimulation(MyCar myCar, int refreshRate)
        {
            this.myCar = myCar;
            this.refreshRate = refreshRate;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public UInt64 myTime
        {
            get => this.time;
            set 
            {
                time = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
