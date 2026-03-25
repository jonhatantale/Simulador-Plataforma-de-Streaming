Algoritmo Proyecto
	
	Definir menu Como Entero
	Definir TotalEvaluados, publicados, rechazados, revision Como Entero
	Definir contenidos, clasificacion, produccion Como Cadena
	Definir duracion, horario Como Entero
	Definir porcentajeAprob Como Real
	
	TotalEvaluados <- 0
	publicados <- 0
	rechazados <- 0
	revision <- 0
	porcentajeAprob <- 0
	
	Repetir
		Escribir ""
		Escribir "=== MENÚ DE OPCIONES ==="
		Escribir "1. Evaluar contenido"
		Escribir "2. Mostrar reglas del sistema"
		Escribir "3. Mostrar estadísticas de la sesión"
		Escribir "4. Reiniciar estadísticas"
		Escribir "5. Salir"
		Leer menu
		
		Segun menu Hacer
			1:
				TotalEvaluados <- TotalEvaluados + 1
				
				Escribir "=== EVALUACIÓN DE CONTENIDO ==="
				Escribir "Ingrese tipo de contenido (pelicula, serie, documental, evento en vivo):"
				Leer contenidos
				Mientras contenidos <> "pelicula" Y contenidos <> "serie" Y contenidos <> "documental" Y contenidos <> "evento en vivo" Hacer
					Escribir "Contenido inválido, intente de nuevo:"
					Leer contenidos
				Fin Mientras
				
				Escribir "Ingrese la duración en minutos:"
				Leer duracion
				Mientras duracion < 1 O duracion > 240 Hacer
					Escribir "Duración inválida, intente de nuevo:"
					Leer duracion
				Fin Mientras
				
				Escribir "Ingrese la clasificación (todo publico, +13, +18):"
				Leer clasificacion
				Mientras clasificacion <> "todo publico" Y clasificacion <> "+13" Y clasificacion <> "+18" Hacer
					Escribir "Clasificación inválida, intente de nuevo:"
					Leer clasificacion
				Fin Mientras
				
				Escribir "Ingrese el horario de transmisión (0-23):"
				Leer horario
				Mientras horario < 0 O horario > 23 Hacer
					Escribir "Horario inválido, intente de nuevo:"
					Leer horario
				Fin Mientras
				
				Escribir "Ingrese nivel de producción (bajo, medio, alto):"
				Leer produccion
				Mientras produccion <> "bajo" Y produccion <> "medio" Y produccion <> "alto" Hacer
					Escribir "Producción inválida, intente de nuevo:"
					Leer produccion
				Fin Mientras
				
				Si (clasificacion = "+13" Y (horario < 6 O horario > 22)) O (clasificacion = "+18" Y (horario < 22 Y horario > 5)) Entonces
					Escribir "Rechazado: horario no válido para esta clasificación."
					rechazados <- rechazados + 1
				SiNo
					Si (contenidos = "pelicula" Y (duracion < 60 O duracion > 180)) O (contenidos = "serie" Y (duracion < 20 O duracion > 90)) O (contenidos = "documental" Y (duracion < 30 O duracion > 120)) O (contenidos = "evento en vivo" Y (duracion < 30 O duracion > 240)) Entonces
						Escribir "Rechazado: duración inválida para este tipo de contenido."
						rechazados <- rechazados + 1
					SiNo
						Si produccion = "bajo" Y clasificacion = "+18" Entonces
							Escribir "Rechazado: producción baja no válida para +18."
							rechazados <- rechazados + 1
						SiNo
							Si produccion = "alto" O duracion > 120 O (horario >= 20 Y horario <= 23) Entonces
								Escribir "Impacto Alto - Enviar a revisión"
								revision <- revision + 1
							SiNo
								Si produccion = "medio" O (duracion >= 60 Y duracion <= 120) Entonces
									Escribir "Impacto Medio - Publicar"
									publicados <- publicados + 1
								SiNo
									Si produccion = "bajo" Y duracion < 60 Entonces
										Escribir "Impacto Bajo - Publicar"
										publicados <- publicados + 1
									SiNo
										Escribir "Publicar con ajustes"
										publicados <- publicados + 1
									Fin Si
								Fin Si
							Fin Si
						Fin Si
					Fin Si
				Fin Si
				
			2:
				Escribir "=== REGLAS DEL SISTEMA ==="
				Escribir "Todo público: cualquier horario"
				Escribir "+13: entre 6 y 22 horas"
				Escribir "+18: entre 22 y 5 horas"
				Escribir "Película: 60-180 min | Serie: 20-90 min"
				Escribir "Documental: 30-120 min | Evento en vivo: 30-240 min"
				Escribir "Producción baja: solo todo público o +13"
				
			3:
				Escribir "=== ESTADÍSTICAS ==="
				Escribir "Total evaluados: ", TotalEvaluados
				Escribir "Publicados: ", publicados
				Escribir "Rechazados: ", rechazados
				Escribir "En revisión: ", revision
				Si TotalEvaluados > 0 Entonces
					porcentajeAprob <- (publicados + revision) / TotalEvaluados * 100
					Escribir "Porcentaje de aprobación: ", porcentajeAprob, "%"
				Fin Si
				
			4:
				TotalEvaluados <- 0
				publicados <- 0
				rechazados <- 0
				revision <- 0
				Escribir "Estadísticas reiniciadas."
				
			5:
				Escribir "=== RESUMEN FINAL ==="
				Escribir "Total evaluados: ", TotalEvaluados
				Escribir "Publicados: ", publicados
				Escribir "Rechazados: ", rechazados
				Escribir "En revisión: ", revision
				Escribir "Hasta luego!"
				
			De Otro Modo:
				Escribir "Opción inválida."
		Fin Segun
		
	Hasta Que menu = 5
	
FinAlgoritmo

