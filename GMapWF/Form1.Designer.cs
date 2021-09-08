
namespace GMapWF
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.textBoxLat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLng = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDeleteMarker = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDiscr = new System.Windows.Forms.TextBox();
            this.buttonAddOrUpdate = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonShowMarkers = new System.Windows.Forms.Button();
            this.buttonHideMarkers = new System.Windows.Forms.Button();
            this.markerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.markerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gMapControl
            // 
            this.gMapControl.AllowDrop = true;
            this.gMapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMapControl.Bearing = 0F;
            this.gMapControl.CanDragMap = true;
            this.gMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl.GrayScaleMode = false;
            this.gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl.LevelsKeepInMemory = 5;
            this.gMapControl.Location = new System.Drawing.Point(0, 3);
            this.gMapControl.MarkersEnabled = true;
            this.gMapControl.MaxZoom = 2;
            this.gMapControl.MinZoom = 2;
            this.gMapControl.MouseWheelZoomEnabled = true;
            this.gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl.Name = "gMapControl";
            this.gMapControl.NegativeMode = false;
            this.gMapControl.PolygonsEnabled = true;
            this.gMapControl.RetryLoadTile = 0;
            this.gMapControl.RoutesEnabled = true;
            this.gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl.ShowTileGridLines = false;
            this.gMapControl.Size = new System.Drawing.Size(661, 525);
            this.gMapControl.TabIndex = 0;
            this.gMapControl.Zoom = 0D;
            this.gMapControl.OnMapClick += new GMap.NET.WindowsForms.MapClick(this.gMapControl_OnMapClick);
            this.gMapControl.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMapControl_OnMarkerClick);
            this.gMapControl.OnMarkerEnter += new GMap.NET.WindowsForms.MarkerEnter(this.gMapControl_OnMarkerEnter);
            this.gMapControl.OnMarkerLeave += new GMap.NET.WindowsForms.MarkerLeave(this.gMapControl_OnMarkerLeave);
            this.gMapControl.Load += new System.EventHandler(this.gMapControl1_Load);
            this.gMapControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gMapControl_MouseDown);
            this.gMapControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gMapControl_MouseUp);
            // 
            // textBoxLat
            // 
            this.textBoxLat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLat.Enabled = false;
            this.textBoxLat.Location = new System.Drawing.Point(4, 35);
            this.textBoxLat.Name = "textBoxLat";
            this.textBoxLat.Size = new System.Drawing.Size(175, 13);
            this.textBoxLat.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lat";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lng";
            // 
            // textBoxLng
            // 
            this.textBoxLng.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLng.Enabled = false;
            this.textBoxLng.Location = new System.Drawing.Point(4, 75);
            this.textBoxLng.Name = "textBoxLng";
            this.textBoxLng.Size = new System.Drawing.Size(175, 13);
            this.textBoxLng.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.buttonDeleteMarker);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxDiscr);
            this.groupBox1.Controls.Add(this.buttonAddOrUpdate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxLng);
            this.groupBox1.Controls.Add(this.textBoxLat);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 176);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Marker Info";
            // 
            // buttonDeleteMarker
            // 
            this.buttonDeleteMarker.Enabled = false;
            this.buttonDeleteMarker.Location = new System.Drawing.Point(102, 134);
            this.buttonDeleteMarker.Name = "buttonDeleteMarker";
            this.buttonDeleteMarker.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteMarker.TabIndex = 8;
            this.buttonDeleteMarker.Text = "Remove";
            this.buttonDeleteMarker.UseVisualStyleBackColor = true;
            this.buttonDeleteMarker.Click += new System.EventHandler(this.buttonDeleteMarker_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Discription";
            // 
            // textBoxDiscr
            // 
            this.textBoxDiscr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDiscr.Enabled = false;
            this.textBoxDiscr.Location = new System.Drawing.Point(4, 115);
            this.textBoxDiscr.Name = "textBoxDiscr";
            this.textBoxDiscr.Size = new System.Drawing.Size(175, 13);
            this.textBoxDiscr.TabIndex = 6;
            // 
            // buttonAddOrUpdate
            // 
            this.buttonAddOrUpdate.Enabled = false;
            this.buttonAddOrUpdate.Location = new System.Drawing.Point(7, 134);
            this.buttonAddOrUpdate.Name = "buttonAddOrUpdate";
            this.buttonAddOrUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonAddOrUpdate.TabIndex = 5;
            this.buttonAddOrUpdate.Text = "Add";
            this.buttonAddOrUpdate.UseVisualStyleBackColor = true;
            this.buttonAddOrUpdate.Click += new System.EventHandler(this.buttonAddOrUpdate_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(1, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gMapControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonShowMarkers);
            this.splitContainer1.Panel2.Controls.Add(this.buttonHideMarkers);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(861, 533);
            this.splitContainer1.SplitterDistance = 666;
            this.splitContainer1.TabIndex = 6;
            // 
            // buttonShowMarkers
            // 
            this.buttonShowMarkers.Location = new System.Drawing.Point(50, 185);
            this.buttonShowMarkers.Name = "buttonShowMarkers";
            this.buttonShowMarkers.Size = new System.Drawing.Size(84, 23);
            this.buttonShowMarkers.TabIndex = 7;
            this.buttonShowMarkers.Text = "show markers";
            this.buttonShowMarkers.UseVisualStyleBackColor = true;
            this.buttonShowMarkers.Click += new System.EventHandler(this.buttonShowMarkers_Click);
            // 
            // buttonHideMarkers
            // 
            this.buttonHideMarkers.Location = new System.Drawing.Point(50, 214);
            this.buttonHideMarkers.Name = "buttonHideMarkers";
            this.buttonHideMarkers.Size = new System.Drawing.Size(84, 23);
            this.buttonHideMarkers.TabIndex = 6;
            this.buttonHideMarkers.Text = "hide markers";
            this.buttonHideMarkers.UseVisualStyleBackColor = true;
            this.buttonHideMarkers.Click += new System.EventHandler(this.buttonHideMarkers_Click);
            // 
            // markerBindingSource
            // 
            this.markerBindingSource.DataSource = typeof(GMapWF.Models.Marker);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(866, 534);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "Form1";
            this.Text = "GTracker";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.markerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private System.Windows.Forms.TextBox textBoxLat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLng;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonAddOrUpdate;
        private System.Windows.Forms.Button buttonHideMarkers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDiscr;
        private System.Windows.Forms.BindingSource markerBindingSource;
        private System.Windows.Forms.Button buttonDeleteMarker;
        private System.Windows.Forms.Button buttonShowMarkers;
    }
}

