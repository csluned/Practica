using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    // Profesor hereda de Personas
    public class Profesores:Personas
    {
        public int IdProfesor { get; set; }
        public double Sueldo { get; set; }
        public string Usuario { get; set; }
        //contraseña
        public string Password { get; set; }

        public Universidades[] LSedes { get; set; }


    }




}
