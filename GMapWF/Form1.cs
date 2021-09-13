using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMapWF.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GMapWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        GMapOverlay _currentOverlay = new GMapOverlay("markers");        
        GMarkerGoogle _lastMarker ;
        GMarkerGoogle _currentMarker ;        
        
        // вошли\вышли из тригера маркера
        bool _isMarkerEnter = false;
        bool _isMouseDown = false;
        bool _exception = false;

        double _lat = 0.0;
        double _lng = 0.0;

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
            try
            {
                ShowMarkers();
            }
            catch(Exception ex)
            {
                AllEnabled(false);
                _exception = true;
            }            
        }

        private void MapControlMouseMove(object sender, MouseEventArgs e)
        {
            if (_isMarkerEnter && _isMouseDown)
            {
                buttonAddOrUpdate.Enabled = false;
                if (_currentMarker != null)                                    
                    NewPositionMarker(e);      
            }                        
        }

        private void gMapControl_OnMarkerEnter(GMapMarker item)
        {
            if(_currentMarker != item && _currentMarker != null) { }
            else
            {                              
                _isMarkerEnter = true;
                _currentMarker = (GMarkerGoogle)item;             
            }
        }

        private void gMapControl_OnMarkerLeave(GMapMarker item)
        {
            if (_currentMarker != item) { }
            else
            {
                _currentMarker = null;
                _isMarkerEnter = false;                
            }            
        }

        private void gMapControl_MouseUp(object sender, MouseEventArgs e)        {  
            _isMouseDown = false;
            if(e.Button == MouseButtons.Left && _currentMarker != null && _lastMarker != null && _isMarkerEnter) 
            {                
                MarkerService.UpdateMarker(_currentMarker, new GMarkerGoogle(new PointLatLng(_lat, _lng), GMarkerGoogleType.arrow));                                    
                _currentMarker = null;
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
                _lat = item.Position.Lat;
                _lng = item.Position.Lng;
                buttonDeleteMarker.Enabled = true;
            }            
        }

        private void gMapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {                
                _lastMarker = (GMarkerGoogle)gMapControl.Overlays.SelectMany(o => o.Markers).FirstOrDefault(m => m.IsMouseOver == true);                            
                if(_lastMarker!=null)
                {                    
                    _lat = _lastMarker.Position.Lat;
                    _lng = _lastMarker.Position.Lng;
                }                
                _isMouseDown = true;                 
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
                MarkerService.UpdateMarker(FillData(new GMarkerGoogle(new PointLatLng(0,0),GMarkerGoogleType.arrow)), new GMarkerGoogle(new PointLatLng(_lat, _lng), GMarkerGoogleType.arrow));                
            } 
            ShowMarkers();               
        }

        private void buttonHideMarkers_Click(object sender, EventArgs e)
        {
            _currentOverlay.Clear();
        }        

        private void buttonShowMarkers_Click(object sender, EventArgs e)
        {
            ShowMarkers();    
        }        

        private void buttonDeleteMarker_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Remove marker?", "Remove", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool itsOk = MarkerService.RemoveMarker(new GMarkerGoogle(new PointLatLng(_lat, _lng), GMarkerGoogleType.arrow));
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
            _currentMarker.Position = point;
            FillMarkerInfo(_currentMarker);
        }

        private void ShowMarkers()
        {
            _currentOverlay.Clear();            
            MarkerService.GetMarkers(_currentOverlay);                  
            gMapControl.Overlays.Add(_currentOverlay);
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

        private void AllEnabled(bool flag)
        {
            textBoxDiscr.Enabled = flag;
            textBoxLat.Enabled = flag;
            textBoxLng.Enabled = flag;
            buttonAddOrUpdate.Enabled = flag;
            buttonDeleteMarker.Enabled = flag;
            buttonHideMarkers.Enabled = flag;
            buttonShowMarkers.Enabled = flag;
        }
        #endregion
    }
}
