using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMapWF.DataHelper;
using System;
using System.Windows.Forms;

namespace GMapWF.Services
{
    public static class MarkerService
    {
        public static void GetMarkers(GMapOverlay overlay)
        {
            try
            {
                foreach(var item in DBHelper.GetMarkers())
                {
                    overlay.Markers.Add(item);
                }     
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        public static void AddMarker(GMarkerGoogle marker)
        {
            try
            {
                DBHelper.AddMarker(marker);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        public static int GetMarkerId(GMarkerGoogle marker)
        {
            try
            {
                return DBHelper.GetMarkerId(marker);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return -1;
            }
            
        }

        public static bool RemoveMarker(GMarkerGoogle marker)
        {
            try
            {
                var id = GetMarkerId(marker);
                if (id > 0)
                {
                    DBHelper.RemoveMarker(id);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public static void UpdateMarker(GMarkerGoogle newData, GMarkerGoogle currentMarker)
        {
            try
            {
                DBHelper.UpdateMarker(newData, currentMarker);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
    }
}
