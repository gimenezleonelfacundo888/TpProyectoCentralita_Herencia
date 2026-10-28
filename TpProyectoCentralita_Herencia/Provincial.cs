using System;
using System.Collections.Generic;
using System.Text;

namespace TpProyectoCentralita_Herencia
{
    public enum Franja
    {
        Franja_1,
        Franja_2,
        Franja_3

    }
    internal class Provincial : Llamada
    {
        protected Franja franjaHoraria;
        public Provincial(Llamada llamada, Franja franjaHoraria)
            : base(llamada.Duracion, llamada.NroDestino, llamada.NroOrigen)
        {
            this.franjaHoraria = franjaHoraria;
        }

        public Provincial(float duracion, string nroDestino, string nroOrigen, Franja franjaHoraria):
            base(duracion, nroDestino, nroOrigen)
        {
            this.franjaHoraria = franjaHoraria;
        }
        private float CalcularCosto()
        {
            float costoUnidad = 0;
            switch (this.franjaHoraria)
            {
                case Franja.Franja_1:
                    costoUnidad = 0.99f;
                    break;
                case Franja.Franja_2:
                    costoUnidad = 1.25f;
                    break;
                case Franja.Franja_3:
                    costoUnidad = 0.66f;
                    break;
            }
            return Duracion * costoUnidad;
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
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("------PROVINCIAL------");
            sb.AppendLine($"-FRANJA HORARIA: {this.franjaHoraria}");
            sb.AppendLine($"-COSTO TOTAL: {this.CostoLlamada}");
            return sb.ToString();
        }
    }
}
