using Newtonsoft.Json;

namespace WeCanCSharp
{
    internal class HttpConverter
    {
        public DonkeyControl ConvertDataFromDonkeyCarMessage(string rawdata)
        {
            /* first, convert string to donkey primitive data */
            if (rawdata == "")
            {
                DonkeyControl empty = new DonkeyControl();
                return empty;
            }
            DonkeyControl dk = JsonConvert.DeserializeObject<DonkeyControl>(rawdata);
            /* scale for view */
            dk.Throttle = dk.Throttle * 10;
            dk.Angle = dk.Angle * 10;
            return dk;
        }

        public string ConvertDataToDonkeyCarMessage(DonkeyControl dk)
        {
            /* scale the values */
            dk.Angle = dk.Angle / 10;
            dk.Throttle = dk.Throttle / 10;
            return JsonConvert.SerializeObject(dk);
        }
    }
}