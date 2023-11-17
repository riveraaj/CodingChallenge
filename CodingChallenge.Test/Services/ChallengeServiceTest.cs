using CodingChallenge.Models;
using CodingChallenge.Repositories;
using CodingChallenge.Services;
using FakeItEasy;
using FluentAssertions;

namespace CodingChallenge.Test.Services {
    public class ChallengeServiceTest {

        [Fact]
        public void ChallengeService_IsAMultiple_ReturnsFooBarForMultipleOf5And3() {
            // Arrange
            var fakePersonRepository = A.Fake<IRepository<Person>>();
            var challengeService = new ChallengeService(fakePersonRepository);

            // Act
            var result = challengeService.IsAMultiple(15);

            // Assert
            result.Should().Be("foo bar");
        }


        [Fact]
        public void ChallengeServiceIsAMultiple_ReturnsFooForMultipleOf5() {
            // Arrange
            var fakePersonRepository = A.Fake<IRepository<Person>>();
            var challengeService = new ChallengeService(fakePersonRepository);

            // Act
            var result = challengeService.IsAMultiple(10);

            // Assert
            result.Should().Be("foo");
        }


        [Fact]
        public void ChallengeService_IsAMultiple_ReturnsBarForMultipleOf3() {
            // Arrange
            var fakePersonRepository = A.Fake<IRepository<Person>>();
            var challengeService = new ChallengeService(fakePersonRepository);

            // Act
            var result = challengeService.IsAMultiple(9);

            // Assert
            result.Should().Be("bar");
        }

        [Fact]
        public void ChallengeService_IsAMultiple_ReturnsNumberAsStringForOtherCases() {
            // Arrange
            var fakePersonRepository = A.Fake<IRepository<Person>>();
            var challengeService = new ChallengeService(fakePersonRepository);

            // Act
            var result = challengeService.IsAMultiple(7);

            // Assert
            result.Should().Be("7 is not a Multiple of 5 or 3");
        }

        [Fact]
        public async Task ChallengeService_GetPeople_ReturnsFilteredPeopleList() {
            // Arrange
            var fakePersonRepository = A.Fake<IRepository<Person>>();
            var challengeService = new ChallengeService(fakePersonRepository);

            var fakePeople = new List<Person> {
                new Person { Age = 25, KnowHowtoDrive = true },
                new Person { Age = 16, KnowHowtoDrive = false },
                new Person { Age = 30, KnowHowtoDrive = true },
            };

            A.CallTo(() => fakePersonRepository.GetAllFilteredAsync()).Returns(fakePeople);

            // Act
            var result = await challengeService.GetPeople();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<Person>>();
            result.Should().HaveCount(3); // Assuming three people meet the filter criteria
        }

        [Fact]
        public void ChallengeService_HowManyVocals_ReturnsZeroForEmptyString() {
            // Arrange
            var fakePersonRepository = A.Fake<IRepository<Person>>();
            var challengeService = new ChallengeService(fakePersonRepository);

            // Act
            var result = challengeService.HowManyVocals(string.Empty);

            // Assert
            result.Should().Be("0");
        }

        [Fact]
        public void ChallengeService_HowManyVocals_ReturnsCorrectCountForStringWithVowels() {
            // Arrange
            var fakePersonRepository = A.Fake<IRepository<Person>>();
            var challengeService = new ChallengeService(fakePersonRepository);

            // Act
            var result = challengeService.HowManyVocals("Hello World");

            // Assert
            result.Should().Be("3"); // Assuming 'e', 'o', and 'o' are vowels
        }

        [Fact]
        public void ChallengeService_HowManyVocals_ReturnsZeroForStringWithoutVowels() {
            // Arrange
            var fakePersonRepository = A.Fake<IRepository<Person>>();
            var challengeService = new ChallengeService(fakePersonRepository);

            // Act
            var result = challengeService.HowManyVocals("HxyWz");

            // Assert
            result.Should().Be("0");
        }

        [Fact]
        public void ChallengeService_HowManyVocals_ReturnsZeroForNullString() { 
            // Arrange
            var fakePersonRepository = A.Fake<IRepository<Person>>();
            var challengeService = new ChallengeService(fakePersonRepository);

            // Act
            var result = challengeService.HowManyVocals(null);

            // Assert
            result.Should().Be("0");
        }
    }
}