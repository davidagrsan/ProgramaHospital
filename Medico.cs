using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HospitalEsplai
{
    internal class Medico : Persona
    {
        private List<Paciente> pacientesAsociados = new List<Paciente>();
        private int idMedico;
        public List<Paciente> PacientesAsociados { get => pacientesAsociados; set => pacientesAsociados = value; }
        public int IdMedico { get => idMedico; set => idMedico = value; }

        public Medico() : base()
        {

        }

        public Medico(string nombrePersona, int idMedico)
            : base (nombrePersona)
        {
            this.idMedico = idMedico;
        }

        public void AgregarPaciente(Paciente nuevoPaciente)
        {
            Console.Clear();
            pacientesAsociados.Add(nuevoPaciente);
            Console.WriteLine($"El paciente se ha agregado a la lista del médico {base.NombrePersona}");
        }

        public void EliminarPaciente(Paciente pacienteEliminado)
        {
            pacientesAsociados.Remove(pacienteEliminado);
        }

        public void MostrarPacientes()
        {
            foreach (Paciente paciente in pacientesAsociados)
            {
                Console.WriteLine($"{paciente.IdPaciente}. Nombre paciente: {paciente.NombrePersona}\n " +
                    $"Enfermedad paciente: {paciente.EnfermedadPaciente}");
            }
        }

        public override string ToString()
        {
            return
                $"{idMedico}. " +
                $"{base.ToString()}\n" +
                $"Pacientes asociados: {pacientesAsociados.Count}";
        }
    }
}
