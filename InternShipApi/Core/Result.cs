namespace InternShipApi.Core
{
    public class Result<T>
    {
        public string Message { get; set; }
        public T  Data { get; set; }
        public bool Success { get; set; }
    }
}
