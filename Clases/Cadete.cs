namespace EspacioClases
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;
        private List<Pedido> listaPedidos;

        public Cadete(int id, string nombre, string direccion, string telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            listaPedidos = new List<Pedido>();
        }

        public string VerDatos
        {
            get { return $"{id} | {nombre} | {direccion} | {telefono}"; }
        }

        public List<Pedido> VerLista
        {
            get { return listaPedidos; }
        }

        public int JornalACobrar()
        {
            return 500 * CantidadPedidosEntregados();
        }

        public int CantidadPedidosEntregados()
        {
            int cantidad = 0;

            foreach (var pedido in listaPedidos)
            {
                if (pedido.VerEstado == EstadoPedido.Entregado)
                    cantidad++;
            }

            return cantidad;
        }
    }
}