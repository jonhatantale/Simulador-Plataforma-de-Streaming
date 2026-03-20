using System;
class Program
{
    static int menu;
    static int TotalEvaluados = 0;
    static int publicados = 0;
    static int rechazados = 0;
    static int revision = 0;
    static string impacto;
    static double porcentajeAprob = 0;
    static string contenidos;
    static int duracion;
    static string clasificacion;
    static int horario;
    static string produccion;
    static void Main()
    {

        do
        {
            MostrarMenu();
            menu = int.Parse(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    EvaluarContenido();
                    TotalEvaluados++;
                    break;
                case 2:
                    MostrarReglas();
                    break;
                case 3:
                    MostrarEstadisticas();
                    break;
                case 4:
                    ReiniciarEstadisticas();
                    break;
                case 5:
                    Console.WriteLine("Saliendo...");
                    MostrarEstadisticas();
                    break;
                default:
                    Console.WriteLine("\nOpción inválida, vuelva a intentarlo\n");
                    break;

            }

        } while (menu != 5);

    }
    static void MostrarMenu()
    {
        Console.WriteLine("Menú de opciones");
        Console.WriteLine("1. Evaluar contenido");
        Console.WriteLine("2. Mostrar reglas del sistema");
        Console.WriteLine("3. Mostrar estadisticas  de la sesión");
        Console.WriteLine("4. Reiniciar estadísticas");
        Console.WriteLine("5. Salir");
    }

    static void EvaluarContenido()
    {


        Console.WriteLine("\nEVALUACIÓN DE CONTENIDOS");
        Console.WriteLine("Ingrese tipo de contenido(película, serie ,documental, evento en vivo)");
        contenidos = Console.ReadLine().ToLower().Trim();
        while (contenidos != "pelicula" && contenidos != "serie" &&
               contenidos != "documental" && contenidos != "evento en vivo")
        {
            Console.WriteLine("\nContenido inválido, intente nuevamente\n");
            contenidos = Console.ReadLine().ToLower().Trim(); 
        }

        Console.WriteLine("\nIngrese la duración en minutos");
        duracion = int.Parse(Console.ReadLine());
        while (duracion < 1 || duracion >= 240)
        {
            Console.WriteLine("\nDuración inválida, intente de nuevo");
            duracion = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("\nIngrese la clasificación(todo publico, +13, +18)");
        clasificacion = Console.ReadLine().ToLower().Trim();
        while (clasificacion != "todo publico" && clasificacion != "+13" && clasificacion != "+18")
        {
            Console.WriteLine("\nContenido inválido, intentelo de nuevo");
            clasificacion = Console.ReadLine().ToLower().Trim();
        }

        Console.WriteLine("\nIngrese el horario de transmisión(0 - 23): ");
        horario = int.Parse(Console.ReadLine());
        while (horario < 0 || horario > 23)
        {
            Console.WriteLine("Horario Inválido, intente de nuevo");
            horario = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("\nIngrese el nivel de producción(bajo, medio, alto)");
        produccion = Console.ReadLine().ToLower().Trim();
        while (produccion != "bajo" && produccion != "medio" && produccion != "alto")
        {
            Console.WriteLine("\nProducción inválida, intentelo de nuevo");
            produccion = Console.ReadLine().ToLower().Trim();
        }

        if ((clasificacion == "+13" && (horario < 6 || horario > 22)) || 
            (clasificacion == "+18" && (horario < 22 && horario > 5)))
        {
            Console.WriteLine("\nContenido rechazado por regla de clásificación y horario.");
            Console.WriteLine("Consulte las reglas desde el menú principal.\n");
            rechazados++;
        }
        else if ((contenidos == "pelicula" && (duracion < 60 || duracion > 180)) || (contenidos == "serie" && (duracion < 20 || duracion > 90)) || 
        (contenidos == "documental" && (duracion < 30 || duracion > 120)) || (contenidos == "evento en vivo" && (duracion < 30 || duracion > 240)))
        {
            Console.WriteLine("\nContenido rechazado por regla de duración por tipo.");
            Console.WriteLine("Consulte las reglas desde el menú principal.\n");
            rechazados++;
        }
        else if (produccion == "bajo" && clasificacion == "+18")
        {
            Console.WriteLine("\nContenido rechazado por reglas de producción.");
            Console.WriteLine("Consulte las reglas desde el menú principal.\n");
            rechazados++;
        }
        else if (produccion == "alto" || duracion > 120 || (horario >= 20 && horario <= 23))
        {
            Console.WriteLine("\nIMPACTO ALTO");
            Console.WriteLine("Enviar a Revisión\n");
            revision++;
        }
        else if (produccion == "medio" || (duracion >= 60 && duracion <= 120))
        {
            Console.WriteLine("\nIMPACTO MEDIO");
            Console.WriteLine("Publicar\n");
            publicados++;

        }
        else if (produccion == "bajo" && duracion < 60)
        {
            Console.WriteLine("\nIMPACTO BAJO");
            Console.WriteLine("Publicar\n");
            publicados++;
        }
        else
        {
            Console.WriteLine("\nPublicar con ajustes\n");
            publicados++;

        }

    }

    static void MostrarReglas()
    {
        Console.WriteLine("\nREGLAS DEL SISTEMA");
        Console.WriteLine("1. Reglas de clasificación de horario.");
        Console.WriteLine("Todo publico: Cualquier horario.");
        Console.WriteLine("+13: Entre 6 y 22 horas (6 a.m. y 10 p.m.)");
        Console.WriteLine("+18: Entre 22 y 5 horas (10 p.m. y 5 a.m.)\n");
        Console.WriteLine("2. Relgas de duración por tipo.");
        Console.WriteLine("Película: 60 - 180 minutos.");
        Console.WriteLine("Serie: 20 - 90 minutos.");
        Console.WriteLine("Documental: 30 - 120 minutos");
        Console.WriteLine("Evento en vivo: 30 - 240 minutos.\n");
        Console.WriteLine("ADVERTENCIA: Si el contenido no cumple el rango de duración \nel programa lo marcará como error de validación técnica.\n");
        Console.WriteLine("3. Reglas de producción.");
        Console.WriteLine("Producción baja: Es váldo solo para Todo público o +13.");
        Console.WriteLine("Producción media o alta: Es válida para cualquier clasificación.\n");
        Console.WriteLine("SI EL CONTENIDO INFLINGE UNA REGLA AUTOMÁTICAMENTE ES RECHAZADO.\n");

    }

    static void MostrarEstadisticas()
    {
        Console.WriteLine("\nESTADÍSTICAS");
        Console.WriteLine("Cantidad de evaluaciones: " + TotalEvaluados);
        Console.WriteLine("Cantidad de rechazados: " + rechazados);
        Console.WriteLine("Cantidad de publicados: " + publicados);
        Console.WriteLine("Cantidad de enviados a revisión: " + revision);
        if (TotalEvaluados > 0)
        {
            porcentajeAprob = (double)(publicados + revision) / TotalEvaluados * 100;
            Console.WriteLine("Porcentaje de aprobación: " + porcentajeAprob + "%\n");
        }
        if (revision >= publicados && revision >= rechazados)
            Console.WriteLine("Impacto predominante: Alto");
        else if (publicados >= revision && publicados >= rechazados)
            Console.WriteLine("Impacto predominante: Bajo/Medio");
        else
            Console.WriteLine("Impacto predominante: Rechazados");
    }

    static void ReiniciarEstadisticas()
    {
        Console.WriteLine("\nREINICIANDO ESTADÍSTICA....\n");
        TotalEvaluados = 0;
        rechazados = 0;
        publicados = 0;
        revision = 0;
    }
}