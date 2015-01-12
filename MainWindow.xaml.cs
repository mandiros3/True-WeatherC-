using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Xml;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.IO;
using System.Web.UI;




namespace True_Weather
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler for when the window is loaded
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
           // resultPage.Navigate("about:blank");
        }



        // Event Handlers, Enter and find button click
        private void OnEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                EntryPoint();

            }
        }


        private void findButton_Click(object sender, RoutedEventArgs e)
        {
            EntryPoint();
        }





        private void EntryPoint()
        {
            // Check for good input, if it's a number and if it's > 4


            //TODO: implement cases for zip, address or city name

            string textZip = zipQuery.Text.Trim();


            if (textZip.Length > 4 && IsNumber(textZip))
            {
                // Reset error message

                // Store woeid 

                string woeid = GetWOEID(textZip);

                //call get weather function
                // this.resultPage.Navigate("about:blank");
                //this.resultPage.Refresh();

                GetWeather(woeid);
            }
            else
            {
                resultBox.Foreground = Brushes.Red;
                resultBox.Text ="Not a valid ZIP code";
            }






        }








        // returns true, if matches regex
        private bool IsNumber(string text)
        {
            Regex regex = new Regex(@"^\d{5}$");
            return regex.IsMatch(text);
        }


        //Gets the Woeid from zip code. Grabs woeid element from xml
        private string GetWOEID(string zipQuery)
        {


            string apiID = "dj0yJmk9Q3lYem5NdHg5Z2NXJmQ9WVdrOWVFSjFOMHhTTkRJbWNHbzlNQS0tJnM9Y29uc3VtZXJzZWNyZXQmeD04Mg--";

            string query = String.Format("http://where.yahooapis.com/v1/places.q('{0}')?appid={1}", zipQuery, apiID);

            XmlDocument woeidData = new XmlDocument();
            woeidData.Load(query);

            XmlNodeList kk = woeidData.GetElementsByTagName("woeid");

            return kk[0].InnerText;



        }

        // Get weather info from woeid...
        private void GetWeather(string woeid)
        {
            //grabbing weather data, raw
            string query = String.Format("http://weather.yahooapis.com/forecastrss?w={0}", woeid );
            XmlDocument wData = new XmlDocument();
            wData.Load(query);
            
            //Getting relevant results

            XmlNode channel = wData.SelectSingleNode("rss").SelectSingleNode("channel");
            string title = channel.SelectSingleNode("title").InnerText;
            Console.WriteLine(title);

            string description = channel.SelectSingleNode("description").InnerText;
            Console.WriteLine(description);

            string lastBuildDate = channel.SelectSingleNode("lastBuildDate").InnerText;
            Console.WriteLine(lastBuildDate);


            // THIS IS JUST TO MAKE SURE IT WORKS FOR PRACTICE PURPOSES **********************************************************

           // Tags with prefix xmlns, with no inner text, requiere a different way, which is to use the namespace manager
            // it's a bunch of key:value pairs


            XmlNamespaceManager man = new XmlNamespaceManager(wData.NameTable);

            // pass the prefix and the url of th namespace
            man.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");

            // for this one, same thing, expect that you need to pass two arguments, prefix and namespace manager. 


            string city = channel.SelectSingleNode("yweather:location", man).Attributes["city"].Value;
            Console.WriteLine(city);

            string region = channel.SelectSingleNode("yweather:location", man).Attributes["region"].Value;
            Console.WriteLine(region);

            string country = channel.SelectSingleNode("yweather:location", man).Attributes["country"].Value;
            Console.WriteLine(country);

            string temperature = channel.SelectSingleNode("yweather:units", man).Attributes["temperature"].Value;
            Console.WriteLine(temperature);

            string cdata = channel.SelectSingleNode("item").SelectSingleNode("description").InnerText;
            resultBox.Text = cdata;
                
           

          


          





        }

        

    }
}
