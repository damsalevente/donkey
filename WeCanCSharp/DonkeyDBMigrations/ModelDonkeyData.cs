using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonkeyDBMigrations
{
    class ModelDonkeyData
    {
        public int ID { get; set; }
        public double Angle { get; set; }
        public double Throttle { get; set; }
        public UInt64 TimeStamp { get; set; }
    }
}
