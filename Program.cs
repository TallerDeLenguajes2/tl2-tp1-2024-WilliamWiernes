using EspacioClases;
using EspacioDatos;
using EspacioMenu;

var cadeteria = new Cadeteria();

var archivoCadeteria = @"Datos\DatosCadeteria";
var archivoCadetes = @"Datos\DatosCadetes";

int seleccionDatos;
Console.WriteLine("Carga de Datos: \n1. Archivos CSV \n2. Archivos JSON");
do
{
    Console.Write("Seleccion: ");
    _ = int.TryParse(Console.ReadLine(), out seleccionDatos);
} while (seleccionDatos < 1 || seleccionDatos > 2);

if (seleccionDatos == 1)
{
    var lectorCSV = new AccesoCSV();
    lectorCSV.CargarDatosCadeteria(archivoCadeteria + ".csv", cadeteria);
    lectorCSV.CargarDatosCadetes(archivoCadetes + ".csv", cadeteria);
}
else
{
    var lectorJSON = new AccesoJSON();
    lectorJSON.CargarDatosCadeteria(archivoCadeteria + ".json", cadeteria);
    lectorJSON.CargarDatosCadetes(archivoCadetes + ".json", cadeteria);
}

Console.WriteLine(cadeteria.VerDatos);
foreach (var cadete in cadeteria.VerListaCadetes)
{
    Console.WriteLine(cadete.VerDatos);
}

int seleccion = 0;

while (seleccion != 5)
{
    Console.WriteLine("\n\nMenú: \n1. Alta pedido \n2. Asignar cadete \n3. Cambiar estado \n4. Reasignar cadete \n5. Salir");
    do
    {
        Console.Write("Seleccion: ");
        _ = int.TryParse(Console.ReadLine(), out seleccion);
    } while (seleccion < 1 || seleccion > 5);

    switch (seleccion)
    {
        case 1:
            Menu.Opcion1(cadeteria);
            break;
        case 2:
            Menu.Opcion2(cadeteria);
            break;
        case 3:
            Menu.Opcion3(cadeteria);
            break;
        case 4:
            Menu.Opcion4(cadeteria);
            break;
        case 5:
            Console.WriteLine("\nSaliendo...");
            break;
    }
}

Menu.InformeJornada(cadeteria);