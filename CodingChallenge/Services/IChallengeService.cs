using CodingChallenge.Models;

namespace CodingChallenge.Services {
    public interface IChallengeService {
        string IsAMultiple(int number);
        string HowManyVocals(string text);
        Task<IEnumerable<Person>> GetPeople();
        bool IsAVowel(char letter);
    }
}