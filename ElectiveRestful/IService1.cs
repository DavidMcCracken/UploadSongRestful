using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ElectiveRestful {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1 {
        //string artist_name, string album, string song_name, string genre, string year_released, string duration
        [OperationContract]
        [WebGet(UriTemplate= "songUpload?artist_name={artist_name}&album={album}&song_name={song_name}&genre={genre}&year_released={year_released}&duration={duration}")]
        string songUpload(string artist_name, string album, string song_name, string genre, string year_released, string duration);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
