namespace GH.Domain.Dto
{
    public class ResultDto<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}

