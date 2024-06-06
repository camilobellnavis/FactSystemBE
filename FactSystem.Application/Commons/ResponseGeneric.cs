using FluentValidation.Results;

namespace FactSystem.Application.Commons
{
    public class ResponseGeneric<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public string? Token { get; set; }
        public IEnumerable<ValidationFailure>? Errors { get; set; }
    }
}
