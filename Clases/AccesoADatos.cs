using System.Text.Json;
using EspacioClases;

namespace EspacioDatos
{
    public abstract class AccesoADatos
    {
        public abstract void CargarDatosCadeteria(string nombreArchivo, Cadeteria cadeteria);
        public abstract void CargarDatosCadetes(string nombreArchivo, Cadeteria cadeteria);
    }

    public class AccesoCSV : AccesoADatos
    {
        public override void CargarDatosCadeteria(string nombreArchivo, Cadeteria cadeteria)
        {
            var arregloCadeteria = File.ReadAllText(nombreArchivo).Split(",");
            cadeteria.VerNombre = arregloCadeteria[0];
            cadeteria.VerTelefono = arregloCadeteria[1];
        }

        public override void CargarDatosCadetes(string nombreArchivo, Cadeteria cadeteria)
        {
            var arregloLineas = File.ReadAllLines(nombreArchivo);
            foreach (var linea in arregloLineas)
            {
                var arregloCadete = linea.Split(",");
                var cadete = new Cadete(int.Parse(arregloCadete[0]), arregloCadete[1], arregloCadete[2], arregloCadete[3]);
                cadeteria.VerListaCadetes.Add(cadete);
            }
        }
    }

    public class AccesoJSON : AccesoADatos
    {
        public override void CargarDatosCadeteria(string nombreArchivo, Cadeteria cadeteria)
        {
            using (var archivo = new FileStream(nombreArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivo))
                {
                    string listaCadeteriaJson = strReader.ReadToEnd();
                    archivo.Close();

                    var datosCadeteria = JsonSerializer.Deserialize<Cadeteria>(listaCadeteriaJson);

                    cadeteria.VerNombre = datosCadeteria.VerNombre;
                    cadeteria.VerTelefono = datosCadeteria.VerTelefono;
                }
            }
        }

        public override void CargarDatosCadetes(string nombreArchivo, Cadeteria cadeteria)
        {
            using (var archivo = new FileStream(nombreArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivo))
                {
                    string listaCadetesJson = strReader.ReadToEnd();
                    archivo.Close();

                    cadeteria.VerListaCadetes = JsonSerializer.Deserialize<List<Cadete>>(listaCadetesJson);
                }
            }
        }
    }
}