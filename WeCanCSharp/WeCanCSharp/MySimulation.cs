using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WeCanCSharp
{
    public class MySimulation : INotifyPropertyChanged
    {
        public MyCar myCar;

        public int RefreshRate { get; set; }

        /* TODO: Overflow protection is not implemented. Could be... */
        private UInt64 time = 0;

        public MySimulation(MyCar myCar, int refreshRate)
        {
            this.myCar = myCar;
            this.RefreshRate = refreshRate;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public UInt64 MyTime
        {
            get => this.time;
            set
            {
                /* The order of these functions must not be changed, or the 0th point will be lost. */
                OnPropertyChanging();

                time = value;
            }
        }

        protected void OnPropertyChanging([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}