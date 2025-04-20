namespace PatitasFelices.Client.Servicios
{
    public class HTTPRespuesta<T>
    {
        public T respuesta { get; }

        public bool Error { get; }

        public HttpResponseMessage httpResponseMessage { get; set; }

        public HTTPRespuesta(T respuesta, bool error, HttpResponseMessage httpResponseMessage)
        {
            this.respuesta = respuesta;
            Error = error;
            this.httpResponseMessage = httpResponseMessage;
        }

    }
}
