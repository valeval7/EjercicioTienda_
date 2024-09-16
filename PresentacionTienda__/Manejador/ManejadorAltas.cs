using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;
using Entidades;

namespace Manejador
{
    public class ManejadorAltas
    {
        Base b = new Base("localhost", "root", "", "Tienda");
        List<Datos> dato = new List<Datos>();

        public string Guardar(TextBox Nombre, TextBox Descripcion, TextBox Precio)
        {
            try
            {
                return b.Comando($"CALL p_Agregar(null, '{Nombre.Text}','{Descripcion.Text}', {double.Parse(Precio.Text)})");

            }
            catch (Exception)
            {
                return "Error de valor";
            }
        }


    }
}
