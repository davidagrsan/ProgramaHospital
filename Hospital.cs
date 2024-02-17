using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalEsplai
{
    internal class Hospital
    {
        private List<Persona> personasList = new List<Persona>();
        private int idMedico = 0;
        private int idPaciente = 0;
        public List<Persona> PersonasList { get => personasList; set => personasList = value; }

        public Hospital()
        {

        }

        public string PedirNombre()
        {
            Console.WriteLine("¿Cuál es el nombre de la persona que quieres dar de alta?");
            return Console.ReadLine();
        }

        public void EliminarPacienteGeneral(Paciente pacienteEliminado)
        {
            personasList.Remove(pacienteEliminado);
        }

        public void ListarMedicos()
        {
            foreach (Persona persona in personasList)
            {
                if (persona is Medico m)
                    Console.WriteLine(m.ToString());
            }
        }

        public Medico FiltrarMedico()
        {
            Console.WriteLine("\nEscribe el número del médico: ");
            int medicoSeleccionado = int.Parse(Console.ReadLine());

            var medicos = personasList.OfType<Medico>();

            if (medicos.Any(medico => medico.IdMedico == medicoSeleccionado))
            {
                Medico medicoFiltrado = medicos.FirstOrDefault(m => m.IdMedico == medicoSeleccionado);
                return medicoFiltrado;
            }
            return null;
        }

        public Paciente FiltrarPaciente(Medico medicoFiltrado)
        {
            Console.WriteLine("Escribe el número del paciente");
            int pacienteSeleccionado = int.Parse(Console.ReadLine());

            var pacientes = medicoFiltrado.PacientesAsociados;

            if (pacientes.Any(paciente => paciente.IdPaciente == pacienteSeleccionado))
            {
                Paciente pacienteFiltrado = pacientes.FirstOrDefault(p => p.IdPaciente == pacienteSeleccionado);
                return pacienteFiltrado;
            }
            else
            {
                Console.WriteLine("No se ha podido filtrar de la lista, número de paciente incorrecto");
                return null;
            }
        }

        public void ListarPacientes()
        {
            ListarMedicos();

            Medico medicoFiltrado = FiltrarMedico();

            medicoFiltrado.MostrarPacientes();
        }

        public void EliminarPaciente()
        {
            ListarMedicos();

            Medico medicoFiltrado = FiltrarMedico();

            medicoFiltrado.MostrarPacientes();

            Paciente pacienteFiltrado = FiltrarPaciente(medicoFiltrado);

            medicoFiltrado.EliminarPaciente(pacienteFiltrado);
            EliminarPacienteGeneral(pacienteFiltrado);
            Console.WriteLine("El paciente ha sido eliminado del sistema.");
        }
        public void AltaAdministrativo()
        {
            string nombreAdmin = PedirNombre();
            Console.WriteLine("¿Cuál es el cargo del administrativo?");
            string cargoAdmin = Console.ReadLine();
            Administrativo nuevoAdmin = new Administrativo(nombreAdmin, cargoAdmin);
            Console.WriteLine($"El administrativo {nuevoAdmin.NombrePersona} se ha dado de alta");
            personasList.Add(nuevoAdmin);
        }

        public void AltaMedico()
        {
            idMedico++;
            string nombreMedico = PedirNombre();
            Medico nuevoMedico = new Medico(nombreMedico, idMedico);
            Console.WriteLine($"El médico {nuevoMedico.NombrePersona} se ha dado de alta");
            personasList.Add(nuevoMedico);
        }

        public void AltaPaciente()
        {
            idPaciente++;
            string nombrePaciente = PedirNombre();
            Console.WriteLine("¿Qué enfermedad tiene el paciente?");
            string enfermedadPaciente = Console.ReadLine();

            Console.WriteLine("Estos son los médicos disponibles: ");
            ListarMedicos();

            Console.WriteLine("Escribe el número del médico que se asignará al paciente");

            int medicoSeleccionado = int.Parse(Console.ReadLine());

            var medicos = personasList.OfType<Medico>();

            if (medicos.Any(medico => medico.IdMedico == medicoSeleccionado))
            {
                Medico medico = medicos.FirstOrDefault(m => m.IdMedico == medicoSeleccionado);
                Paciente nuevoPaciente = new Paciente(enfermedadPaciente, medico, nombrePaciente, idPaciente);
                medico.AgregarPaciente(nuevoPaciente);
                personasList.Add(nuevoPaciente);
                Console.WriteLine(nuevoPaciente);
            }
            else
                Console.WriteLine("No se ha podido dar de alta, número de médico incorrecto");
        }

        public void MostrarPersonas()
        {
            foreach (Persona persona in personasList)
            {
                if (persona is Medico m)
                    Console.WriteLine($"Médico: \n{m}\n");
                else if (persona is Administrativo a)
                    Console.WriteLine($"Administrativo: \n{a}\n");
                else if(persona is Paciente p)
                    Console.WriteLine($"Paciente: \n{p}\n");
            }
            Console.WriteLine(personasList);
        }
    }
}
