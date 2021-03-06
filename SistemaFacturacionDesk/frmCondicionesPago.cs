﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFacturacionDesk
{
    public partial class frmCondicionesPago : Form
    {
        public frmCondicionesPago()
        {
            InitializeComponent();
        }

        private void frmCondicionesPago_Load(object sender, EventArgs e)
        {
            ValidarInsertcionDatos();
            estadoComboBox.DataSource = Utilidades.Estados;
            // TODO: This line of code loads data into the 'fACTURACIONDataSet.CONDICIONESPAGO' table. You can move, or remove it, as needed.
            this.cONDICIONESPAGOTableAdapter.Fill(this.fACTURACIONDataSet.CONDICIONESPAGO);
        }

        private void ValidarInsertcionDatos()
        {
            descripcionTextBox.ValidarContenido(TipoDatos.Alfanumerico);
            cantidadDiasTextBox.ValidarContenido(TipoDatos.Numerico);
        }

        private void cONDICIONESPAGOBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            string mensaje = Utilidades.ObtenerMensajeInsertarModificar(this.cONDICIONESPAGOBindingSource.Current);

            if (ValidarDatosCampos() && this.Validate())
            {
                this.cONDICIONESPAGOBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.fACTURACIONDataSet);
               
                if (!string.IsNullOrEmpty(mensaje))
                {
                    this.MensajeInformacion(mensaje);
                }

            }

        }

        private void fillByDescripcion(object sender, EventArgs e)
        {
            try
            {
                this.cONDICIONESPAGOTableAdapter.FillByDescripcion(this.fACTURACIONDataSet.CONDICIONESPAGO, txtDescripcion.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtDescripcion.Clear();
            fillByDescripcion(sender, e);
        }


        private bool ValidarDatosCampos()
        {
            bool resultado = true;
            string NombreCampo = "";
            if (string.IsNullOrEmpty(descripcionTextBox.Text))
            {
                resultado = false;
                NombreCampo = "Descripción";
                descripcionTextBox.Focus();
            }
            else if (string.IsNullOrEmpty(cantidadDiasTextBox.Text))
            {
                resultado = false;
                NombreCampo = "Cantidad de Días";
                cantidadDiasTextBox.Focus();
            }
            else if (estadoComboBox.SelectedIndex == -1)
            {
                resultado = false;
                NombreCampo = "Estado";
                estadoComboBox.Focus();
            }

            if (!resultado) this.MensajeAdvertencia("El campo " + NombreCampo + " no puede estar en blanco.", "Datos en Blanco");

            return resultado;
        }

        private void frmCondicionesPago_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMenu frmMenu = new frmMenu();
            frmMenu.Visible = true;
            this.Dispose();
        }


    }
}
