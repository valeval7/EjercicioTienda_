using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;

namespace Manejador
{
    public class ManejadorBajas
    {
        Base b = new Base("localhost", "root", "", "Tienda");
        public void Mostrar(DataGridView Tabla, string filtro)//Filtro para saber como va a ser la búsqueda
        {
            Tabla.Columns.Clear();
            DataTable datos = b.Consultar($"select * from datos where Nombre like '%{filtro}%'", "datos").Tables[0];
            Tabla.DataSource = datos;
            Tabla.Columns.Insert(Math.Min(6, datos.Columns.Count), Boton("Eliminar", Color.Red));
            Tabla.AutoResizeColumns();
            Tabla.AutoResizeRows();
        }

        DataGridViewButtonColumn Boton(string t, Color f)
        {
            DataGridViewButtonColumn x = new DataGridViewButtonColumn();
            x.Text = t;
            x.UseColumnTextForButtonValue = true;
            x.FlatStyle = FlatStyle.Popup;
            x.DefaultCellStyle.ForeColor = Color.White;
            x.DefaultCellStyle.BackColor = f;
            return x;
        }
        public void Borrar(int id, string Dato)
        {
            DialogResult rs = MessageBox.Show($"Está seguro de borrar {Dato}", "!Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                b.Comando($"call p_Eliminar({id})");
                MessageBox.Show("Registro Eliminado", "!Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
