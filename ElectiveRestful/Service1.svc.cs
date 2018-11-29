using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace ElectiveRestful {
    public class Service1 : IService1 {
        /*
         * This service is loading an xml of song data in memory, and adding another artist with song information
        */
        public string songUpload(string artist_name, string album, string song_name, string genre, string year_released, string duration) {
            XDocument xd = XDocument.Load(@"http://webstrar15.fulton.asu.edu/page10/Member.xml");

            XElement root = new XElement("artist");

            //adding its child elements
            root.Add(new XElement("artist_name", artist_name));
            root.Add(new XElement("album", album));
            root.Add(new XElement("song_name", song_name));
            root.Add(new XElement("genre", genre));
            root.Add(new XElement("year_released", year_released));
            root.Add(new XElement("duration", duration));

            //adding this root to the correct xml position
            xd.Element("database").Element("artist_database").Add(root);
            
            //find location of path inside server
            string flocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");

            //find up a few levels to where page0 -pages10 located
            string newpath = Path.GetFullPath(Path.Combine(flocation, @"..\..\"));

            //go inside page level
            string final = Path.Combine(newpath, @"Page10");

            //find exact folder in which to update
            string ultimateFinal = Path.Combine(final, @"Member.xml");
            xd.Save(ultimateFinal);
            //return information of what was put into xml
            string songInformation = string.Format("Artist: {0}    Song: {1}    Album: {2}    Genre: {3}    Year released: {4}    Duration: {5} ",artist_name, song_name , album, genre, year_released, duration);
            return songInformation;
        }


        }
    }