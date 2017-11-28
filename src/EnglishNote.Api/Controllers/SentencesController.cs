using EnglishNote.Api.Commands;
using EnglishNote.Api.Repositories;
using EnglishNote.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishNote.Api.Controllers
{
    [Route("api/[controller]")]
    public class SentencesController : Controller
    {
        private readonly ISentenceService _sentenceService;

        public SentencesController(ISentenceService sentenceService)
        {
            _sentenceService = sentenceService;
        }

        //GET api/sentences/
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sentences = await _sentenceService.BrowseAsync();

            return Json(sentences);
        }

        //GET api/sentences/sentenceId
        [HttpGet("{sentenceId}")]
        public async Task<IActionResult> Get(Guid sentenceId)
        {
            var sentence = await _sentenceService.GetAsync(sentenceId);

            return Json(sentence);
        }

        //POST api/sentences/
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddSentence command)
        {
            await _sentenceService.AddAsync(command.PolishSentence, command.EnglishSentence);

            return Created($"/ senteces /{ command.EnglishSentence}", null);
        }

        //DELETE api/sentences/{sentenceid}
        [HttpDelete("{sentenceId}")]
        public async Task<IActionResult> Delete(Guid sentenceId)
        {
            await _sentenceService.RemoveAsync(sentenceId);

            return NoContent();
        }
    }
}
