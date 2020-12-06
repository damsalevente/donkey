namespace WeCanCSharp
{
    /* This is the serialization format. */

    public class MyConfiguration
    {
        public MyCarConfiguration myCarConfiguration;

        public int refreshRate;
    }

    public static class Config
    {
        public static string filepath = "E:/config.xml";

        public static int defaultRefreshRate = 500;
    }
}