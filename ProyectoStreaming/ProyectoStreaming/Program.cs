using System;

int menu;
int TotalEvaluados = 0;
int publicados = 0;
int rechazados = 0;
int revision = 0;
string impacto;
double porcentajeAprob = 0;

do
{
    MostrarMenu();
    menu = int.Parse(Console.ReadLine());

    switch (menu)
    {
        case 1: EvaluarContenido(ref int publicados, ref int rechazados, ref int revision);
            TotalEvaluados++; 
            break;
        case 2: MostrarReglas(); 
            break;
        case 3: MostrarEstadisticas(TotalEvaluados);
            break;
        /*case 4: ReinicarEstadisticas();
            break;*/
        case 5: Console.WriteLine("Saliendo...");
            break;

    }

} while (menu != 5);

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
    string contenidos;
    int duracion;
    string clasificacion;
    int transmision;
    string produccion;

    Console.WriteLine("Ingrese tipo de contenido(película, serie ,documental, evento en vivo)");
    contenidos = Console.ReadLine();

    if (contenidos == "pelicula" || contenidos == "serie" ||
    contenidos == "documental" || contenidos == "evento en vivo")
    {

        Console.WriteLine("Ingrese la duración en minutos");
        duracion = int.Parse(Console.ReadLine());

        if (duracion >= 20 && duracion <= 240)
        {
            Console.WriteLine("Ingrese la clasificación(todo publico, +13, +18)");
            clasificacion = Console.ReadLine();

            if (clasificacion == "todo publico" || clasificacion == "+13" || clasificacion == "+18")
            {

                Console.WriteLine("Ingrese la hora programada para transmitir(0-23)");
                transmision = int.Parse(Console.ReadLine());

                if ((clasificacion == "todo publico") || (clasificacion == "+13" && transmision >= 6 && transmision <= 22) ||
                    (clasificacion == "+18" && (transmision >= 22 || transmision <= 5)))
                {
                    Console.WriteLine("Ingrese nivel de producción(bajo, medio, alto)");
                    produccion = Console.ReadLine();

                    if (produccion == "bajo" || produccion == "medio" || produccion == "alto")
                    {
                        if (produccion == "alto" || duracion > 120 || (transmision >= 20 && transmision <= 23))
                        {
                            Console.WriteLine("Impacto Alto");
                            Console.WriteLine("Enviar a Revisión");
                        }
                        else if (produccion == "medio" || (duracion >= 60 && duracion <= 120))
                        {
                            Console.WriteLine("Impacto Medio");
                            Console.WriteLine("Publicar");
                        }
                        else if (produccion == "bajo" && duracion < 60)
                        {
                            Console.WriteLine("Bajo");
                            Console.WriteLine("Publicar");
                        }
                        else
                        {
                            Console.WriteLine("Publicar con ajustes");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nivel de produccion no válido");
                        rechazados ++;
                    }

                }
                else
                {
                    Console.WriteLine("Horario de transmisión no válida");
                    rechazados++;
                }
            }
            else
            {
                Console.WriteLine("Clasificación no válida");
                rechazados++;
            }

        }
        else
        {
            Console.WriteLine("Duración inválida");
            rechazados++;
        }
    }
    else
    {
        Console.WriteLine("Contenido inválido");
        rechazados++;
    }
  
}

static void MostrarReglas()
{
    Console.WriteLine("");
    Console.WriteLine("REGLAS DEL SISTEMA");
    Console.WriteLine("1. Reglas de clasificación de horario.");
    Console.WriteLine("Todo publico: Cualquier horario.");
    Console.WriteLine("+13: Entre 6 y 22 horas (6 a.m. y 10 p.m.)");
    Console.WriteLine("+18: Entre 22 y 5 horas (10 p.m. y 5 a.m.)");
    Console.WriteLine("");
    Console.WriteLine("2. Relgas de duración por tipo.");
    Console.WriteLine("Película: 60 - 180 minutos.");
    Console.WriteLine("Serie: 20 - 90 minutos.");
    Console.WriteLine("Documental: 30 - 120 minutos");
    Console.WriteLine("Evento en vivo: 30 - 240 minutos.");
    Console.WriteLine("");
    Console.WriteLine("ADVERTENCIA: Si el contenido no cumple el rango de duración \nel programa lo marcará como error de validación técnica");
    Console.WriteLine("");
    Console.WriteLine("3. Reglas de producción.");
    Console.WriteLine("Producción baja: Es váldo solo para Todo público o +13.");
    Console.WriteLine("Producción media o alta: Es válida para cualquier clasificación.");
    Console.WriteLine("");
    Console.WriteLine("SI EL CONTENIDO INFLINGE UNA REGLA AUTOMÁTICAMENTE ES RECHAZADO.");
    Console.WriteLine("");
    
}

static void MostrarEstadisticas(int evaluados)
{
    Console.WriteLine("Cantidad de evaluaciones: " + evaluados);
}

