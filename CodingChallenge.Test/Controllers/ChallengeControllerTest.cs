using CodingChallenge.Controllers;
using CodingChallenge.Models;
using CodingChallenge.Services;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodingChallenge.Test.Controllers
{
    public class ChallengeControllerTest {

        private readonly ILogger<ChallengeController> _logger;
        private readonly IChallengeService _challengeService;
        private readonly ChallengeController _challengeController;

        public ChallengeControllerTest() {
            //Dependencies
            _challengeService = A.Fake<IChallengeService>();
            _logger = A.Fake<ILogger<ChallengeController>>();

            //SUT
            _challengeController = new ChallengeController(_logger, _challengeService);
        }

        [Fact]
        public void ChallengeController_CalculateMultiple_ReturnsSuccess() {
            //Arrange - What do i need to bring in?
            int number = 1;
            A.CallTo(() => _challengeService.IsAMultiple(number)).Returns("Foo");

            //Act
            var result = _challengeController.CalculateMultiple(number);

            //Assert - Object check actions
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void ChallengeController_CalculateVocals_ReturnsSuccess(){
            //Arrange - What do i need to bring in?
            string text = "342-]c dgye6 ";
            A.CallTo(() => _challengeService.HowManyVocals(text)).Returns(text);

            //Act
            var result = _challengeController.CalculateVocals(text);

            //Assert - Object check actions
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public async Task ChallengeController_GetPersonList_ReturnsSuccessAsync() {
            //Arrange - What do i need to bring in?
            A.CallTo(() => _challengeService.GetPeople()).Returns(new List<Person>());

            //Act
            var result = await _challengeController.GetPersonList();

            //Assert - Object check actions
            result.Should().BeOfType<ViewResult>();
        }
    }
}