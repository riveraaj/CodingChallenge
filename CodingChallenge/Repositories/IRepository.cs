namespace CodingChallenge.Repositories {
    public interface IRepository<T> {
        ICollection<T> GetAll();
        ICollection<T> GetAllFiltered();
        Task<ICollection<T>> GetAllAsync();
        Task<ICollection<T>> GetAllFilteredAsync();
    }
}