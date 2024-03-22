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

namespace GoogleMaps
{
    public partial class Mapa : Form
    {
        GMarkerGoogle marcador;
        GMapOverlay capaMarcador;
        DataTable direcciones = new DataTable();
        
        int filaSeleccionada = 0;
        double latitudInicial = -27.46056;
        double longitudInicial = -58.98389;
        
        public Mapa()
        {
            InitializeComponent();

            gMapControl1.ShowCenter = false;

            direcciones.Columns.Add("Ciudad", typeof(string));
            direcciones.Columns.Add("Latitud", typeof(double));
            direcciones.Columns.Add("Longitud", typeof(double));

            dataGridViewMap.DataSource = direcciones;

            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(latitudInicial, longitudInicial);
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            direcciones.Rows.Add(txtNombre.Text, txtLat.Text, txtLon.Text);
            txtNombre.Text = "";
            txtLat.Text = "";
            txtLon.Text = "";
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            dataGridViewMap.Rows.RemoveAt(filaSeleccionada);
        }

        private void buttonRuta_Click(object sender, EventArgs e)
        {
            GMapOverlay Ruta = new GMapOverlay("CapaRuta");

            List<PointLatLng> puntos = new List<PointLatLng>();

            double lat, lng;

            for (int filas = 0; filas < dataGridViewMap.Rows.Count; filas++)
            {
                lat = Convert.ToDouble(dataGridViewMap.Rows[filas].Cells[1].Value);
                lng = Convert.ToDouble(dataGridViewMap.Rows[filas].Cells[2].Value);
                puntos.Add(new PointLatLng(lat, lng));
            }

            GMapRoute PuntosRuta = new GMapRoute(puntos, "Ruta");

            GMapOverlay capaExistente = gMapControl1.Overlays.FirstOrDefault(o => o.Id == "CapaRuta");
            if (capaExistente != null)
            {
                gMapControl1.Overlays.Remove(capaExistente);
            }

            Ruta.Routes.Add(PuntosRuta);
            gMapControl1.Overlays.Add(Ruta);

            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;

            double distancia = Math.Round(PuntosRuta.Distance, 2);

            txtDistancia.Text = distancia.ToString();
        }

        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (txtNombre.Text == "" || txtNombre.Text == "Agregue el nombre de la parada...")
            {
                txtNombre.Text = "Agregue el nombre de la parada...";
                label1.Text = "*NOMBRE";
                label1.ForeColor = Color.Red;
            }
            else
            {
                double latitud = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
                double longitud = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;

                txtLat.Text = latitud.ToString();
                txtLon.Text = longitud.ToString();

                marcador = new GMarkerGoogle(new PointLatLng(latitud, longitud), GMarkerGoogleType.blue);
                capaMarcador = new GMapOverlay("Marcador");
                capaMarcador.Markers.Add(marcador);

                gMapControl1.Overlays.Add(capaMarcador);

                marcador.ToolTipText = string.Format($"Parada: {txtNombre.Text}");

                gMapControl1.Zoom = gMapControl1.Zoom + 1;
                gMapControl1.Zoom = gMapControl1.Zoom - 1;
            }
        }

        private void SeleccionarRegistro(object sender, DataGridViewCellMouseEventArgs e)
        {
            filaSeleccionada = e.RowIndex;
        }

        private void gMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "NOMBRE";
            label1.ForeColor = Color.Black;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}