using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalEsplai
{
    internal class Persona
    {
        private string nombrePersona;

        public string NombrePersona { get { return nombrePersona; } set {  nombrePersona = value; } }

        public Persona ()
        {

        }

        public Persona (string nombrePersona)
        {
            NombrePersona = nombrePersona;
        }

        public override string ToString()
        {
            return $"{NombrePersona}";
        }
    }
}
