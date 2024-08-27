using System.Security.Cryptography;
using EspacioClases;

var cadeteria = new Cadeteria();

var archivoCadeteria = @"CSV\DatosCadeteria.csv";
var archivoCadetes = @"CSV\DatosCadetes.csv";

// Carga y muestra de datos
cadeteria.CargarDatosCadeteriaCSV(archivoCadeteria);
cadeteria.CargarDatosCadetesCSV(archivoCadetes);

Console.WriteLine(cadeteria.VerDatos);
foreach (var cadete in cadeteria.VerLista)
{
    Console.WriteLine(cadete.VerDatos);
}

// Interfaz de consola
Console.WriteLine("\n\nMenú: \n1. Alta pedido \n2. Asignar pedido \n3. Cambiar estado \n4. Reasignar pedido");
int seleccion;
do
{
    Console.Write("Seleccion: ");
    _ = int.TryParse(Console.ReadLine(), out seleccion);
} while (seleccion < 1 || seleccion > 4);

switch (seleccion)
{
    case 1:
        break;
    case 2:
        break;
    case 3:
        break;
    case 4:
        break;
}
