using System;
using Negocio;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Tarea1.Ventanas
{
    public partial class FormSede : Form
    {
        public FormSede()
        {
            InitializeComponent();
        }
       



        private void CuadraDialogo(string mensaje, string titulo, MessageBoxIcon icono)
        {

            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            Console.WriteLine("Si entra");
            try
            {

                Console.WriteLine("Si entra");

                Universidades sede = new Universidades();
                sede.IdSede = Convert.ToInt32(textCodigo.Text);
                sede.Descripcion = textDesp.Text;


                int opcion = LogicaSedes.GuardarSede(sede);

                switch (opcion)
                {

                    case 0:
                        CuadraDialogo("La sede se ha registrado", "Registro", MessageBoxIcon.Information);
                        break;
                    case 1:
                        CuadraDialogo("Campo descripcion en blanco", "Validacion", MessageBoxIcon.Warning);
                        break;
                    case 2:
                        CuadraDialogo("El codigo " + sede.IdSede + " existe", "Validacion", MessageBoxIcon.Warning);
                        break;

                }


            }
            catch (Exception ex)
            {

                CuadraDialogo(ex.Message, "Error", MessageBoxIcon.Error);
            }
        }
    }


   
}
