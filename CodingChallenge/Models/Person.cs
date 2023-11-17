using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.Models {
    public partial class Person {
        public int Id { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Age must be a positive number.")]
        public int Age { get; set; }
        public bool KnowHowtoDrive { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Country { get; set; } = null!;

        public List<Person> GetPersons() {
            List<Person> persons = new() {
                new Person {
                    Id = 1,
                    FirstName = "Michael", LastName = "Pitt",
                    Age = 32,
                    Country = "Germany",
                    KnowHowtoDrive = true
                 }, new Person {
                    Id = 2,
                    FirstName = "Sabrina", LastName = "Morales", Age = 6,
                    Country = "Ecuador",
                    KnowHowtoDrive = false
                 }, new Person {
                    Id = 3,
                    FirstName = "Rodrigo", LastName = "Vela",
                    Age = 54,
                    Country = "Peru",
                    KnowHowtoDrive = false
                 }, new Person {
                    Id = 4,
                    FirstName = "Lorena", LastName = "Perez", Age = 18,
                    Country = "Bolivia",
                    KnowHowtoDrive = true
                 }, new Person{
                    Id = 5,
                    FirstName = "Pablo", LastName = "Picasso", Age = 19,
                    Country = "Spain",
                    KnowHowtoDrive = true
                 }, new Person {
                    Id = 6,
                    FirstName = "Walter", LastName = "Misagi", Age = 17,
                    Country = "Japan",
                    KnowHowtoDrive = true
                 }
            };
            return persons;
        }
    }
}