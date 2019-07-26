using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidad
{
    public class Caja
    {
        public int NumCaja { get; set; }
        public string FechaEntrada { get; set; }
        public DateTime Fecha { get; set; }
        public string Nivel { get; set; }
        public string Fila { get; set; }
        public string CodigoRack { get; set; }
        public string ID_Etiqueta { get; set; }
        public int ID_Usuario { get; set; }
        public string Liberacion { get; set; }
        public string NoParte { get; set; }
        public string Rack { get; set; }

        public Caja() { }

    }
}
