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
    public partial class frmListar : Form
    {
        public frmListar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cierra el formulario actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se encarga de cargar los datos y mostrarlos el datagridview
        /// se ejecuta al hacer click en el boton listar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListar_Click(object sender, EventArgs e)
        {
            // realizamos la conexión con la BD.
            SqlConnection conn = new SqlConnection(@"server = (local)\sqlexpress;
                                integrated security = true; database = AdventureWorks2014;");

            // Creamos el query de seleccion de los datos.

            string sql = @"SELECT * FROM HumanResources.Department";

            try
            {
                // Creamos el dataAdapter
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sql, conn);

                // Creamos el DataSet
                DataSet ds = new DataSet();

                // cargamos  los valores de la tabla
                da.Fill(ds, "HumanResources.Department");

                // obtenemos los valores de la tabla por referencia.
                DataTable dta = ds.Tables["HumanResources.Department"];

                // Cremos el dataview con los valores de la tabla
                DataView dv = new DataView(dta);

                //DataView dv = new DataView(dt, "MiddleName = 'J.'", "MiddleName", DataViewRowState.Unchanged);

                // LLenamos el dataGridView con los datos de la vista

                dgvDepartamentos.DataSource = dv;


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
    }
}
