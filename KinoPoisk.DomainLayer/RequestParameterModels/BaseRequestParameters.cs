namespace KinoPoisk.DomainLayer.RequestParameterModels {
    public class BaseRequestParameters {
        public BaseRequestParameters() { }

        public int PageNumber { get; set; } = 1;
        public int PageSize {
            get => _pageSize;
            set {
                _pageSize = value > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : value;
            }
        }

        public string? Filters { get; set; }
        public string? Sorting { get; set; }

        private const int MAX_PAGE_SIZE = 30;
        private int _pageSize = MAX_PAGE_SIZE;
    }
}
