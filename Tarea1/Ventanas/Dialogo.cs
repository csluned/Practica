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
    public partial class Dialogo : Form
    {
        private string cedula;

        public Dialogo( string cedula)
        {
            InitializeComponent();
            this.cedula = cedula;
            cargarDatos();
        }

        
        private void cargarDatos() {

            if (String.IsNullOrEmpty(cedula))
            {

                MessageBox.Show("No selecciono una cedula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else {

                Personas persona = LogicaDocentes.getPersona(cedula);
                textNombre.Text = persona.Nombre;
                textApellidos.Text = persona.PrimerAp;
            
            }




        
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            Personas persona = new Personas();
            persona.Nombre = textNombre.Text;
            persona.PrimerAp = textApellidos.Text;
            persona.Cedula = cedula;



            int opcion = LogicaDocentes.ActualizarPersona(persona);

            switch (opcion)
            {

                case 0:
                    CuadraDialogo("La sede se ha registrado", "Registro", MessageBoxIcon.Information);
                    break;
                case 1:
                    CuadraDialogo("Campo nombre en blanco", "Validacion", MessageBoxIcon.Warning);
                    break;
                case 2:
                    CuadraDialogo("Campo apellido en blanco", "Validacion", MessageBoxIcon.Warning);
                    break;
                case 3:
                    CuadraDialogo("No se registro los datos a la base de datos", "Base Datos", MessageBoxIcon.Information);
                    break;

            }












        }

        private void CuadraDialogo(string mensaje, string titulo, MessageBoxIcon icono)
        {

            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);

        }


    }
}
