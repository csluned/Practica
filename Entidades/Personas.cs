using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    // Clase de Objeto padre que hereda a clase hijas Profesor y Estudiantes
    public class Personas
    {
        public string Nombre { get; set; }
        public string PrimerAp { get; set; }
        public string SegundoAp { get; set; }

        // Universidades hacer referencia a Sedes
        public Universidades[] Sedes { get; set; }


    }
}
