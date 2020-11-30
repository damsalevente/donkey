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
        readonly XmlSerializer xmlSerializer = new XmlSerializer(typeof(MyConfiguration));

        public void Serialize(MyConfiguration myConfiguration, string filepath)
        {
            using (FileStream stream = new FileStream(filepath, FileMode.Create, FileAccess.Write))
            {
                var writer = new StreamWriter(stream);

                StreamWriter sw = new StreamWriter(stream);

                xmlSerializer.Serialize(sw, myConfiguration);
            }
        }

        public MyConfiguration Deserialize(string filepath)
        {
            MyConfiguration myConfiguration;

            try
            {
                using (FileStream stream = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                {
                    myConfiguration = (MyConfiguration)xmlSerializer.Deserialize(stream);
                }
            }
            catch
            {
                myConfiguration = null;
            }

            return myConfiguration;
        }
    }
}
