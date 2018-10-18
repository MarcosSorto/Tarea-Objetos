using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmPrincipal
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cierra el formulario principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Crea una instancia del formulario listar y lo
        /// muestra en la pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListar_Click(object sender, EventArgs e)
        {
            frmListar listar = new frmListar();
            listar.ShowDialog();
        }

        /// <summary>
        /// Crea una instancia del formulario crear departamentos y lo
        /// muestra en la pantalla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmCrearDepartamento crear = new frmCrearDepartamento();
            crear.ShowDialog();
        }

        /// <summary>
        /// Crea una instancia del formulario actualizar departamento
        /// y lo muestra en la pantalla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            frmActualizarDepartamentos actualizar = new frmActualizarDepartamentos();
            actualizar.ShowDialog();
        }

        /// <summary>
        /// Crea una instancia del formulario eliminar departamento y
        /// lo mestra en pantalla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmEliminarDepartamento Eliminar = new frmEliminarDepartamento();
            Eliminar.ShowDialog();
        }
    }
}
