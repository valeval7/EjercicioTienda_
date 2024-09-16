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
        public FrmAltas()
        {
            InitializeComponent();
            md = new ManejadorAltas();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string resultado = md.Guardar(txtNombre, txtDescripcion, txtPrecio);
            MessageBox.Show(resultado);
        }

        private void txtPrecio_Enter(object sender, EventArgs e)
        {
            txtPrecio.Clear();
        }
    }
    
}
