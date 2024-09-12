using System.ComponentModel;

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

        public int VerContNumPedido
        {
            get { return contNumPedido; }
        }

        public List<Pedido> VerListaPedidos
        {
            get { return listaPedidos; }
        }

        public void AltaPedido(string observacion, string cliNombre, string cliDireccion, string cliTelefono, string cliIndicacionesDireccion)
        {
            var pedidoAux = new Pedido(contNumPedido, observacion, EstadoPedido.Espera, cliNombre, cliDireccion, cliTelefono, cliIndicacionesDireccion);
            listaPedidos.Add(pedidoAux);
            contNumPedido++;
        }

        public void AsignarCadeteAPedido(int idCadete, int numPedido)
        {
            listaPedidos[numPedido].VerCadete = listaCadetes[idCadete];
        }

        public void CambiarEstado(int numPedido, int seleccionEstado)
        {
            switch (seleccionEstado)
            {
                case 1:
                    listaPedidos[numPedido].VerEstado = EstadoPedido.Entregado;
                    break;
                case 2:
                    listaPedidos[numPedido].VerEstado = EstadoPedido.Espera;
                    break;
                case 3:
                    listaPedidos[numPedido].VerEstado = EstadoPedido.Cancelado;
                    break;
            }
        }

        public void ReasignarCadete(int idCadete, int numPedido)
        {
            listaPedidos[numPedido].VerCadete = listaCadetes[idCadete];
        }

        public string GenerarInforme(int idCadete)
        {
            var monto = JornalACobrar(idCadete);
            var cantidadPedidos = CantidadDePedidosPorCadete(idCadete);
            var cantidadPedidosEntregados = CantidadPedidosEntregados(idCadete);
            var enviosProm = (double)cantidadPedidosEntregados / ((cantidadPedidos == 0) ? 1 : cantidadPedidos); // Para solucionar problema con NaN

            return $"\n{listaCadetes[idCadete].VerDatos}\n\tCantidad de envíos: {cantidadPedidos} | Monto ganado: ${monto:F2} | Envíos promedio: {enviosProm:F2}";
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