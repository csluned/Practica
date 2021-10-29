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

        public static int GuardarSede( Universidades sedes) {

            // Retorna 1 si la descripcion esta vacia
            if (String.IsNullOrEmpty(sedes.Descripcion)) {
                return 1;
            }

            //Retorna 2 si el codigo es repetido
            if (ConexionDatos.SiExisteSede(sedes.IdSede)) {

                return 2;
            }


            ConexionDatos.GuardarSede(sedes);

            return 0;

        }


        // 2. comprobar datos ingresado de sedes.
        public static bool CompDatosSedes()
        {

            Universidades[] listSede = ConexionDatos.getSede();
            Console.WriteLine(listSede.Count());

            if (listSede.Count(x => x != null) == 0 || listSede == null)
            {
                return true;
            }

            return false;

        }


        public static Universidades[] getSedes() {

            return ConexionDatos.getSede();

        
        }


    }

    


}
