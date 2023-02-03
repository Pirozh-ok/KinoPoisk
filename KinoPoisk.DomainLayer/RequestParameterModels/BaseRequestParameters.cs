namespace KinoPoisk.DomainLayer.RequestParameterModels {
    public class BaseRequestParameters {
        public BaseRequestParameters() { }

        public uint PageNumber { get; set; } = 1;
        public uint PageSize {
            get => _pageSize;
            set {
                _pageSize = value > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : value;
            }
        }

        public string? Filters { get; set; }
        public string Sorting { get; set; } = "+name"; 

        private const uint MAX_PAGE_SIZE = 30;
        private uint _pageSize = MAX_PAGE_SIZE;
    }
}
