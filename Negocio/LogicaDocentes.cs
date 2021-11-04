using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LogicaDocentes
    {

        public static int GuardarDocente(Profesores docente,List<Sedes> listasede)
        {

            ConexionDatos conexion = new ConexionDatos();


            string senteciaInsertar = "INSERT INTO Personas(cedula, nombre, apellidos) VALUES('" + docente.Cedula + "','" + docente.Nombre + "','" + docente.PrimerAp + "')";



            //string senteciaInsertar = "INSERT INTO Sedes(idSede,descripcion) Values ('" + sedes.IdSede + "','" + sedes.Descripcion + "')";


            if (conexion.Ejecutar_Sentencia(senteciaInsertar))
            {
                string senteciaInsertar2 = "INSERT INTO Profesores(cedula, sueldo, usuario, password) Values('" + docente.Cedula + "','" + docente.Sueldo + "','" + docente.Usuario + "','" + docente.Password + "')";


                if (conexion.Ejecutar_Sentencia(senteciaInsertar2)) {

                    


                }

                return 0;
            }


            return 3;

        }







        public static List<ConsultaDocentes> GetProfesores()
        {

            ConexionDatos conexion = new ConexionDatos();

            string setencia = "select Personas.cedula,nombre,apellidos,sueldo,descripcion from Personas inner join Profesores on Personas.cedula = Profesores.cedula " +
            "inner join ProfesorXSede on Profesores.cedula = ProfesorXSede.cedula inner join Sedes on ProfesorXSede.IdSede = Sedes.idSede";


            return conexion.getProfesores(setencia);
        }

    }
}
