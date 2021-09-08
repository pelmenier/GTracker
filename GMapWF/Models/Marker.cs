using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMapWF.Models
{
    public class Marker
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Text { get; set; }

        public Marker(int id, double lat, double lng, string txt)
        {
            Id = id;
            Latitude = lat;
            Longitude = lng;
            Text = txt;
        }
    }
}
