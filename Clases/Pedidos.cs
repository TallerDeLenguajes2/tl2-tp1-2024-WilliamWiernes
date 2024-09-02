namespace EspacioClases
{
    public enum EstadoPedido
    {
        Entregado,
        Espera,
        Cancelado
    }

    public class Pedido
    {
        private int numPedido;
        private string observacion;
        private Cliente cliente;
        private EstadoPedido estado;
        private Cadete cadete;

        public Pedido(int numPedido, string observacion, EstadoPedido estado, string cliNombre, string cliDireccion, string cliTelefono, string cliIndicacionesDireccion)
        {
            this.numPedido = numPedido;
            this.observacion = observacion;
            cliente = new Cliente(cliNombre, cliDireccion, cliTelefono, cliIndicacionesDireccion);
            this.estado = estado;
        }

        public EstadoPedido VerEstado
        {
            get { return estado; }
            set { estado = value; }
        }

        public int VerNumPedido
        {
            get { return numPedido; }
        }

        public Cadete VerCadete
        {
            get { return cadete; }
            set { cadete = value; }
        }
    }
}