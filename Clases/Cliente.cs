namespace EspacioClases
{
    public class Cliente
    {
        private string nombre;
        private string direccion;
        private string telefono;
        private string indicacionesDireccion;

        public Cliente(string nombre, string direccion, string telefono, string indicacionesDireccion)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.indicacionesDireccion = indicacionesDireccion;
        }
    }
}