namespace EspacioClases
{
    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Cadete> listaCadetes;
        private Pedido pedidoAux;
        private bool pedidoCreado;
        private int contNumPedido;

        public Cadeteria()
        {
            listaCadetes = new List<Cadete>();
            pedidoAux = null;
            pedidoCreado = false;
            contNumPedido = 0;
        }

        public List<Cadete> VerLista
        {
            get { return listaCadetes; }
        }

        public string VerDatos
        {
            get { return $"{nombre} | {telefono}"; }
        }

        public void CargarDatosCadeteriaCSV(string nombreArchivo)
        {
            var arregloCadeteria = File.ReadAllText(nombreArchivo).Split(",");
            nombre = arregloCadeteria[0];
            telefono = arregloCadeteria[1];
        }

        public void CargarDatosCadetesCSV(string nombreArchivo)
        {
            var arregloLineas = File.ReadAllLines(nombreArchivo);
            foreach (var linea in arregloLineas)
            {
                var arregloCadete = linea.Split(",");
                var cadete = new Cadete(int.Parse(arregloCadete[0]), arregloCadete[1], arregloCadete[2], arregloCadete[3]);
                listaCadetes.Add(cadete);
            }
        }

        public void AltaPedido()
        {
            if (!pedidoCreado)
            {
                int numPedido = contNumPedido;
                contNumPedido++;

                Console.WriteLine($"\nPedido N° {numPedido}:");
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

                pedidoAux = new Pedido(numPedido, observacion, EstadoPedido.Espera, cliNombre, cliDireccion, cliTelefono, cliIndicacionesDireccion);
                pedidoCreado = true;

                Console.WriteLine($"El Pedido N° {numPedido} se ha creado Correctamente.");
            }
            else
            {
                Console.WriteLine("Asigna el Pedido pendiente antes de crear otro!");
            }
        }

        public void AsignarPedido()
        {
            if (pedidoAux != null)
            {
                int idSeleccion;
                do
                {
                    Console.Write("\nIngresa el Id del Cadete: ");
                    _ = int.TryParse(Console.ReadLine(), out idSeleccion);
                } while (idSeleccion < 0 || idSeleccion > listaCadetes.Count);

                var cadete = listaCadetes[idSeleccion];
                cadete.VerLista.Add(pedidoAux);

                Console.WriteLine($"El Pedido N° {pedidoAux.VerNumPedido} fue asignado al Cadete con Id {idSeleccion} correctamente.");

                pedidoAux = null;
                pedidoCreado = false;
            }
            else
            {
                Console.WriteLine("Crea un Pedido antes de asignarlo!");
            }
        }

        public void CambiarEstado()
        {
            foreach (var cadete in listaCadetes)
            {
                Console.WriteLine($"\n{cadete.VerDatos} \nPedidos:");
                if (cadete.VerLista.Count != 0)
                {
                    foreach (var pedido in cadete.VerLista)
                    {
                        Console.WriteLine($"\tNúmero: {pedido.VerNumPedido} | Estado: {pedido.VerEstado}");
                    }
                }
                else
                {
                    Console.WriteLine("\tNo hay pedidos!");
                }
            }

            int numPedido;
            do
            {
                Console.Write("\nIngrese el N° de Pedido a Cambiar el Estado: ");
                _ = int.TryParse(Console.ReadLine(), out numPedido);
            } while (numPedido < 0 || numPedido > contNumPedido - 1);

            int seleccion;
            Console.WriteLine("1. Entregado \n2. Espera \n3. Cancelado");
            do
            {
                Console.Write("Seleccion: ");
                _ = int.TryParse(Console.ReadLine(), out seleccion);
            } while (seleccion < 1 || seleccion > 3);

            var cadeteConPedido = listaCadetes.Find(cadete => cadete.VerLista.Any(pedido => pedido.VerNumPedido == numPedido));
            var pedidoEstado = cadeteConPedido.VerLista.Find(pedido => pedido.VerNumPedido == numPedido);

            switch (seleccion)
            {
                case 1:
                    pedidoEstado.VerEstado = EstadoPedido.Entregado;
                    break;
                case 2:
                    pedidoEstado.VerEstado = EstadoPedido.Espera;
                    break;
                case 3:
                    pedidoEstado.VerEstado = EstadoPedido.Cancelado;
                    break;
            }

            Console.WriteLine($"El estado del Pedido N° {numPedido} ha sido cambiado a {pedidoEstado.VerEstado}.");
        }

        public void ReasignarPedido()
        {
            foreach (var cadete in listaCadetes)
            {
                Console.WriteLine($"\n{cadete.VerDatos} \nPedidos:");
                if (cadete.VerLista.Count != 0)
                {
                    foreach (var pedido in cadete.VerLista)
                    {
                        Console.WriteLine($"\tNúmero: {pedido.VerNumPedido} | Estado: {pedido.VerEstado}");
                    }
                }
                else
                {
                    Console.WriteLine("\tNo hay pedidos!");
                }
            }

            int numPedido;
            do
            {
                Console.Write("\nIngrese el N° de Pedido a Reasignar: ");
                _ = int.TryParse(Console.ReadLine(), out numPedido);
            } while (numPedido < 0 || numPedido > contNumPedido - 1);

            int idSeleccion;
            do
            {
                Console.Write("\nIngresa el Id del Cadete que recibe el Pedido: ");
                _ = int.TryParse(Console.ReadLine(), out idSeleccion);
            } while (idSeleccion < 0 || idSeleccion > listaCadetes.Count);

            var cadetePierde = listaCadetes.Find(cadete => cadete.VerLista.Any(pedido => pedido.VerNumPedido == numPedido));
            var pedidoReasignado = cadetePierde.VerLista.Find(pedido => pedido.VerNumPedido == numPedido);
            var cadeteRecibe = listaCadetes[idSeleccion];

            cadeteRecibe.VerLista.Add(pedidoReasignado);
            cadetePierde.VerLista.Remove(pedidoReasignado);

            Console.WriteLine($"El Pedido N° {numPedido} fue Reasignado correctamente.");
        }

        public void GenerarInforme()
        {
            Console.WriteLine("Informe de la Jornada:");

            foreach (var cadete in listaCadetes)
            {
                var monto = cadete.JornalACobrar();
                var enviosProm = (cadete.VerLista.Count == 0) ? 0 : (double)cadete.CantidadPedidosEntregados() / cadete.VerLista.Count;

                Console.WriteLine($"\n{cadete.VerDatos}");
                Console.WriteLine($"\tCantidad de envíos: {cadete.VerLista.Count}");
                Console.WriteLine($"\tMonto ganado: ${monto:F2}");
                Console.WriteLine($"\tEnvíos promedio: {enviosProm:F2}");
            }

            var totalEnvios = listaCadetes.Sum(cadete => cadete.VerLista.Count);
            var montoTotal = listaCadetes.Sum(cadete => cadete.JornalACobrar());

            Console.WriteLine($"\nTotal de envíos: {totalEnvios}");
            Console.WriteLine($"Monto total: ${montoTotal}");
        }
    }
}