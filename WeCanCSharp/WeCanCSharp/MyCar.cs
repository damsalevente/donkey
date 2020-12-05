using System.ComponentModel;

namespace WeCanCSharp
{
    public class MyCar
    {
        public MyCarConfiguration myCarConfiguration;

        public DonkeyControl myInputData = new DonkeyControl();

        public MyCar(MyCarConfiguration myCarConfiguration)
        {
            this.myCarConfiguration = myCarConfiguration;
        }

        public MyCarConfiguration GetMyCarConfiguration()
        {
            return myCarConfiguration;
        }

        public void SetMyCarConfiguration(MyCarConfiguration myCarConfiguration)
        {
            this.myCarConfiguration = myCarConfiguration;
        }
    }

    public class MyCarConfiguration: INotifyPropertyChanged
    {
        /* PWM values */
        public int maxThrottle;
        public int maxLeftSteeringPWM;
        public int maxRightSteeringPWM;
        public int MaxThrottle
        {
            get
            {
                return this.maxThrottle;
            }
            set
            {
                if (this.maxThrottle != value)
                {
                    this.maxThrottle = value;
                    //this.OnPropertyChanged("MaxThrottle");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}