using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace MyBrary
{

    public static class Helper
    {

        public static string ConVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        public static string GetAuthorCommand()
        {
            string command = "SELECT * from Authors Order By Author";
            return command;
           
        }

        public static string GetPublisherCommand()
        {
            string command = "SELECT * from Publishers Order By Name";
            return command;

        }



    }


}
