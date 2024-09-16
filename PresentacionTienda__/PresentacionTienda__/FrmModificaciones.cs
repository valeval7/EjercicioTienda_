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

namespace PresentacionTienda_
{
    public partial class FrmModificaciones : Form
    {
        ManejadorModificaciones MM;
        int fila = 0, columna = 0;
        public static int Id = 0;
        public static string Nombre = "", Descripcion = "";
        public static double Precio = 0.0;


        public FrmModificaciones()
        {
            InitializeComponent();
            MM = new ManejadorModificaciones();
        }


        private void dtgvDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex; columna = e.ColumnIndex;
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (fila >= 0)
            {
                Id = int.Parse(dtgvDatos.Rows[fila].Cells[0].Value.ToString());
                Nombre = dtgvDatos.Rows[fila].Cells[1].Value.ToString();
                Descripcion = dtgvDatos.Rows[fila].Cells[2].Value.ToString();
                Precio = double.Parse(dtgvDatos.Rows[fila].Cells[3].Value.ToString());
                FrmAltas dm = new FrmAltas();
                dm.ShowDialog();
                Limpiar();
                txtBuscar.Focus();
            }
            else
                MessageBox.Show("Por favor, seleccione una fila válida para modificar.");

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dtgvDatos.Visible = true;
            MM.Mostrar(dtgvDatos, txtBuscar.Text);
        }

       

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }
        void Limpiar()
        {
            dtgvDatos.Visible = false;
        }



    }
}
