using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalEsplai
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Programa();
        }

        static void Programa()
        {
            Console.WriteLine("Programa Hospital Espai\n--------------------------\n");
            // Creamos el hospital que a su vez creará la lista de personas
            Hospital hospital = new Hospital();
            Console.WriteLine("Pulse cualquier tecla para iniciar el programa");
            Console.ReadKey();
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"
¿Qué acción quieres realizar?
1. Dar de alta un médico
2. Dar de alta un paciente en un médico concreto
3. Dar de alta un administrativo
4. Listar los médicos
5. Listar los pacientes de un médico concreto
6. Eliminar un paciente
7. Ver la lista completa de personas en el hospital
0. Salir del programa");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("Vamos a dar de alta a un médico...");
                        hospital.AltaMedico();
                        Console.ReadKey();
                        continue;
                    case 2:
                        Console.WriteLine("Vamos a dar de alta a un paciente...");
                        hospital.AltaPaciente();
                        Console.ReadKey();
                        continue;
                    case 3:
                        Console.WriteLine("Vamos a dar de alta a un administrativo...");
                        hospital.AltaAdministrativo();
                        Console.ReadKey();
                        continue;
                    case 4:
                        Console.WriteLine("Vamos a listar médicos...");
                        hospital.ListarMedicos();
                        Console.ReadKey();
                        continue;
                    case 5:
                        Console.WriteLine("Vamos a listar los pacientes de un médico...");
                        hospital.ListarPacientes();
                        Console.ReadKey();
                        continue;
                    case 6:
                        Console.WriteLine("Vamos a eliminar un paciente...");
                        hospital.EliminarPaciente();
                        Console.ReadKey();
                        continue;
                    case 7:
                        Console.WriteLine("Vamos a mostrar todas las personas del hospital...");
                        hospital.MostrarPersonas();
                        Console.ReadKey();
                        continue;
                    default:
                        Console.WriteLine("No has dado ninguna de las opciones válidas, se saldrá del programa");
                        break;
                }
            }
        }
    }
}
