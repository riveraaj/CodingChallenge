using CodingChallenge.Models;
using CodingChallenge.Repositories;

namespace CodingChallenge.Services {
    public class ChallengeService : IChallengeService {

        // Private field to store an instance of IRepository<Person>
        private readonly IRepository<Person> _personRepository;

        // Constructor to initialize the ChallengeService with an IRepository<Person> instance
        public ChallengeService(IRepository<Person> personRepository) => _personRepository = personRepository;

        // Method to determine if a given number is a multiple of 3, 5, both, or neither
        public string IsAMultiple(int number) =>
            (number % 5 == 0 && number % 3 == 0) ? "foo bar" :
            (number % 5 == 0) ? "foo" : (number % 3 == 0) ? "bar" : $"{number} is not a Multiple of 5 or 3";

        // Method to count the number of vowels in a given string
        public string HowManyVocals(string text) {
            // Check if the input string is null or empty, return "0" in that case
            if (string.IsNullOrEmpty(text)) return "0";
            // Trim and convert the input string to uppercase
            string newText = text.Trim().ToUpperInvariant();
            // Count the vowels in the modified string and return the count as a string
            return newText.Where(letter => IsAVowel(letter)).Count().ToString();
        }

        // Method to asynchronously get a filtered list of people from the repository
        public async Task<IEnumerable<Person>> GetPeople() => await _personRepository.GetAllFilteredAsync();

        // Method to check if a given character is a vowel
        public bool IsAVowel(char letter) => (letter == 'A' || letter == 'E' || letter == 'I' || letter == 'O' || letter == 'U');
    }
}