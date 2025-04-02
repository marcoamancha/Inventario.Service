namespace Inventario.Service.Dominio.General
{
    /// <summary>
    /// Clase respuesta para respuesta general
    /// </summary>
    /// <typeparam name="T">Tipo de dato</typeparam>
    public class InventarioRespuesta<T>
    {
        public bool Exitoso { get; set; }
        public T Datos { get; set; }
        public bool HuboError { get; set; }
        public string Mensaje { get; set; }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="datos">Dato de resouesta</param>
        /// <param name="exitoso">Indica si ka respuesta es exitosa</param>
        /// <param name="mensaje">Mensaje de respuesta</param>
        public InventarioRespuesta(T datos, bool exitoso = true, string mensaje = "")
        {
            Exitoso = exitoso;
            Datos = datos;
            HuboError = !exitoso;
            Mensaje = mensaje;
        }
    }
}
