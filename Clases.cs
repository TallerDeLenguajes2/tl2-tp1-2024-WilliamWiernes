namespace EspacioClases
{
    enum EstadoPedido
    {
        Entregado,
        Espera,
        Cancelado
    }

    public class Cliente
    {
        private string nombre;
        private string direccion;
        private string telefono;

        public Cliente(string nombre, string direccion, string telefono)
        {
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }

    public class Pedidos
    {
        private string numPedido;
        private string observacion;
        private Cliente cliente;
        private string estado;

        public Pedidos(string numPedido, string observacion, Cliente cliente, string estado)
        {
            NumPedido = numPedido;
            Observacion = observacion;
            Cliente = cliente;
            Estado = estado;
        }

        public string NumPedido { get => numPedido; set => numPedido = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public string Estado { get => estado; set => estado = value; }
    }

    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;
        private List<Pedidos> listaPedidos;

        public Cadete(int id, string nombre, string direccion, string telefono, List<Pedidos> listaPedidos)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            ListaPedidos = listaPedidos;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Pedidos> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }
    }

    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Cadete> listaCadetes;

        public Cadeteria(string nombre, string telefono, List<Cadete> listaCadetes)
        {
            Nombre = nombre;
            Telefono = telefono;
            ListaCadetes = listaCadetes;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
    }
}