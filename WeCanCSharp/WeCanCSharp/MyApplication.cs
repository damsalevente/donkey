using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeCanCSharp
{
    /* This is the highest layer of the computing logic */
    class MyApplication
    {
        MyCar myCar;

        MyBluetoothHandler myBluetoothHandler = new MyBluetoothHandler();

        MyBluetoothConverter myBluetoothConverter = new MyBluetoothConverter();

        public MyApplication()
        {
            /* TODO: Get the settings from the settings.xml */
            myCar = new MyCar(1, 1, 1);

            /* TODO: This is not so nice here... The refresh rate also needs to come from settings.xml */
            /* Start the cyclic refresh */
            cyclicRefreshData(2000);
        }

        /* This function is an infinite loop which runs with refreshRate ms */
        async private void cyclicRefreshData(int refreshRate)
        {
            /* TODO: This works but not so nice... */
            while (true)
            {
                if (myBluetoothHandler.isBluetoothConnected)
                {
                    myBluetoothHandler.requestData();

                    myCar.myInputData = myBluetoothConverter.getDataFromBluetoothMessage(myBluetoothHandler.receiveData());
                }

                await Task.Delay(refreshRate);
            }
        }


    }
}
