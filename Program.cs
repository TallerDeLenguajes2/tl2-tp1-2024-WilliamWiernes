using EspacioClases;

var cadeteria = new Cadeteria();

var archivoCadeteria = @"CSV\DatosCadeteria.csv";
var archivoCadetes = @"CSV\DatosCadetes.csv";

cadeteria.CargarDatosCadeteriaCSV(archivoCadeteria);
cadeteria.CargarDatosCadetesCSV(archivoCadetes);

Console.WriteLine(cadeteria.VerDatos);
foreach (var cadete in cadeteria.VerLista)
{
    Console.WriteLine(cadete.VerDatos);
}

int seleccion = 0;

while (seleccion != 5)
{
    Console.WriteLine("\n\nMenú: \n1. Alta pedido \n2. Asignar pedido \n3. Cambiar estado \n4. Reasignar pedido \n5. Salir");
    do
    {
        Console.Write("Seleccion: ");
        _ = int.TryParse(Console.ReadLine(), out seleccion);
    } while (seleccion < 1 || seleccion > 5);

    switch (seleccion)
    {
        case 1:
            cadeteria.AltaPedido();
            break;
        case 2:
            cadeteria.AsignarPedido();
            break;
        case 3:
            cadeteria.CambiarEstado();
            break;
        case 4:
            cadeteria.ReasignarPedido();
            break;
        case 5:
            Console.WriteLine("\nSaliendo...");
            break;
    }
}
