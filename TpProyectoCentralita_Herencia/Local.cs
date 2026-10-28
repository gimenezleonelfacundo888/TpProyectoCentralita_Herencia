using System;
using System.Collections.Generic;
using System.Text;

namespace TpProyectoCentralita_Herencia
{
    public class Local : Llamada
    {
        protected float costo;
        public Local(Llamada llamada, float costo):
            base(llamada.Duracion, llamada.NroDestino, llamada.NroOrigen)
        {
            this.costo = costo;
        }
        public Local(float duracion, string nroDestino, string nroOrigen, float costo):
            base(duracion, nroDestino, nroOrigen)
        {
            this.costo = costo;
        }
        private float CalcularCosto()
        {
            return Duracion * costo;
        }
        public float CostoLlamada
        {
            get
            {
                return CalcularCosto();
            }
        }
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("------LOCAL------");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"-COSTO: {this.costo}");
            return sb.ToString();
        }
    }
}
