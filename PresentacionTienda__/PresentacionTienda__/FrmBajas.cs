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
    public partial class FrmBajas : Form
    {
        ManejadorBajas mp;
        int fila = 0, columna = 0;
        public static int IdProducto = 0;

        public FrmBajas()
        {
            InitializeComponent();
            mp = new ManejadorBajas();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dtgvDatos.Visible = true;
            mp.Mostrar(dtgvDatos, txtBuscar.Text);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
            IdProducto = 0;
        }
        private void dtgvDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;
            if (dtgvDatos.Columns[columna] is DataGridViewButtonColumn)
            {
                IdProducto = int.Parse(dtgvDatos.Rows[fila].Cells[0].Value.ToString());
                mp.Borrar(IdProducto, dtgvDatos.Rows[fila].Cells[2].Value.ToString());
                Limpiar();
                txtBuscar.Focus();
            }

        }

        void Limpiar()
        {
            dtgvDatos.Visible = false;
        }

    }
}
