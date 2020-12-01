using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;

namespace WeCanCSharp
{
    public class MenuCommand : BaseCommand
    {
        MySimulation mySimulation;
        private readonly MyViewCreator myViewCreator = new MyViewCreator();

        public MenuCommand() {}
        public MenuCommand(MySimulation ms)
        {
            this.mySimulation = ms;
        }
        public override void Execute(object parameter)
        {
            string In = parameter as String;

            if (Equals(In, "Main"))
            {
                
            }
            if (Equals(In, "Configuration"))
            {
                MyConfigurationPage myConfigurationPage = new MyConfigurationPage();
                myViewCreator.CreateNewView(myConfigurationPage, mySimulation);
            }
            if (Equals(In, "About"))
            {
                MyAboutPage myAboutPage = new MyAboutPage();
                myViewCreator.CreateNewView(myAboutPage, null);
            }
            if (Equals(In, "Exit"))
            {
                CoreApplication.Exit();
            }
            //throw new NotImplementedException();
        }
    }
}
