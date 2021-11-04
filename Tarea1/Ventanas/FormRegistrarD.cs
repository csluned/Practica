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
        // Punto 1
        // private Universidades[] arraySede;
        private List<Sedes> listaSedes;
        private Profesores docente = new Profesores();
        private int contador = 0;

        private string cedula;


        public FormRegistrarD()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Cargar Datos;
        private void CargarDatos(object sender, EventArgs e)
        {
            //cargar los datos de la tabla

            cargarTabla();

            // carga los datos de la lista desplegable
             List<Sedes> arraySede = LogicaSedes.getSedes();
            arraySede.Insert(0, new Sedes { IdSede = 0, Descripcion = "Seleccionar" });

            cbxListaSede.DataSource = arraySede;
            cbxListaSede.DisplayMember = "Descripcion";
            cbxListaSede.ValueMember = "IdSede";
            cbxListaSede.Refresh();
            cbxListaSede.SelectedIndex = 0;




        }

        private void agregarSedes(object sender, EventArgs e)
        {

            if (cbxListaSede.SelectedIndex != 0)
            {
                // falta validar que docente no aparezca en 2 misma sede

               listaSedes = new List<Sedes>();

                // Punto 2
                Sedes sede = new Sedes();



                //Punto 3
                sede.IdSede = Convert.ToInt32(cbxListaSede.SelectedValue.ToString());
                sede.Descripcion = ((Sedes)cbxListaSede.SelectedItem).Descripcion;

                

                //Punto 4
                listaSedes.Add(sede);


                listBoxSede.Items.Add(((Sedes)cbxListaSede.SelectedItem).Descripcion);

              

                contador++;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Sede", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void AddDocentes(object sender, EventArgs e)
        {
            try
            {

                if (listaSedes.Count(x => x != null) == 0)
                {

                    MessageBox.Show("Debe Agregar una Sede", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    // Punto 5
                    docente.Cedula = textCarnet.Text;
                    docente.Nombre = textNombre.Text;
                    docente.Password = textPass.Text;
                    docente.PrimerAp = textApellidos.Text;
                    docente.Sueldo = Convert.ToDouble(textSalario.Text);
                    docente.Usuario = textUsuario.Text;

                    // Punto 6
                    int resultado = LogicaDocentes.GuardarDocente(docente,listaSedes);
                  
                    if (resultado == 0)
                    {
                        MessageBox.Show("Profesor se agrego correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarFormulario();
                        cargarTabla();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }




        }

        private void limpiarFormulario()
        {

            // Se incializa el objeto docente
            docente = new Profesores();
            listaSedes = new List<Sedes>();
            cbxListaSede.SelectedIndex = 0;
            textCarnet.Text = string.Empty;
            textNombre.Text = string.Empty;
            textPass.Text = string.Empty;
            textApellidos.Text = string.Empty;
            textSalario.Text = string.Empty;
            textUsuario.Text = string.Empty;
            listBoxSede.Items.Clear();

        }

        private void cargarTabla()
        {

            List<ConsultaDocentes> tempProfesores = LogicaDocentes.GetProfesores();

            TablaDocente.Rows.Clear();
            TablaDocente.Refresh();

            if (tempProfesores.Count != 0) {

                foreach (ConsultaDocentes item in tempProfesores) {

                    TablaDocente.Rows.Add(item.Cedula,
                        item.Nombre, item.PrimerAp,
                        item.Sueldo, item.Descripcion);

                }
            
            }


            /*
            if (tempProfesores.Count(x => x != null) != 0)
            {

                for (int i = 0; i < tempProfesores.Count(x => x != null); i++)
                {


                    foreach (ConsultaDocentes item in tempProfesores) {

                        TablaDocente.Rows.Add(item.Cedula,
                        item.Nombre,item.PrimerAp,
                        item.Sueldo, item.Descripcion);


                    }


                   

                }

            }*/


        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            Dialogo dialogo = new Dialogo(cedula);
            dialogo.ShowDialog();




        }

        private void TablaDocente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cedula = TablaDocente.Rows[e.RowIndex].Cells[0].Value.ToString();
           

        }

        private void btnResfrecar_Click(object sender, EventArgs e)
        {
            cargarTabla();
        }
    }
}
