using System.Numerics;

Console.WriteLine("Menú de opciones");
Console.WriteLine("1. Evaluar contenido");
Console.WriteLine("2. Mostrar reglas del sistema");
Console.WriteLine("3. Mostrar estadisticas  de la sesión");
Console.WriteLine("4. Reiniciar estadísticas");
Console.WriteLine("5. Salir");
int menu;

do
{
    menu = int.Parse(Console.ReadLine());
    switch (menu)
    {
        case 1:
            string[] contValidos = { "pelicula", "serie", "documental", "evento en vivo" };
            Console.WriteLine("Ingrese tipo de contenido(película, serie ,documental, evento en vivo)");
            string contenidos = Console.ReadLine();

            if (Array.Exists(contValidos, cont => cont == contenidos))
            {
               
                Console.WriteLine("Ingrese la duración en minutos");
                int duracion = int.Parse(Console.ReadLine());

                if (duracion >= 20 && duracion <= 240)
                {
                    string[] clasValidas = {"todo publico", "+13", "+18" };
                    Console.WriteLine("Ingrese la clasificación(todo publico, +13, +18)");
                    string clasificacion = Console.ReadLine();

                    if (Array.Exists(clasValidas, clas => clas == clasificacion))
                    {

                        Console.WriteLine("Ingrese la hora programada para transmitir(0-23)");
                        int transmision = int.Parse(Console.ReadLine());
                        if ()
                        {
                            Console.WriteLine("Ingrese nivel de producción(bajo, medio, alto)");
                            string produccion = Console.ReadLine();

                        }
                    }

                }
            }

        break;

    }

} while (menu != 5);


Console.WriteLine("holas ");
