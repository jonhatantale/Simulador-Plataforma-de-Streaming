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
            Console.WriteLine("Ingrese tipo de contenido(película, serie ,documental, evento en vivo)");
            string tcontenido = Console.ReadLine();

            Console.WriteLine("Ingrese la duración en minutos");
            int duracion = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la clasificación(todo publico, +13, +18)");
            string clasificacion = Console.ReadLine();

            Console.WriteLine("Ingrese la hora programada para transmitir(0-23)");
            int transmision = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese nivel de producción(bajo, medio, alto)");
            string produccion = Console.ReadLine();
            

            break;

    }

} while (menu != 5);
