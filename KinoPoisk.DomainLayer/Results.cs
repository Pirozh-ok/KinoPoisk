namespace KinoPoisk.DomainLayer {
    public abstract class Result {
        public bool Success { get; protected set; }
        public bool Failure => !Success;
    }

    public class SuccessResult<T> : Result {
        public T Data { get; }

        public SuccessResult(T data) {
            Data = data;
            Success = true;
        }
    }

    public class ErrorResult : Result {
        public IEnumerable<string> Errors { get; }

        public ErrorResult(IEnumerable<string> errors) {
            Errors = errors;
            Success = false;
        }
    }
}
