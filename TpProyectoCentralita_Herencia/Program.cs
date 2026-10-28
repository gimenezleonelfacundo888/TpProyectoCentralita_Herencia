namespace TpProyectoCentralita_Herencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Centralita centralita = new Centralita("telefonisca");
            Local local1 = new Local(10, "222", "111", 2);
            

            Llamada datosLocal = new Llamada(5, "333", "111");
            Local local2 = new Local(datosLocal, 3);

            Provincial provincial1 = new Provincial(
                10, "444", "111", Franja.Franja_2);

            Llamada datosProvincial = new Llamada(5, "555", "111");
            Provincial provincial2 = new Provincial(datosProvincial, Franja.Franja_3);

            centralita.Llamadas.Add(local1);
            centralita.Llamadas.Add(local2);
            centralita.Llamadas.Add(provincial1);
            centralita.Llamadas.Add(provincial2);

            Console.WriteLine("=== ANTES DE ORDENAR ===");
            Console.WriteLine(centralita.Mostrar());

            centralita.OrdenarLlamadas();

            Console.WriteLine("=== DESPUÉS DE ORDENAR ===");
            Console.WriteLine(centralita.Mostrar());

        }
    }
}
