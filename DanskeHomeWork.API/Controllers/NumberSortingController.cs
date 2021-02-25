using DanskeHomeWork.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DanskeHomeWork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberSortingController : ControllerBase
    {
        private readonly ILogger<NumberSortingController> logger;
        private readonly IIOService ioService;
        private readonly ISortingService sortingService;

        public NumberSortingController(ILogger<NumberSortingController> logger, IIOService ioService, ISortingService sortingService)
        {
            this.logger = logger;
            this.ioService = ioService;
            this.sortingService = sortingService;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> PostAndOrderNumbers(string lineOfNumbers)
        {
            try
            {
                int[] numbers = lineOfNumbers.Split(' ').Select(number => int.Parse(number)).ToArray();
                await ioService.WriteToFile("result.txt", sortingService.BubbleSort(numbers));
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return ex switch
                {
                    FormatException => BadRequest("Pateikta eilutė, nebuvo sveikujų skaičių eilutė atskirta tarpais"),
                    _ => BadRequest("Nenumatyta klaida"),
                };
            }
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetPreviousOrderingResult()
        {
            try
            {
                return Ok(await ioService.ReadFromFile("result.txt"));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return ex switch
                {
                    FileNotFoundException => BadRequest("Nėra išsaugoto rezultato"),
                    _ => BadRequest("Nenumatyta klaida"),
                };
            }
        }
        [HttpGet("benchmark")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        public IActionResult GetBenchmarks()
        {
            try
            {
                Random random = new Random();
                int[] unsortedNumbers = new int[int.MaxValue / 100000];
                for (int i = 0; i < unsortedNumbers.Length; i++)
                {
                    unsortedNumbers[i] = random.Next(int.MaxValue);
                }
                int[] numbersToUseInBubbleSort = (int[])unsortedNumbers.Clone();
                int[] numbersToUseInSelectionSort = (int[])unsortedNumbers.Clone();
                List<string> results = new List<string>();
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                sortingService.BubbleSort((int[])unsortedNumbers.Clone());
                stopwatch.Stop();
                results.Add($"BubbleSort užtruko: {stopwatch.ElapsedMilliseconds} ms");
                stopwatch.Reset();
                stopwatch.Start();
                sortingService.SelectionSort((int[])unsortedNumbers.Clone());
                stopwatch.Stop();
                results.Add($"SelectionSort užtruko: {stopwatch.ElapsedMilliseconds} ms");
                stopwatch.Reset();
                stopwatch.Start();
                Array.Sort(unsortedNumbers);
                stopwatch.Stop();
                results.Add($"Array.Sort užtruko: {stopwatch.ElapsedMilliseconds} ms");
                return Ok(results);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest("Nepavyko atlikti matavimų");
            }
        }
    }
}
