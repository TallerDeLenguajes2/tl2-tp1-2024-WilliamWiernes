namespace EspacioClases
{
    public enum EstadoPedido
    {
        Entregado,
        Espera,
        Cancelado
    }

    public class Pedidos
    {
        private string numPedido;
        private string observacion;
        private Cliente cliente;
        private EstadoPedido estado;

        public Pedidos(string numPedido, string observacion, EstadoPedido estado, string cliNombre, string cliDireccion, string cliTelefono, string cliIndicacionesDireccion)
        {
            this.numPedido = numPedido;
            this.observacion = observacion;
            cliente = new Cliente(cliNombre, cliDireccion, cliTelefono, cliIndicacionesDireccion);
            this.estado = estado;
        }
    }
}