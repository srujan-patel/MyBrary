using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace MyBrary
{
    public partial class GoogleSearch : Form
    {

        public const string bookURL = "https://www.googleapis.com/books/v1/volumes/"; //google boooks api
        HttpClient booksClient = new HttpClient(); //http client object

        public GoogleSearch()
        {
            InitializeComponent();
            booksClient.BaseAddress = new Uri(bookURL);
        }

        private void GoogleSearch_Load(object sender, EventArgs e)
        {
            messageText.Text = "Please Enter a Book Address or Search for a Book"; //Default Address
            outputBox.Text = ""; //initializing with an empty string 
            maxResults.Value = 5;



            //adding items to the search combo box
            string[] searchItems = new string[] { "all", "titles", "authors", "publishers" };
            searchCombo.Items.AddRange(searchItems);
            searchCombo.SelectedItem = "all"; //default selection of the combobox

            //display list box
            string[] resultItems = new string[] { "Titles", "Authors", "Publishers", "Published Date" };
            displayListBox.Items.AddRange(resultItems);
            for(int i = 0; i < displayListBox.Items.Count - 1; i++)
            {
                displayListBox.SetItemChecked(i, true);

            }


            //availability information
            string[] availabilityItems = new string[] { "PDF Aavilable", "PDF Link", "EPUB Available", "EPUB Link", "For Sale", "Sale Link" };
            availabilityListBox.Items.AddRange(availabilityItems);
            for(int i=0; i<availabilityListBox.Items.Count-1; i++)
            {
                availabilityListBox.SetItemChecked(i, true);
            }


        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            outputBox.Text = "";
            String urlParams= inputText.Text;
            HttpResponseMessage response;

            string searchFor = searchCombo.SelectedItem.ToString();
            Console.WriteLine("Searching for " + searchFor);

            urlParams = "?q="; // Search param

            if (searchFor == "authors")
            {
                urlParams += "inauthor:" + inputText.Text;
            }
            else if (searchFor == "titles")
            {
                
                urlParams += "intitle:" + inputText.Text;
            }

            else if(searchFor=="publishers")
            {
                urlParams += "inpublisher:" + inputText.Text;

            }

            else
            {
                urlParams += inputText.Text;
            }


            urlParams += "&maxResults=" + maxResults.Value; // Adding max results
            response = booksClient.GetAsync(urlParams).Result;

            if (response.IsSuccessStatusCode) { 
            JObject bookJson = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            string text = "Number of records: " + bookJson["totalItems"].ToString() + "\r\n \r\n";

            string availability = "Availability: ";


            outputBox.Text = text + availability;

            JArray books = (JArray)bookJson["items"];

            StringBuilder sb = new StringBuilder();

            if (books != null)
            {
                foreach (var book in books)
                {
                    sb.Append(ParseBook((JObject)book) + "\r\n \r\n");
                }
                outputBox.Text += sb.ToString();
           
                messageText.Text = bookURL + urlParams;
            }
            else
            {
                messageText.Text = "Fail: Search didn't provide any valid results"; // messagebox failure message display
            }
            }
            else
            {
                messageText.Text = "Fail: " + (int)response.StatusCode + " " + response.ReasonPhrase; //messagebox failure code message
            }
        }

        // Parses the Json for the Book Info Box
        public string ParseBook(JObject bookJson)
        {
            BookObject book = new BookObject(); // Create the book object


            JObject volumeInfoObject = (JObject)bookJson["volumeInfo"]; // Reading book info for attributes
            JObject searchInfoObject = (JObject)bookJson["searchInfo"]; 

            StringBuilder sb = new StringBuilder(); // Printing to screen

            bool[] resultBool = new bool[displayListBox.Items.Count];
            for (int i = 0; i <= displayListBox.Items.Count - 1; i++)
            {
                resultBool[i] = displayListBox.GetItemChecked(i);
            }

            if (resultBool[0])
            {
                book.title = ParseString(volumeInfoObject, "title");
                sb.Append("Title: " + book.title + " \r\n");
            }
            if (resultBool[1])
            {
                JArray authors = (JArray)volumeInfoObject["authors"];

                sb.Append("Authors: ");

                if (authors != null)
                {
                    foreach (var author in authors)
                    {
                        book.authors.Add(author.ToString());
                        sb.Append(author + ", ");
                    }

                }
                sb.Append("\r\n");

            }

            if (resultBool[2])
            {
                book.publisher = ParseString(volumeInfoObject, "publisher");
                sb.Append("Publisher: " + book.publisher + " \r\n");
            }
            if (resultBool[3])
            {
                book.publishedDate = ParseString(volumeInfoObject, "publishedDate");
                sb.Append("Published: " + book.publishedDate + " \r\n");
            }
          


            //// Parsing Availability
            // "PDF Available", "PDF Link", "Epub Available", "Epub Link", "For Sale", "Sale Link
            JObject countryObject = ParseJObject(bookJson, "country");
            if (countryObject.Count == 0)
            {
                book.pdfAvailable = false;
                book.pdfLink = "N/A";
                book.epubAvailable = false;
                book.epubLink = "N/A";
            }
            else
            {
                JObject epubObject = (JObject)countryObject["epub"]; // Reading Epub
                JObject pdfObject = (JObject)countryObject["pdf"]; // Reading PDF

                book.pdfAvailable = ParseBool(pdfObject, "isAvailable");
                book.pdfLink = ParseString(pdfObject, "acsTokenLink");
                book.epubAvailable = ParseBool(epubObject, "isAvailable");
                book.epubLink = ParseString(epubObject, "acsTokenLink");
            }

            JObject saleInfoObject = ParseJObject(bookJson, "saleInfo"); // Reading sale
            if (saleInfoObject.Count == 0)
            {
                book.forSale = "Not for sale";
                book.saleLink = "N/A";
            }
            else
            {
                book.forSale = ParseString(saleInfoObject, "saleability");
                book.saleLink = ParseString(saleInfoObject, "buyLink");
                if (book.saleLink == "")
                {
                    book.saleLink = "N/A";
                }
            }

            // Retrieving the availability items and items checked
            bool[] availBool = new bool[availabilityListBox.Items.Count];
            for (int i = 0; i <= availabilityListBox.Items.Count - 1; i++)
            {
                availBool[i] = availabilityListBox.GetItemChecked(i);
            }

            if (availBool[0])
            {
                sb.Append("PDF Available: " + book.pdfAvailable + " \r\n");
            }
            if (availBool[1])
            {
                sb.Append("PDF Link: " + book.pdfLink + " \r\n");
            }
            if (availBool[2])
            {
                sb.Append("EPUB Available: " + book.epubAvailable + " \r\n");
            }
            if (availBool[3])
            {
                sb.Append("EPUB Link: " + book.epubLink + " \r\n");
            }
            if (availBool[4])
            {
                sb.Append("For Sale: " + book.forSale + " \r\n");
            }
            if (availBool[5])
            {
                sb.Append("Sale Link: " + book.saleLink + " \r\n");
            }

            return sb.ToString();
        }

        // Parsing Json string
        public static string ParseString(JObject bookJson, string toParse)
        {
            if (bookJson == null)
            {
                return "";
            }
            else if (bookJson[toParse] == null)
            {
                return "";
            }
            else return (string)bookJson[toParse];
        }

        // Parsing Json boolean
        public static bool ParseBool(JObject bookJson, string toParse)
        {
            if (bookJson == null)
            {
                return false;
            }
            else if (bookJson[toParse] == null)
            {
                return false;
            }
            else return (bool)bookJson[toParse];
        }

        // Parsing Json integer
        public static int ParseInt(JObject bookJson, string toParse)
        {
            if (bookJson == null)
            {
                return 0;
            }
            else if (bookJson[toParse] == null)
            {
                return 0;
            }
            else return (int)bookJson[toParse];
        }

        // Parsing Json Object
        public static JObject ParseJObject(JObject bookJson, string toParse)
        {
            JObject jo = new JObject();
            if (bookJson == null)
            {
                return jo;
            }
            else if (bookJson[toParse] == null)
            {
                return jo;
            }
            else return (JObject)bookJson[toParse];
        }

        private void selectDisplayButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < displayListBox.Items.Count; i++)
            {
                displayListBox.SetItemChecked(i, true);
            }
        }

        private void clearDisplayButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < displayListBox.Items.Count; i++)
            {
                displayListBox.SetItemChecked(i, false);
            }
        }

        private void selectAvailabilityButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < availabilityListBox.Items.Count; i++)
            {
                availabilityListBox.SetItemChecked(i, true);
            }
        }

        private void clearAvailabilityButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < availabilityListBox.Items.Count; i++)
            {
                availabilityListBox.SetItemChecked(i, false);
            }
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
