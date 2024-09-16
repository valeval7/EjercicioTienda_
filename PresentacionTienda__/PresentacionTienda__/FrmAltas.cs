using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejador;
using Entidades;


namespace PresentacionTienda_
{
    public partial class FrmAltas : Form
    {
        ManejadorAltas md;
        ManejadorModificaciones ml;
        public FrmAltas()
        {
            InitializeComponent();
            md = new ManejadorAltas();
            ml = new ManejadorModificaciones();
            if (FrmModificaciones.Id > 0)
            {
                txtNombre.Text = FrmModificaciones.Nombre;
                txtDescripcion.Text = FrmModificaciones.Descripcion;
                txtPrecio.Text = FrmModificaciones.Precio.ToString();
                FrmModificaciones.Id = 0;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (FrmModificaciones.Id > 0)
            {
                ml.Modificar(FrmModificaciones.Id, txtNombre, txtDescripcion, txtPrecio);
                FrmModificaciones.Id = 0;
                txtNombre.Clear();
                txtDescripcion.Clear();
                txtPrecio.Clear();
            }
            else
            {
                string resultado = md.Guardar(txtNombre, txtDescripcion, txtPrecio);
                MessageBox.Show(resultado);
                txtNombre.Clear();
                txtDescripcion.Clear();
                txtPrecio.Clear();
            }
        }

        private void txtPrecio_Enter(object sender, EventArgs e)
        {
            txtPrecio.Clear();
        }
    }
    
}
