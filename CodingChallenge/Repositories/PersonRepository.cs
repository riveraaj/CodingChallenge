using CodingChallenge.Models;

namespace CodingChallenge.Repositories
{
    public class PersonRepository : IRepository<Person> {

        // Private field to store an instance of the Person class
        private readonly Person _person;

        // Constructor to initialize the PersonRepository with an instance of the Person class
        public PersonRepository(Person oPerson) => _person = oPerson ?? throw new ArgumentNullException(nameof(oPerson));

        // Method to get all persons from the stored Person instance
        public ICollection<Person> GetAll() => _person.GetPersons();
        // Method to get a filtered list of persons (age >= 18 and know how to drive)
        public ICollection<Person> GetAllFiltered() => GetAll().Where(x => x.Age >= 18 && x.KnowHowtoDrive).ToList();
        // Method to asynchronously get all persons from the stored Person instance
        public async Task<ICollection<Person>> GetAllAsync() => await Task.FromResult(GetAll());
        // Method to asynchronously get a filtered list of persons (age >= 18 and know how to drive)
        public async Task<ICollection<Person>> GetAllFilteredAsync() => await Task.FromResult(GetAllFiltered());
    }
}