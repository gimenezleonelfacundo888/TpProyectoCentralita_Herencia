using System;
using System.Collections.Generic;
using System.Text;

namespace TpProyectoCentralita_Herencia
{
    public enum TipoDeLlamada
    {
        Local,
        Provincial,
        Todas
    }
    internal class Centralita
    {
        private List<Llamada> listaDeLlamadas;
        private string razonSocial;

        public Centralita()
        {
            this.listaDeLlamadas = new List<Llamada>();
        }
        public Centralita(string razonSocial): this()
        {
            this.razonSocial = razonSocial;
        }
        public List<Llamada> Llamadas
        {
            get
            {
                return this.listaDeLlamadas;
            }
        }
        private float CalcularGanancia(TipoDeLlamada tipo)
        {
            float ganancia = 0;
            foreach(Llamada llamada in listaDeLlamadas)
            {
                if(tipo == TipoDeLlamada.Todas)
                {
                    if (llamada.GetType() == typeof(Local))
                    {
                        Local llamadaLocal = (Local)llamada;
                        ganancia += llamadaLocal.CostoLlamada;
                    }
                    else if (llamada.GetType() == typeof(Provincial))
                    {
                        Provincial llamadaProvincial = (Provincial)llamada;
                        ganancia += llamadaProvincial.CostoLlamada;
                    }
                }
                else if (tipo == TipoDeLlamada.Local &&
                         llamada.GetType() == typeof(Local))
                {
                    Local llamadaLocal = (Local)llamada;
                    ganancia += llamadaLocal.CostoLlamada;
                }
                else if (tipo == TipoDeLlamada.Provincial &&
                         llamada.GetType() == typeof(Provincial))
                {
                    Provincial llamadaProvincial = (Provincial)llamada;
                    ganancia += llamadaProvincial.CostoLlamada;
                }
            }
            return ganancia;
        }
        public float GananciaPorLocal
        {
            get { return CalcularGanancia(TipoDeLlamada.Local); }
        }

        public float GananciaPorProvincial
        {
            get { return CalcularGanancia(TipoDeLlamada.Provincial); }
        }

        public float GananciaPorTotal
        {
            get { return CalcularGanancia(TipoDeLlamada.Todas); }
        }

        public void OrdenarLlamadas()
        {
            listaDeLlamadas.Sort(Llamada.OrdenarPorDuracion);
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Centralita: {razonSocial}");
            sb.AppendLine($"Ganancia total: {GananciaPorTotal}");
            sb.AppendLine($"Ganancia por llamadas locales: {GananciaPorLocal}");
            sb.AppendLine($"Ganancia por llamadas provinciales: {GananciaPorProvincial}");
            sb.AppendLine();
            sb.AppendLine("DETALLE DE LLAMADAS");

            int contador = 1;

            foreach (Llamada llamada in listaDeLlamadas)
            {
                sb.AppendLine($"Llamada número {contador}");

                if (llamada.GetType() == typeof(Local))
                {
                    Local llamadaLocal = (Local)llamada;
                    sb.Append(llamadaLocal.Mostrar());
                }
                else if (llamada.GetType() == typeof(Provincial))
                {
                    Provincial llamadaProvincial = (Provincial)llamada;
                    sb.Append(llamadaProvincial.Mostrar());
                }

                sb.AppendLine();
                contador++;
            }

            return sb.ToString();
        }
    }
}
