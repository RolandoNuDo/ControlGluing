using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidad
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Nivel { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int Nomina { get; set; }
        
        public Usuario()
        {

        }

        public Usuario(int ID, string Nombre, string ApellidoP, string ApellidoM, string Nivel, string User, string Password, int Nomina)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.ApellidoP = ApellidoP;
            this.ApellidoM = ApellidoM;
            this.Nivel = Nivel;
            this.User = User;
            this.Password = Password;
            this.Nomina = Nomina;
        }
    }
}
