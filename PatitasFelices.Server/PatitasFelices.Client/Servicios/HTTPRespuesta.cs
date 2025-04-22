namespace PatitasFelices.Client.Servicios
{
    public class HTTPRespuesta<T>
    {
        public T Respuesta { get; }

        public bool Error { get; }

        public HttpResponseMessage httpResponseMessage { get; set; }

        public HTTPRespuesta(T respuesta, bool error, HttpResponseMessage httpResponseMessage)
        {
            this.Respuesta = respuesta;
            Error = error;
            this.httpResponseMessage = httpResponseMessage;
        

        }


        public async Task<string> ObtenerError()
        {
            if (!Error)
            {
                return "";
            }

            var statuscode = httpResponseMessage.StatusCode;

            switch (statuscode)
            {
                case System.Net.HttpStatusCode.BadRequest:
                    return httpResponseMessage.Content.ReadAsStringAsync().ToString()!;
                //                    return "Error, no se puede procesar la información";
                case System.Net.HttpStatusCode.Unauthorized:
                    return "Error, no está logueado";
                case System.Net.HttpStatusCode.Forbidden:
                    return "Error, no tiene autorización a ejecutar este proceso";
                case System.Net.HttpStatusCode.NotFound:
                    return "Error, dirección no encontrado";
                default:
                    return httpResponseMessage.Content.ReadAsStringAsync().Result;
            }
        }

    }




}
