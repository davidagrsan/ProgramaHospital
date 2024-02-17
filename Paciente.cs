using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalEsplai
{
    internal class Paciente : Persona
    {
        private string enfermedadPaciente;
        private Medico medicoAsignado = new Medico();
        private int idPaciente;

        public string EnfermedadPaciente { get => enfermedadPaciente; set => enfermedadPaciente = value; }
        public Medico MedicoAsignado { get => medicoAsignado; set => medicoAsignado = value; }
        public int IdPaciente { get => idPaciente; set => idPaciente = value; }

        public Paciente(string enfermedadPaciente, Medico medicoAsignado, string nombrePersona, int idPaciente)
            : base(nombrePersona)
        {
            this.enfermedadPaciente = enfermedadPaciente;
            this.medicoAsignado = medicoAsignado;
            this.idPaciente = idPaciente;
        }

        
        public override string ToString()
        {
            return 
                $"Nombre: {base.ToString()}\n" +
                $"Enfermedad: {enfermedadPaciente}\n" +
                $"Médico asignado: {medicoAsignado.NombrePersona}";
        }
    }
}
