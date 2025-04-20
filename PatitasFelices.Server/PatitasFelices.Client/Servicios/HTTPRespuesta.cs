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

    }
}
