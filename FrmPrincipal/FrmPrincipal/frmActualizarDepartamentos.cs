using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace FrmPrincipal
{
    public partial class frmActualizarDepartamentos : Form
    {
        public frmActualizarDepartamentos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cierra el formulario y regresa al menu principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Captura los datos ingresados y ejecuta un procedimiento almacenado para actualizar
        /// los datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnactualizar_Click(object sender, EventArgs e)
        {
            // Verificamos que el código haya sido ingresado.
            if (txtcodigo.Text =="")
            {
                MessageBox.Show("Debe ingresar el codigo del departamento", "Error en ingreso", MessageBoxButtons.OK);
                txtcodigo.Focus();
            }
            else
            {
                // Creamos la conexión
                SqlConnection conn = new SqlConnection(@"server = (local)\sqlexpress;
                                    integrated security = true; database = AdventureWorks2014");

                // Creams el comando
                SqlCommand cmd = new SqlCommand("sp_EditarDepartamento", conn);

                // Definimos el tipo de comando
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    // definimos los parámetros del procedimiento almacenado.
                    cmd.Parameters.Add(new SqlParameter("@Codigo", SqlDbType.SmallInt, 50));
                    cmd.Parameters["@Codigo"].Value = txtcodigo.Text;

                    cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar, 50));
                    cmd.Parameters["@Nombre"].Value = txtNombre.Text;

                    cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar, 50));
                    cmd.Parameters["@Descripcion"].Value = txtGrupo.Text;

                    cmd.Parameters.Add(new SqlParameter("@FechaM", SqlDbType.DateTime, 50));
                    cmd.Parameters["@FechaM"].Value = dtpFechaModificacion.Value;

                    // abrimos la conexión
                    conn.Open();

                    //ejecutamos el comando
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Departamento actualizado correctamente", "Control de Departamentos", MessageBoxButtons.OK);

                    // limpiamos los valores ingresados
                    txtcodigo.Text = "";
                    txtNombre.Text = "";
                    txtGrupo.Text = "";
                    txtcodigo.Focus();

                }
                catch (SqlException ex)
                {

                    MessageBox.Show(ex.Message + ex.StackTrace + "Detalles de la exepcion");
                }
                finally
                {
                    //cerramos la conexión
                    conn.Close();
                }

            }
        }
    }
}
