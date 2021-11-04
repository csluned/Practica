using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AccesoDatos
{
    public class ConexionDatos
    {
        // Ir al archivo de configuracion Settings.settings se encuentra el string connection.

        // private string strconexion = Properties.Settings.Default.CadenaBD.ToString();


        // conection string en el archivo app.config  
        private string strconexion = ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;

        private SqlConnection objconexion;

        public ConexionDatos()
        {
            try
            {

                objconexion = new SqlConnection(strconexion);
                this.Abrir();


            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {

                this.Cerrar();

            }




        }







        // abrirla 
        private void Abrir()
        {

            if (objconexion.State == System.Data.ConnectionState.Closed)
            {

                objconexion.Open();

            }

        }


        // cerrar

        private void Cerrar()
        {

            if (objconexion.State == System.Data.ConnectionState.Open)
            {

                objconexion.Close();
            }



        }


        // Me permite un solo metodo de eliminar, insertar y actualizar

        public bool Ejecutar_Sentencia(string sentencia)
        {
            try
            {

                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = objconexion;
                comando.CommandText = sentencia;

                this.Abrir();

                return (comando.ExecuteNonQuery() > 0);


            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {

                this.Cerrar();
            }


        }


        // Cuando son consulta se realizan metodos aparte

        public bool SiExisteSede(string sentecia)
        {

            DataTable dt = new DataTable();

            try
            {

                //Este objeto es el que se encarga de ejecutar la peticion contra base de datos
                SqlCommand comando = new SqlCommand();

                //Asignacion los valores por ejecutar
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = objconexion;
                comando.CommandText = sentecia;

                SqlDataAdapter objconsulta = new SqlDataAdapter(comando);

                objconsulta.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    return true;
                }

                return false;



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                this.Cerrar();
            }

        }


        public List<ConsultaDocentes> getProfesores(string sentecia)
        {

            DataTable dt = new DataTable();

            List<ConsultaDocentes> lstResultados = new List<ConsultaDocentes>();


            try
            {

                //Este objeto es el que se encarga de ejecutar la peticion contra base de datos
                SqlCommand comando = new SqlCommand();

                //Asignacion los valores por ejecutar
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = objconexion;
                comando.CommandText = sentecia;

                SqlDataAdapter objconsulta = new SqlDataAdapter(comando);

                objconsulta.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow fila in dt.Rows)
                    {

                        lstResultados.Add(new ConsultaDocentes
                        {
                            Cedula = fila.ItemArray[0].ToString(),
                            Nombre = fila.ItemArray[1].ToString(),
                            PrimerAp = fila.ItemArray[2].ToString(),
                            Sueldo = Convert.ToDouble(fila.ItemArray[3].ToString()),
                            Descripcion = fila.ItemArray[4].ToString(),


                        });



                    }

                }

                return lstResultados;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                this.Cerrar();
            }

        }


        public List<Sedes> getSede(string sentecia)
        {

            DataTable dt = new DataTable();

            List<Sedes> lstResultados = new List<Sedes>();


            try
            {

                //Este objeto es el que se encarga de ejecutar la peticion contra base de datos
                SqlCommand comando = new SqlCommand();

                //Asignacion los valores por ejecutar
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = objconexion;
                comando.CommandText = sentecia;

                SqlDataAdapter objconsulta = new SqlDataAdapter(comando);

                objconsulta.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow fila in dt.Rows)
                    {

                        lstResultados.Add(new Sedes
                        {
                            IdSede = Convert.ToInt32(fila.ItemArray[0].ToString()),
                            Descripcion = fila.ItemArray[1].ToString(),


                        });



                    }

                }

                return lstResultados;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                this.Cerrar();
            }

        }





        public Personas getPersona(string sentecia)
        {

            DataTable dt = new DataTable();

            Personas lstResultados = new Personas();


            try
            {

                //Este objeto es el que se encarga de ejecutar la peticion contra base de datos
                SqlCommand comando = new SqlCommand();

                //Asignacion los valores por ejecutar
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = objconexion;
                comando.CommandText = sentecia;

                SqlDataAdapter objconsulta = new SqlDataAdapter(comando);

                objconsulta.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow fila in dt.Rows)
                    {

                        lstResultados.Nombre = fila.ItemArray[0].ToString();
                        lstResultados.PrimerAp = fila.ItemArray[1].ToString();




                    }

                }

                return lstResultados;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                this.Cerrar();
            }





            /*
            private static Sedes[] dataSedes = new Sedes[20];
            private static Profesores[] dataDocentes = new Profesores[20];
            private static int index1 = 0;


            public static bool GuardarSede(Sedes sedes) {

                dataSedes[index1] = sedes;

                index1++;

                //prueba
                Console.WriteLine(dataSedes.Length);

                return true;
            }


            public static bool SiExisteSede( int codigo) {

                if (index1 > 0) {

                    foreach (Sedes item in dataSedes)
                    {
                        if (item.IdSede == codigo)
                        {
                            return true;
                        }
                    }


                }





                return false;

            }



            public static Sedes[] getSede() { 

                return dataSedes;

            }

            */

        }
    }
}