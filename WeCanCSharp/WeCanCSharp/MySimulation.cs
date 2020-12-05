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
        private static MySimulation instance = null;
        
        public MyCar myCar;

        public int RefreshRate { get; set; }

        private UInt64 time = 0;

        private MySimulation(){}

        public static MySimulation Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MySimulation();
                }
                return instance;
            }
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
