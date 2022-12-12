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
        public static string GetSearchCommand(string sender)
        {

            return "Name LIKE '*" + sender + "*'";



        }

        public static string GetAuthorSearchCommand(string sender)
        {

            return "Author LIKE '*" + sender + "*'";



        }

        public static string GetTitlesCommand()
        {

            return "SELECT * FROM Titles ORDER BY Title";



        }

        public static string GetTitlesSearchCommand(string sender)
        {

            return "Title LIKE '*" + sender + "*'";

        }
        public static string GetTitleISBNCommand(string sender)
        {

            return "ISBN= '" + sender + "'";

        }
        public static string GetISBNCommand(string sender)
        {
            string command = "SELECT * from Title_Author WHERE ISBN='"+ sender+"'" ;
            return command;

        }


        public static string GetPUblisherCommand()
        {
            string command = "SELECT * from Publishers Order By Name";
            return command;

        }

    }

    [Serializable]
    public class BookObject
    {
        public BookObject()
        {
            authors = new List<string>(); // init authors in constructor
        }
        public string id { get; set; }
        public string title { get; set; }
        public List<string> authors { get; set; }
        public string publisher { get; set; }
        public string publishedDate { get; set; }
        public int pageCount { get; set; }

        // Availability
        public bool pdfAvailable { get; set; }
        public string pdfLink { get; set; }
        public bool epubAvailable { get; set; }
        public string epubLink { get; set; }
        public string forSale { get; set; }
        public string saleLink { get; set; }
    }
}
