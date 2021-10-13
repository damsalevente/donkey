using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static string filepath = @"c:\Users\Matyi\Documents\config.xml";

        public static int defaultRefreshRate = 500;
    }
}
