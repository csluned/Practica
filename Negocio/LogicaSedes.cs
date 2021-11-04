using Entidades;
using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LogicaSedes
    {

        public static int GuardarSede( Sedes sedes) {

            ConexionDatos conexion = new ConexionDatos();
            string senteciaConsulta = "SELECT * FROM Sedes Where idSede =" + sedes.IdSede; 


            // Retorna 1 si la descripcion esta vacia
            if (String.IsNullOrEmpty(sedes.Descripcion)) {
                return 1;
            }


            //Retorna 2 si el codigo es repetido
            if (conexion.SiExisteSede(senteciaConsulta)) {

                return 2;
            }


            string senteciaInsertar = "INSERT INTO Sedes(idSede,descripcion) Values ('" + sedes.IdSede + "','" + sedes.Descripcion + "')";


            if (conexion.Ejecutar_Sentencia(senteciaInsertar))
            {

                return 0;
            }


            return 3;

        }


        // 2. comprobar datos ingresado de sedes.
        public static bool CompDatosSedes()
        {
            /*
            Sedes[] listSede = ConexionDatos.getSede();
            Console.WriteLine(listSede.Count());

            if (listSede.Count(x => x != null) == 0 || listSede == null)
            {
                return true;
            }*/

            return false;

        }

     
        public static List<Sedes> getSedes() {

            ConexionDatos conexion = new ConexionDatos();

            string sentecia = "SELECT * FROM Sedes";



          return conexion.getSede(sentecia);

        
        }


    }

    


}
