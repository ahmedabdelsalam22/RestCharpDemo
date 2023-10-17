namespace RestCharpCourse.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<T> UpdateAsync(string url,T data);
        Task PostAsync(string url, T data);
        Task<List<T>> GetAsync(string url);
        Task Delete(string url);
    }
}
