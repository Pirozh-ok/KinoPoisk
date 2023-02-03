namespace KinoPoisk.DomainLayer.RequestParameterModels {
    public class PagedList<T> : List<T>{
        public uint CurrentPage { get; private set; }
        public uint TotalPages { get; private set; }
        public uint PageSize { get; private set; }
        public uint TotalCount { get; private set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public PagedList(IEnumerable<T> items, uint count, uint pageNumber, uint pageSize) {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (uint)Math.Ceiling(count/(double)pageSize);
            AddRange(items);
        }
    }
}
