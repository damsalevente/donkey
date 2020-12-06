namespace WeCanCSharp
{
    public class DonkeyConfigViewModel
    {
        public MyCarConfiguration donkeyConfig;

        public DonkeyConfigViewModel(MyCarConfiguration donkey)
        {
            this.donkeyConfig = donkey;
        }

        public int MaxLeftSteeringPWM
        {
            get
            {
                return (int)((double)donkeyConfig.maxLeftSteeringPWM / 255 * 100);
            }
            set
            {
                donkeyConfig.maxLeftSteeringPWM = (int)((double)value / 100 * 255);
            }
        }

        public int MaxRightSteeringPWM
        {
            get
            {
                return (int)((double)donkeyConfig.maxRightSteeringPWM / 255 * 100);
            }
            set
            {
                donkeyConfig.maxRightSteeringPWM = (int)((double)value / 100 * 255);
            }
        }

        public int MaxThrottle
        {
            get
            {
                return (int)((double)donkeyConfig.maxThrottle / 255 * 100);
            }
            set
            {
                donkeyConfig.maxThrottle = (int)((double)value / 100 * 255);
            }
        }
    }
}