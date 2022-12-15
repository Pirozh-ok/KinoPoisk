namespace KinoPoisk.DomainLayer {
    public class Result {
        public bool Success { get; private set; }
        public List<string> Errors { get; private set; }

        public bool Failure {
            get { return !Success; }
        }

        protected Result(bool success, List<string> errors) {
            Success = success;
            Errors = errors;
        }

        public static Result Fail(string message) {
            return new Result(false, new List<string> { message });
        }

        public static Result Fail(List<string> errors) {
            return new Result(false, errors);
        }

        public static Result Ok() {
            return new Result(true, new List<string>());
        }

        public static Result<T> Ok<T>(T? value) {
            return new Result<T>(value, true, new List<string>());
        }
    }

    public class Result<T> : Result {
        public T Value { get; private set; } 

        protected internal Result(T? value, bool success, string error)
            : base(success, new List<string>() { error } ) {
            Value = value;
        }

        protected internal Result(T? value, bool success, List<string> errors)
            : base(success, errors ) {
            Value = value;
        }
    }
}
