using EspacioClases;

namespace EspacioMenu
{

    public abstract class Menu
    {
        static public void Opcion1(Cadeteria cadeteria)
        {
            Console.WriteLine($"\nPedido N° {cadeteria.VerContNumPedido}:");
            Console.Write("\tIngrese una observación: ");
            var observacion = Console.ReadLine();

            Console.WriteLine("Ingrese los datos del Cliente:");
            Console.Write("\tNombre: ");
            var cliNombre = Console.ReadLine();

            Console.Write("\tDirección: ");
            var cliDireccion = Console.ReadLine();

            Console.Write("\tTeléfono: ");
            var cliTelefono = Console.ReadLine();

            Console.Write("\tIndicaciones dirección: ");
            var cliIndicacionesDireccion = Console.ReadLine();

            cadeteria.AltaPedido(observacion, cliNombre, cliDireccion, cliTelefono, cliIndicacionesDireccion);

            Console.WriteLine($"El Pedido N° {cadeteria.VerContNumPedido - 1} se ha añadido a la lista Correctamente.");
        }

        static public void Opcion2(Cadeteria cadeteria)
        {
            Console.WriteLine("Pedidos:");
            if (cadeteria.VerListaPedidos.Count != 0)
            {
                // Se muestran únicamente pedidos que no tienen un Cadete asignado
                foreach (var pedido in cadeteria.VerListaPedidos)
                {
                    if (pedido.VerCadete == null)
                        Console.WriteLine($"\tNúmero: {pedido.VerNumPedido} | Estado: {pedido.VerEstado}");
                }

                int idCadete;
                do
                {
                    Console.Write("\nIngresa el Id del Cadete a Asignar: ");
                    _ = int.TryParse(Console.ReadLine(), out idCadete);
                } while (idCadete < 0 || idCadete > cadeteria.VerListaCadetes.Count);

                int numPedido;
                do
                {
                    Console.Write("\nIngrese el N° de Pedido que recibe el Cadete: ");
                    _ = int.TryParse(Console.ReadLine(), out numPedido);
                } while (numPedido < 0 || numPedido > cadeteria.VerContNumPedido - 1);

                // No se puede Asignar un Cadete si el Pedido ya tiene uno
                if (cadeteria.VerListaPedidos[numPedido].VerCadete == null)
                {
                    cadeteria.AsignarCadeteAPedido(idCadete, numPedido);

                    var cadeteAux = cadeteria.VerListaPedidos[numPedido].VerCadete;
                    var pedidoAux = cadeteria.VerListaPedidos[numPedido];
                    Console.WriteLine($"El Cadete Id {cadeteAux.VerId} fue Asignado correctamente al Pedido {pedidoAux.VerNumPedido}.");
                }
                else
                {
                    Console.WriteLine("Este Pedido ya tiene un Cadete! Use la función para Reasignar Cadetes.");
                }
            }
            else
            {
                Console.WriteLine("\tNo hay pedidos!");
            }
        }

        static public void Opcion3(Cadeteria cadeteria)
        {
            Console.WriteLine("Pedidos:");
            if (cadeteria.VerListaPedidos.Count != 0)
            {
                foreach (var pedido in cadeteria.VerListaPedidos)
                {
                    Console.WriteLine($"\tNúmero: {pedido.VerNumPedido} | Estado: {pedido.VerEstado} | Id Cadete: {pedido.VerCadete.VerId}");
                }

                int numPedido;
                do
                {
                    Console.Write("\nIngrese el N° de Pedido a Cambiar el Estado: ");
                    _ = int.TryParse(Console.ReadLine(), out numPedido);
                } while (numPedido < 0 || numPedido > cadeteria.VerContNumPedido - 1);

                int seleccionEstado;
                Console.WriteLine("1. Entregado \n2. Espera \n3. Cancelado");
                do
                {
                    Console.Write("Seleccion: ");
                    _ = int.TryParse(Console.ReadLine(), out seleccionEstado);
                } while (seleccionEstado < 1 || seleccionEstado > 3);

                cadeteria.CambiarEstado(numPedido, seleccionEstado);

                var pedidoAux = cadeteria.VerListaPedidos[numPedido];
                Console.WriteLine($"El estado del Pedido N° {pedidoAux.VerNumPedido} ha sido cambiado a {pedidoAux.VerEstado}.");
            }
            else
            {
                Console.WriteLine("\tNo hay pedidos!");
            }
        }

        static public void Opcion4(Cadeteria cadeteria)
        {
            Console.WriteLine("Pedidos:");
            if (cadeteria.VerListaPedidos.Count != 0)
            {
                foreach (var pedido in cadeteria.VerListaPedidos)
                {
                    Console.WriteLine($"\tNúmero: {pedido.VerNumPedido} | Estado: {pedido.VerEstado} | Id Cadete: {pedido.VerCadete.VerId}");
                }

                int idCadete;
                do
                {
                    Console.Write("\nIngresa el Id del Cadete a Reasignar: ");
                    _ = int.TryParse(Console.ReadLine(), out idCadete);
                } while (idCadete < 0 || idCadete > cadeteria.VerListaCadetes.Count);

                int numPedido;
                do
                {
                    Console.Write("\nIngrese el N° de Pedido que recibe el Cadete: ");
                    _ = int.TryParse(Console.ReadLine(), out numPedido);
                } while (numPedido < 0 || numPedido > cadeteria.VerContNumPedido - 1);

                cadeteria.ReasignarCadete(idCadete, numPedido);

                var cadeteAux = cadeteria.VerListaCadetes[idCadete];
                var pedidoAux = cadeteria.VerListaPedidos[numPedido];
                Console.WriteLine($"El Cadete Id {cadeteAux.VerId} fue Reasignado correctamente al Pedido {pedidoAux.VerNumPedido}.");
            }
            else
            {
                Console.WriteLine("\tNo hay pedidos!");
            }
        }

        static public void InformeJornada(Cadeteria cadeteria)
        {
            Console.WriteLine("Informe de la Jornada:");
            if (cadeteria.VerListaPedidos.Count != 0)
            {
                foreach (var cadete in cadeteria.VerListaCadetes)
                {
                    Console.WriteLine(cadeteria.GenerarInforme(cadete.VerId));
                }

                var totalEnvios = cadeteria.VerListaPedidos.Count;
                var montoTotal = cadeteria.VerListaCadetes.Sum(cadete => cadeteria.JornalACobrar(cadete.VerId));

                Console.WriteLine($"\nTotal de envíos: {totalEnvios}");
                Console.WriteLine($"Monto total: ${montoTotal}");
            }
            else
            {
                Console.WriteLine("\tNo hay pedidos!");
            }
        }
    }
}