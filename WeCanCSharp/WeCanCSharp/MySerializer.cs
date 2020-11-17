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
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(MyCarConfiguration));

        public void mySerializerRoutine(MyCarConfiguration myCarConfiguration, string filepath)
        {
            using (FileStream stream = new FileStream(filepath, FileMode.Create, FileAccess.Write))
            {
                var writer = new StreamWriter(stream);

                StreamWriter sw = new StreamWriter(stream);

                xmlSerializer.Serialize(sw, myCarConfiguration);
            }
        }

        public MyCarConfiguration myDeserializerRoutine(string filepath)
        {
            MyCarConfiguration myCarConfiguration;

            try
            {
                using (FileStream stream = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                {
                    myCarConfiguration = (MyCarConfiguration)xmlSerializer.Deserialize(stream);
                }
            }
            catch
            {
                myCarConfiguration = null;
            }

            return myCarConfiguration;
        }
    }
}
