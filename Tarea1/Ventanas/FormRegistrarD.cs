using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea1.Ventanas
{
    public partial class FormRegistrarD : Form
    {
        public FormRegistrarD()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormRegistrarD_Load(object sender, EventArgs e)
        {
            CargarSedes();


        }


        private void CargarSedes() {

            Universidades[] arraySede = LogicaSedes.getSedes();

            cbxSedes.DisplayMember = "Texto";
            cbxSedes.ValueMember = "Id";

            cbxSedes.Items.Add(new { Texto = "Seleccionar", Value = 0 });

            for (int i = 0; i < arraySede.Count(x => x != null); i++) {

                cbxSedes.Items.Add(new { Texto = arraySede[i].Descripcion, Value = arraySede[i].IdSede });
            }

            cbxSedes.Refresh();
            cbxSedes.SelectedIndex = 0;
              
        }
    }
}
