using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalEsplai
{
    internal class Administrativo : Persona
    {
        private string cargoAdministrativo;
        public string CargoAdministrativo { get => cargoAdministrativo; set => cargoAdministrativo = value; }

        public Administrativo(string nombrePersona, string cargoAdministrativo) 
            : base(nombrePersona)
        {
            this.cargoAdministrativo = cargoAdministrativo;
        }

        public override string ToString()
        {
            return
            $"Nombre: {base.ToString()}\n" +
            $"Cargo: {cargoAdministrativo}";
        }
    }
}
