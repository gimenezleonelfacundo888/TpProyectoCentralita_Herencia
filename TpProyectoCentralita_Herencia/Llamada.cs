using System;
using System.Collections.Generic;
using System.Text;

namespace TpProyectoCentralita_Herencia
{
    public class Llamada
    {
        private float duracion;
        private string nroDestino;
        private string nroOrigen;

        public float Duracion { get => duracion; }
        public string NroDestino { get => nroDestino; }
        public string NroOrigen { get => nroOrigen; }
        public Llamada(float duracion, string nroDestino, string nroOrigen)
        {
            this.duracion = duracion;
            this.nroDestino = nroDestino;
            this.nroOrigen = nroOrigen;
        }
        public static int  OrdenarPorDuracion(Llamada llamada1, Llamada llamada2)
        {
            if(llamada1.Duracion < llamada2.Duracion)
            {
                return -1;
            }
            else if (llamada1.Duracion > llamada2.Duracion)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-DURACION: {this.Duracion}");
            sb.AppendLine($"-NUMERO DE ORIGEN: {this.NroOrigen}");
            sb.AppendLine($"-NUMERO DE DESTINO: {this.NroDestino}");
            return sb.ToString();
        }
    }
}
