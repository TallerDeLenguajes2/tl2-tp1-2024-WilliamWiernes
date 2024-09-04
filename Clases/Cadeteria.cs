namespace EspacioClases
{
    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Cadete> listaCadetes;
        private int contNumPedido;
        private List<Pedido> listaPedidos;

        public Cadeteria()
        {
            listaCadetes = new List<Cadete>();
            contNumPedido = 0;
            listaPedidos = new List<Pedido>();
        }

        public List<Cadete> VerListaCadetes
        {
            get { return listaCadetes; }
            set { listaCadetes = value; }
        }

        public string VerDatos
        {
            get { return $"{nombre} | {telefono}"; }
        }

        public string VerNombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string VerTelefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public void AltaPedido()
        {
            var numPedido = contNumPedido;
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

            var pedidoAux = new Pedido(numPedido, observacion, EstadoPedido.Espera, cliNombre, cliDireccion, cliTelefono, cliIndicacionesDireccion);

            listaPedidos.Add(pedidoAux);

            Console.WriteLine($"El Pedido N° {numPedido} se ha añadido a la lista Correctamente.");
        }

        public void AsignarPedido()
        {
            Console.WriteLine("Pedidos:");
            if (listaPedidos.Count != 0)
            {
                foreach (var pedido in listaPedidos)
                {
                    if (pedido.VerCadete == null)
                        Console.WriteLine($"\tNúmero: {pedido.VerNumPedido} | Estado: {pedido.VerEstado}");
                }

                int idCadete;
                do
                {
                    Console.Write("\nIngresa el Id del Cadete a Asignar: ");
                    _ = int.TryParse(Console.ReadLine(), out idCadete);
                } while (idCadete < 0 || idCadete > listaCadetes.Count);

                int numPedido;
                do
                {
                    Console.Write("\nIngrese el N° de Pedido que recibe el Cadete: ");
                    _ = int.TryParse(Console.ReadLine(), out numPedido);
                } while (numPedido < 0 || numPedido > contNumPedido - 1);

                if (listaPedidos[numPedido].VerCadete == null)
                {
                    AsignarCadeteAPedido(idCadete, numPedido);
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

        private void AsignarCadeteAPedido(int idCadete, int numPedido)
        {
            listaPedidos[numPedido].VerCadete = listaCadetes[idCadete];

            var cadete = listaPedidos[numPedido].VerCadete;
            var pedido = listaPedidos[numPedido];

            Console.WriteLine($"El Cadete Id {cadete.VerId} fue Asignado correctamente al Pedido {pedido.VerNumPedido}.");
        }

        public void CambiarEstado()
        {
            Console.WriteLine("Pedidos:");
            if (listaPedidos.Count != 0)
            {
                foreach (var pedido in listaPedidos)
                {
                    Console.WriteLine($"\tNúmero: {pedido.VerNumPedido} | Estado: {pedido.VerEstado} | Id Cadete: {pedido.VerCadete.VerId}");
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

                var pedidoEstado = listaPedidos[numPedido];

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
            else
            {
                Console.WriteLine("\tNo hay pedidos!");
            }
        }

        public void ReasignarCadete()
        {
            Console.WriteLine("Pedidos:");
            if (listaPedidos.Count != 0)
            {
                foreach (var pedido in listaPedidos)
                {
                    Console.WriteLine($"\tNúmero: {pedido.VerNumPedido} | Estado: {pedido.VerEstado} | Id Cadete: {pedido.VerCadete.VerId}");
                }

                int idCadete;
                do
                {
                    Console.Write("\nIngresa el Id del Cadete a Reasignar: ");
                    _ = int.TryParse(Console.ReadLine(), out idCadete);
                } while (idCadete < 0 || idCadete > listaCadetes.Count);

                int numPedido;
                do
                {
                    Console.Write("\nIngrese el N° de Pedido que recibe el Cadete: ");
                    _ = int.TryParse(Console.ReadLine(), out numPedido);
                } while (numPedido < 0 || numPedido > contNumPedido - 1);

                listaPedidos[numPedido].VerCadete = listaCadetes[idCadete];

                Console.WriteLine($"El Cadete Id {listaCadetes[idCadete].VerId} fue Reasignado correctamente al Pedido {listaPedidos[numPedido].VerNumPedido}.");
            }
            else
            {
                Console.WriteLine("\tNo hay pedidos!");
            }
        }

        public void GenerarInforme()
        {
            Console.WriteLine("Informe de la Jornada:");

            if (listaPedidos.Count != 0)
            {
                foreach (var cadete in listaCadetes)
                {
                    var monto = JornalACobrar(cadete.VerId);
                    var cantidadPedidos = (CantidadDePedidosPorCadete(cadete.VerId) == 0) ? 1 : CantidadDePedidosPorCadete(cadete.VerId);
                    var cantidadPedidosEntregados = CantidadPedidosEntregados(cadete.VerId);
                    var enviosProm = (double)cantidadPedidosEntregados / cantidadPedidos;

                    Console.WriteLine($"\n{cadete.VerDatos}");
                    Console.WriteLine($"\tCantidad de envíos: {cantidadPedidos}");
                    Console.WriteLine($"\tMonto ganado: ${monto:F2}");
                    Console.WriteLine($"\tEnvíos promedio: {enviosProm:F2}");
                }

                var totalEnvios = listaPedidos.Count;
                var montoTotal = listaCadetes.Sum(cadete => JornalACobrar(cadete.VerId));

                Console.WriteLine($"\nTotal de envíos: {totalEnvios}");
                Console.WriteLine($"Monto total: ${montoTotal}");
            }
            else
            {
                Console.WriteLine("\tNo hay pedidos!");
            }
        }

        public int JornalACobrar(int idCadete)
        {
            return 500 * CantidadPedidosEntregados(idCadete);
        }

        private int CantidadPedidosEntregados(int idCadete)
        {
            int cantidad = 0;

            foreach (var pedido in listaPedidos)
            {
                if (pedido.VerCadete.VerId == idCadete)
                    if (pedido.VerEstado == EstadoPedido.Entregado)
                        cantidad++;
            }

            return cantidad;
        }

        private int CantidadDePedidosPorCadete(int idCadete)
        {
            var cantidad = 0;

            foreach (var pedido in listaPedidos)
            {

                if (pedido.VerCadete.VerId == idCadete)
                    cantidad++;
            }

            return cantidad;
        }
    }
}