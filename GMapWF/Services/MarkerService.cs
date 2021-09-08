using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMapWF.DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMapWF.Services
{
    public static class MarkerService
    {
        public static void GetMarkers(GMapOverlay overlay)
        {                        
            foreach(var item in DBHelper.GetMarkers())
            {
                overlay.Markers.Add(item);
            }     
        }

        public static void AddMarker(GMarkerGoogle marker)
        {            
            DBHelper.AddMarker(marker);
        }

        public static int GetMarkerId(GMarkerGoogle marker)
        {
            return DBHelper.GetMarkerId(marker);
        }

        public static bool RemoveMarker(GMarkerGoogle marker)
        {
            //try
            //{
            var id = GetMarkerId(marker);
            if (id > 0)
            {
                DBHelper.RemoveMarker(id);
                return true;
            }
            return false;    
            //}
            //catch(Exception e)
            //{
            //    return false;
            //}
            
        }

        public static void UpdateMarker(GMarkerGoogle newData, GMarkerGoogle currentMarker)
        {
            DBHelper.UpdateMarker(newData, currentMarker);
        }
    }
}
