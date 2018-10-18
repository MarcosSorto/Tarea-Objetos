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
    public partial class frmCrearDepartamento : Form
    {
        public frmCrearDepartamento()
        {
            InitializeComponent();
        }

        private void lblGrupo_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Cierra el formulario de agregar departamentos y
        /// regresa al menu principal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Captura los datos de los textbox y ejecuta un procedimiento almacenado para
        /// guardar los datos en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificamos que los valores de los textbox no esten vacios.
            if (txtNombre.Text == "" || txtGrupo.Text == "")
            {
                MessageBox.Show("Hay valores sin ingresar, revise", "Error en ingreso", MessageBoxButtons.OK);

            }
            else
            {
                // Creamos la conexion
                SqlConnection conn = new SqlConnection(@"server = (local)\sqlexpress;
                                   integrated security = true; database = AdventureWorks2014");

                // Creamos el comando
                SqlCommand cmd = new SqlCommand("sp_RegistrarDepartamento", conn);

                // Especificamos el tipo de comando
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    // definimos los parámetros necesarios para el storeProcedure.
                    cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar, 50));
                    cmd.Parameters["@Nombre"].Value = txtNombre.Text;
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar, 50));
                    cmd.Parameters["@Descripcion"].Value = txtGrupo.Text;
                    cmd.Parameters.Add(new SqlParameter("@FechaM", SqlDbType.DateTime, 50));
                    cmd.Parameters["@FechaM"].Value = dtpFechaModificacion.Value;

                    // Abrimos la conexión
                    conn.Open();

                    // Ejecutamos el comando
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Departamento registrado correctamente", "Control de departamentos", MessageBoxButtons.OK);

                    // limpiamos las cajas de texto 
                    txtNombre.Text = "";
                    txtGrupo.Text = "";
                    txtNombre.Focus();
             



                }
                catch (SqlException ex)
                {

                    MessageBox.Show(ex.Message + ex.StackTrace + "Detalles de la exepción");
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
