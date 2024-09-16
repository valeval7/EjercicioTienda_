using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;

namespace Manejador
{
    public class ManejadorModificaciones
    {
        Base b = new Base("localhost", "root", "", "Tienda");

        public void Modificar(int Id, TextBox Nombre, TextBox Descripcion, TextBox Precio)
        {
            b.Comando($"CALL p_Modificar({Id}, '{Nombre.Text}', '{Descripcion.Text}', {double.Parse(Precio.Text)});");
            MessageBox.Show("Registro Modificado", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Mostrar(DataGridView Tabla, string filtro)
        {
            Tabla.Columns.Clear();
            DataTable datos = b.Consultar($"select * from datos where Nombre like '%{filtro}%'", "datos").Tables[0];
            Tabla.DataSource = datos;
            Tabla.AutoResizeColumns();
            Tabla.AutoResizeRows();
        }
    }
}
