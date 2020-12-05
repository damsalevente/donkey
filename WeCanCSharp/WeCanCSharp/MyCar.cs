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

    public class MyCarConfiguration
    {
        /* PWM values */
        public int maxThrottle;
        public int maxLeftSteeringPWM;
        public int maxRightSteeringPWM;
    }
}