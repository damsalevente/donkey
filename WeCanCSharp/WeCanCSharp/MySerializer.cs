using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WeCanCSharp
{
    class MySerializer
    {
        public void mySerializerRoutine(string maximumThrottleInputText, string maximumLeftSteeringValue, string maximumRightSteeringValue)
        {
            /* TODO: This should not be here...*/
            List<string> myConfigList = new List<string>();

            myConfigList.Add(maximumThrottleInputText);
            myConfigList.Add(maximumLeftSteeringValue);
            myConfigList.Add(maximumRightSteeringValue);

        }
    }
}
