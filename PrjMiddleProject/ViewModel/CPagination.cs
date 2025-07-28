namespace PrjMiddleProject.ViewModels
{
    public static class CPagination
    {
        public static IEnumerable<T> Paginate<T>(IEnumerable<T> source, int page, int pageSize, out int totalPages)
        {
            int totalCount = source.Count();
            totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
