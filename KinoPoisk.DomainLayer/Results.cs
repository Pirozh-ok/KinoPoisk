namespace KinoPoisk.DomainLayer {
    public class ServiceResult {
        public bool Success { get; private set; }
        public List<string> Errors { get; private set; }

        public bool Failure {
            get { return !Success; }
        }

        protected ServiceResult(bool success, List<string> errors) {
            Success = success;
            Errors = errors;
        }

        public static ServiceResult Fail(string message) {
            return new ServiceResult(false, new List<string> { message });
        }

        public static ServiceResult Fail(List<string> errors) {
            return new ServiceResult(false, errors);
        }

        public static ServiceResult<T> Fail<T>(T? value, string message) {
            return new ServiceResult<T>(value, false, message);
        }

        public static ServiceResult Ok() {
            return new ServiceResult(true, new List<string>());
        }

        public static ServiceResult<T> Ok<T>(T? value) {
            return new ServiceResult<T>(value, true, new List<string>());
        }

        public static ServiceResult InternalServerError() {
            return Fail("Internal server error");
        }
    }

    public class ServiceResult<T> : ServiceResult {
        public T Value { get; private set; } 

        protected internal ServiceResult(T? value, bool success, string error)
            : base(success, new List<string>() { error } ) {
            Value = value;
        }

        protected internal ServiceResult(T? value, bool success, List<string> errors)
            : base(success, errors ) {
            Value = value;
        }

        public static ServiceResult<T> InternalServerError() {
            return new ServiceResult<T>(false, "Internal server error");
        }
    }
}
