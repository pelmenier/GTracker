using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using GMapWF.DataHelper;
using GMapWF.Services;

namespace GMapWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        GMapOverlay currentOverlay = new GMapOverlay("markers");        
        GMarkerGoogle lastMarker ;
        GMarkerGoogle currentMarker ;        
        
        // вошли\вышли из тригера маркера
        bool isMarkerEnter = false;
        bool isMouseDown = false;        

        double lat = 0.0;
        double lng = 0.0;

        #region "GMap Control"
        private void gMapControl1_Load(object sender, EventArgs e)
        {
            // Настройки для компонента GMap
            gMapControl.Bearing = 0;
            // Перетаскивание левой кнопки мыши
            gMapControl.CanDragMap = true;
            // Перетаскивание карты левой кнопкой мыши
            gMapControl.DragButton = MouseButtons.Left;

            gMapControl.GrayScaleMode = true;

            // Все маркеры будут показаны
            gMapControl.MarkersEnabled = true;
            // Максимальное приближение
            gMapControl.MaxZoom = 18;
            // Минимальное приближение
            gMapControl.MinZoom = 2;
            // Курсор мыши в центр карты
            gMapControl.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;

            // Отключение нигативного режима
            gMapControl.NegativeMode = false;
            // Разрешение полигонов
            gMapControl.PolygonsEnabled = true;
            // Разрешение маршрутов
            gMapControl.RoutesEnabled = true;
            // Скрытие внешней сетки карты
            gMapControl.ShowTileGridLines = false;
            // При загрузке 10-кратное увеличение
            gMapControl.Zoom = 10;
            // Убрать красный крестик по центру
            gMapControl.ShowCenter = false;

            // Чья карта используется
            gMapControl.MapProvider = GMapProviders.GoogleMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapControl.Position = new PointLatLng(55,82.9);

            GMapOverlay markersOverley = new GMapOverlay("markers");

            //marker.ToolTip = new GMapRoundedToolTip(marker);               


            gMapControl.MouseMove += new MouseEventHandler(MapControlMouseMove);
            //gMapControl.OnMarkerEnter += new MarkerEnter(gMapControl_OnMarkerEnter);
            //gMapControl.OnMarkerLeave += new MarkerLeave(gMapControl_OnMarkerLeave);           

            ShowMarkers();
        }

        private void MapControlMouseMove(object sender, MouseEventArgs e)
        {
            if (isMarkerEnter && isMouseDown)
            {
                buttonAddOrUpdate.Enabled = false;
                if (currentMarker != null)                                    
                    NewPositionMarker(e);        
            }      
                           
                           
        }

        private void gMapControl_OnMarkerEnter(GMapMarker item)
        {
            if(currentMarker != item && currentMarker != null) { }
            else
            {                              
                isMarkerEnter = true;
                currentMarker = (GMarkerGoogle)item;             
            }
        }

        private void gMapControl_OnMarkerLeave(GMapMarker item)
        {
            if (currentMarker != item) { }
            else
            {
                currentMarker = null;
                isMarkerEnter = false;                
            }            
        }

        private void gMapControl_MouseUp(object sender, MouseEventArgs e)        {  
            isMouseDown = false;
            if(e.Button == MouseButtons.Left && currentMarker != null && lastMarker != null && isMarkerEnter) 
            {                
                MarkerService.UpdateMarker(currentMarker, new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.arrow));                
                currentMarker = null;
                SwitchAddOrUpdate();               
            }            
            MarkerInfoEnable();          
        }

        private void gMapControl_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {                
                FillMarkerInfo(item);
                buttonAddOrUpdate.Text = "Update";
                buttonAddOrUpdate.Enabled = true;
                lat = item.Position.Lat;
                lng = item.Position.Lng;
                buttonDeleteMarker.Enabled = true;
            }            
        }

        private void gMapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {                
                lastMarker = (GMarkerGoogle)gMapControl.Overlays.SelectMany(o => o.Markers).FirstOrDefault(m => m.IsMouseOver == true);                            
                if(lastMarker!=null)
                {                    
                    lat = lastMarker.Position.Lat;
                    lng = lastMarker.Position.Lng;
                }                
                isMouseDown = true;                 
                MarkerInfoDisable();
            }              
        }

        private void gMapControl_OnMapClick(PointLatLng pointClick, MouseEventArgs e)
        {
            if (buttonAddOrUpdate.Text == "Add")
                buttonAddOrUpdate.Enabled = true;
            textBoxLat.Text = pointClick.Lat.ToString();
            textBoxLng.Text = pointClick.Lng.ToString();
            textBoxDiscr.Text = "";
            if (e.Button == MouseButtons.Left)
                SwitchAddOrUpdate();
        }
        #endregion

        #region "Buttons Click"
        private void buttonAddOrUpdate_Click(object sender, EventArgs e)
        {
            if(buttonAddOrUpdate.Text == "Add")
            {
                var marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(textBoxLat.Text), Convert.ToDouble(textBoxLng.Text)), GMarkerGoogleType.blue_dot);
                marker.ToolTipText = textBoxDiscr.Text;
                if (MarkerService.GetMarkerId(marker) == 0)
                    MarkerService.AddMarker(marker);
                else
                    MessageBox.Show("Маркек с такими координатами уже существует");
            }
            else if(buttonAddOrUpdate.Text == "Update")
            {                
                MarkerService.UpdateMarker(FillData(new GMarkerGoogle(new PointLatLng(0,0),GMarkerGoogleType.arrow)), new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.arrow));                
            } 
            ShowMarkers();
        }

        private void buttonHideMarkers_Click(object sender, EventArgs e)
        {
            currentOverlay.Clear();
        }        

        private void buttonShowMarkers_Click(object sender, EventArgs e)
        {
            ShowMarkers();
        }        

        private void buttonDeleteMarker_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Remove marker?", "Remove", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool itsOk = MarkerService.RemoveMarker(new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.arrow));
                if (!itsOk)
                    MessageBox.Show("Маркера с такими данными не найдено!");

                buttonDeleteMarker.Enabled = false;
            }
            ShowMarkers();
        }
        #endregion

        #region "created method"
        private void FillMarkerInfo(GMapMarker marker)
        {
            textBoxLat.Text = marker.Position.Lat.ToString();
            textBoxLng.Text = marker.Position.Lng.ToString();
            textBoxDiscr.Text = marker.ToolTipText;
        }

        private void NewPositionMarker(MouseEventArgs e)
        {
            PointLatLng point = gMapControl.FromLocalToLatLng(e.X, e.Y);
            currentMarker.Position = point;
            FillMarkerInfo(currentMarker);
        }

        private void ShowMarkers()
        {
            currentOverlay.Clear();
            MarkerService.GetMarkers(currentOverlay);            
            gMapControl.Overlays.Add(currentOverlay);
        }

        private void MarkerInfoEnable()
        {
            textBoxDiscr.Enabled = true;
            textBoxLat.Enabled = true;
            textBoxLng.Enabled = true;
        }

        private void MarkerInfoDisable()
        {
            textBoxDiscr.Enabled = false;
            textBoxLat.Enabled = false;
            textBoxLng.Enabled = false;
        }

        private GMarkerGoogle FillData(GMarkerGoogle marker)
        {
            marker.Position = new PointLatLng(Convert.ToDouble(textBoxLat.Text), Convert.ToDouble(textBoxLng.Text));
            marker.ToolTipText = textBoxDiscr.Text;
            return marker;
        }

        private void SwitchAddOrUpdate()
        {
            buttonAddOrUpdate.Text = "Add";
        }
        #endregion
    }
}
