using CodingChallenge.Models;
using CodingChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace CodingChallenge.Controllers {
    public class ChallengeController : Controller {

        // Private fields to store the logger and challenge service instances
        private readonly ILogger<ChallengeController> _logger;
        private readonly IChallengeService _challengeService;

        // Constructor to initialize the ChallengeController with a logger and challenge service
        public ChallengeController(ILogger<ChallengeController> logger, IChallengeService oChallengeService) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _challengeService = oChallengeService ?? throw new ArgumentNullException(nameof(oChallengeService));
        }

        // Action method to return the Index view
        public IActionResult Index() => View();

        // Action method to handle the CalculateMultiple POST request
        [HttpPost("CalculateMultiple")]
        public IActionResult CalculateMultiple([Range(2, 999)] int multipleNumber) {
            try {
                // Calculate and set ViewBag.CalculateMultiple based on the input
                ViewBag.CalculateMultiple = ModelState.IsValid ? _challengeService.IsAMultiple(multipleNumber)
                    : throw new InvalidOperationException("Invalid input");
            }
            catch (Exception ex) {
                // Log errors and set ViewBag.CalculateMultipleError for error handling
                _logger.LogError(ex, "An error occurred while calculating multiples.");
                ViewBag.CalculateMultipleError = "An error occurred while processing your request.";
            }

            // Return the Index view
            return View("Index");
        }

        // Action method to handle the CalculateVocals POST request
        [HttpPost("CalculateVocals")]
        public IActionResult CalculateVocals([RegularExpression("^[a-zA-Z\\s]*$")] string vocalsText) {
            try {
                // Calculate and set ViewBag.CalculateVocals based on the input
                ViewBag.CalculateVocals = !string.IsNullOrEmpty(vocalsText) ? _challengeService.HowManyVocals(vocalsText)
                    : throw new InvalidOperationException("Invalid input");
            }
            catch (Exception ex) {
                // Log errors and set ViewBag.CalculateVocalsError for error handling
                _logger.LogError(ex, "An error occurred while calculating vocals.");
                ViewBag.CalculateVocalsError = "An error occurred while processing your request.";
            }

            // Return the Index view
            return View("Index");
        }

        // Action method to handle the GetPersonList GET request asynchronously
        [HttpGet("GetPersonList")]
        public async Task<IActionResult> GetPersonList() {
            try {
                // Get the list of people from the challenge service
                var peopleList = await _challengeService.GetPeople();
                if (peopleList.Any())
                {
                    // If the list is not empty, set ViewBag.GetPersonList
                    ViewBag.GetPersonList = peopleList;
                }
                else
                {
                    // If the list is empty, set ViewBag.PersonListError
                    ViewBag.PersonListError = "Empty List";
                }
            }
            catch (Exception ex) {
                // Log errors and set ViewBag.PersonListError for error handling
                _logger.LogError(ex, "An error occurred while calling the challenge service.");
                ViewBag.PersonListError = "An error occurred while processing your request.";
            }

            // Return the Index view
            return View("Index");
        }

        // Action method to handle errors and return the Error view
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}