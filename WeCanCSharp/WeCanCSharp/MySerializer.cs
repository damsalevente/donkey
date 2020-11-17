using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace WeCanCSharp
{
    class MySerializer
    {
        public void mySerializerRoutine(MyCarConfiguration myCarConfiguration)
        {


            //XmlSerializer xmlSerializer = new XmlSerializer();
            //const string xmlFilename = "MyConfiguration.xml";
            


        }
        public void myDeserializerRoutine(string maximumThrottleInputText, string maximumLeftSteeringValue, string maximumRightSteeringValue)
        {
            /* TODO: This should not be here...*/
            List<string> myConfigList = new List<string>();

            myConfigList.Add(maximumThrottleInputText);
            myConfigList.Add(maximumLeftSteeringValue);
            myConfigList.Add(maximumRightSteeringValue);


        }
    }
}
