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
    public partial class frmEliminarDepartamento : Form
    {
        // Definimos la conexión de manera global
        SqlConnection conn = new SqlConnection(@"server = (local)\sqlexpress;
                            integrated security = true; database = AdventureWorks2014");


        public frmEliminarDepartamento()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cierra el formulario actual y regresa al menu principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se encarga de cargar los datos de los departamentos para ser llenados en 
        /// el datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmEliminarDepartamento_Load(object sender, EventArgs e)
        {

            
            // Cremos el query de seleccion.
            string sql = "SELECT DepartmentID,Name FROM HumanResources.Department";

            // creamos el comando
            SqlCommand com = new SqlCommand(sql, conn);

            try
            {
                // establecemos conexion
                conn.Open();

                // Ejecutamos el query via un DataReader y llenamos el listbox
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lstDepartamentos.Items.Add(rdr[0]);
                    lstDepartamentos.Items.Add( "         "+rdr[1]);
                }


            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace + "Detalles de la exepcion");
            }
            finally
            {
                conn.Close();
            }
            
        }

        /// <summary>
        /// Se encarga de ejecutar un procedimiento almacenado que elimina un departamento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificamos que el usuario haya seleccionado un valor
            if (lstDepartamentos.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un registro para eliminarlo", "Error en ingreso", MessageBoxButtons.OK);
            }
            else
            {
                // Creamos el comando
                SqlCommand cmd = new SqlCommand("sp_EliminarDepartamento", conn);

                // definimos el tipo de comando
                cmd.CommandType = CommandType.StoredProcedure;

                

                try
                {
                    // Definimos los parámetros que el procedimiento necesita.
                    cmd.Parameters.Add(new SqlParameter("@Codigo", SqlDbType.SmallInt, 50));
                    cmd.Parameters["@Codigo"].Value =lstDepartamentos.SelectedItems[0];

                    // Abrimos la conexión
                    conn.Open();
                    // verificamos si se ha seleccionado alguna fila;
                    if (lstDepartamentos.SelectedIndex == -1)
                    {
                        MessageBox.Show("Por favor debe seleccionar un departamento", "Error en ingreso", MessageBoxButtons.OK);
                    }
                    else
                    {

                        // ejecutamos el comando
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Departamento eliminado correctamente", "Control de departamentos", MessageBoxButtons.OK);
                        lstDepartamentos.SelectedIndex = -1;
                        
                        
                    }
                }
                catch (SqlException ex)
                {

                    MessageBox.Show(ex.Message + ex.StackTrace + "Detalles de la exepecion");

                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
