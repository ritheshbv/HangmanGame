using Microsoft.AspNetCore.Mvc;
using Sbs.Api.Data.Entities;
using Sbs.Api.Repositories;
using System;
using System.Threading.Tasks;

namespace Sbs.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HangmanController : ControllerBase
    {
        private readonly ISbsDbRepository _repository;
        public HangmanController(ISbsDbRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        //[HttpGet("WordList{type}")]
        public async Task<IActionResult> GetWords(int type)
        {
            WordType wordType = (WordType)type;

            if (Enum.IsDefined(typeof(WordType), wordType))
            {
                var results = await _repository.GetWordsAsync(wordType);
                return Ok(results);
            }

            return BadRequest(new { Message = "WordType not matching should be 0, 1 or 2." });
        }

        [HttpGet("{type}")]
        public async Task<IActionResult> GetWord(int type)
        {
            WordType wordType = (WordType)type;

            if (Enum.IsDefined(typeof(WordType), wordType))
            {
                var results = await _repository.GetWordsAsync(wordType);
                Random random = new Random();
                var wordindex = random.Next(results.Length);
                var word = results[wordindex];

                return Ok(word);
            }

            return BadRequest(new { Message = "WordType not matching should be 0, 1 or 2." });
        }
    }
}
