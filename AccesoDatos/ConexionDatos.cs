using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ConexionDatos
    {

        private static Universidades[] dataSedes = new Universidades[20];
        private static Profesores[] dataDocentes = new Profesores[20];
        private static int index1 = 0;


        public static bool GuardarSede(Universidades sedes) {

            dataSedes[index1] = sedes;
           
            index1++;

            //prueba
            Console.WriteLine(dataSedes.Length);

            return true;
        }


        public static bool SiExisteSede( int codigo) {

            if (index1 > 0) {

                foreach (Universidades item in dataSedes)
                {
                    if (item.IdSede == codigo)
                    {
                        return true;
                    }
                }


            }
             
                



            return false;

        }



        public static Universidades[] getSede() { 
        
            return dataSedes;
        
        }



    }
}
