using CodingChallenge.Models;
using CodingChallenge.Repositories;
using FakeItEasy;
using FluentAssertions;

namespace CodingChallenge.Test.Repositories{
    public class PersonRepositoryTest{

        [Fact]
        public void PersonRepository_GetAll_ReturnsListOfPeople(){
            //Arrange - What do i need to bring in?
            var fakePerson = A.Fake<Person>();
            var _personRespository = new PersonRepository(fakePerson);

            //Act
            var result = _personRespository.GetAll();

            //Assert - Object check actions
            result.Should().NotBeNull();
            result.Should().BeOfType<List<Person>>();
        }

        [Fact]
        public void PersonRepository_GetAllFiltered_ReturnsListOfPeople()
        {
            //Arrange - What do i need to bring in?
            var fakePerson = A.Fake<Person>();
            var _personRespository = new PersonRepository(fakePerson);

            //Act
            var result = _personRespository.GetAllFiltered();

            //Assert - Object check actions
            result.Should().NotBeNull();
            result.Should().BeOfType<List<Person>>();
        }

        [Fact]
        public async Task PersonRepository_GetAllAsync_ReturnsListOfPeople()
        {
            //Arrange - What do i need to bring in?
            var fakePerson = A.Fake<Person>();
            var _personRespository = new PersonRepository(fakePerson);

            //Act
            var result = await _personRespository.GetAllAsync();

            //Assert - Object check actions
            result.Should().NotBeNull();
            result.Should().BeOfType<List<Person>>();
        }

        [Fact]
        public async Task PersonRepository_GetAllFilteredAsync_ReturnsListOfPeople()
        {
            //Arrange - What do i need to bring in?
            var fakePerson = A.Fake<Person>();
            var _personRespository = new PersonRepository(fakePerson);

            //Act
            var result = await _personRespository.GetAllFilteredAsync();

            //Assert - Object check actions
            result.Should().NotBeNull();
            result.Should().BeOfType<List<Person>>();
        }

    }
}