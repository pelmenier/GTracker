using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GMapWF.DataHelper
{
    public static class DBHelper
    {
        private static string _conStr = "";/* = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;  */
        
        public static IEnumerable<GMarkerGoogle> GetMarkers()
        {
            List<GMarkerGoogle> markers = new List<GMarkerGoogle>();
            using(SqlConnection connection = new SqlConnection(_conStr))
            { 
                connection.Open();

                if(connection.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM GMapMarkers", connection);
                    SqlDataReader sqlReader = cmd.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            GMarkerGoogle newMarker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(sqlReader[1]), Convert.ToDouble(sqlReader[2])), GMarkerGoogleType.blue_dot);
                            newMarker.ToolTipText = sqlReader[3].ToString();
                            markers.Add(newMarker);
                        }
                    }
                }                
            }
            return markers;   
        }

        public static void AddMarker(GMarkerGoogle marker)
        {
            using (SqlConnection connection = new SqlConnection(_conStr))
            {
                connection.Open();
                if(marker != null)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO [GMapMarkers] (Latitude, Longitude, Text) VALUES (@Latitude, @Longitude, @Text)", connection);
                    cmd.Parameters.AddWithValue("Latitude", marker.Position.Lat);
                    cmd.Parameters.AddWithValue("Longitude", marker.Position.Lng);
                    cmd.Parameters.AddWithValue("Text", marker.ToolTipText);
                    cmd.ExecuteNonQuery();                    
                }            
            }           
        }

        public static void UpdateMarker(GMarkerGoogle newData, GMarkerGoogle currentMarker)
        {
            using (SqlConnection connection = new SqlConnection(_conStr))
            {           
                connection.Open();
                if(newData != null)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE GMapMarkers set Latitude=@Latitude, Longitude=@Longitude, Text=@Text WHERE Id=@ID", connection);
                    cmd.Parameters.AddWithValue("Latitude", newData.Position.Lat);
                    cmd.Parameters.AddWithValue("Longitude", newData.Position.Lng);
                    cmd.Parameters.AddWithValue("Text", newData.ToolTipText);
                    cmd.Parameters.AddWithValue("Id", GetMarkerId(currentMarker));
                    cmd.ExecuteNonQuery();                    
                }            
            }
        }

        public static int GetMarkerId(GMarkerGoogle marker)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(_conStr))
            {
                connection.Open();
                if (marker != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM GMapMarkers WHERE Latitude=@Latitude AND Longitude=@Longitude", connection);
                    cmd.Parameters.AddWithValue("Latitude", marker.Position.Lat);
                    cmd.Parameters.AddWithValue("Longitude", marker.Position.Lng);
                    SqlDataReader sqlReader = cmd.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        sqlReader.Read();
                        id = (int)sqlReader[0];
                    }
                }
            }
            return id;
        }

        public static void RemoveMarker(int id)
        {
            using (SqlConnection connection = new SqlConnection(_conStr))
            {
                connection.Open();
                if (id > 0)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM GMapMarkers WHERE Id=@ID", connection);
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.ExecuteNonQuery();                    
                }                
            }            
        }
    }
}
