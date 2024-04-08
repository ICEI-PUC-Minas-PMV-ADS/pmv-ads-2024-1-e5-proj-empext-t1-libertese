namespace Libertese.Data
{
    public class OperationResult
    {
        public OperationResult()
        {
            Errors = new List<string>();
            Error = false;
        }

        public object? Data { get; set; }
        public string? Message { get; set; }
        public List<string> Errors { get; set; }
        public bool Error { get; set; }
    }
}
