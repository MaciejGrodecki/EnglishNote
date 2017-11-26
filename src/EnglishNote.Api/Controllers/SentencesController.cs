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

        //Get api/sentences/
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sentences = await _sentenceService.BrowseAsync();

            return Json(sentences);
        }

        //POST api/sentences/
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddSentence command)
        {
            await _sentenceService.AddAsync(command.PolishSentence, command.EnglishSentence);

            return Created($"/ senteces /{ command.EnglishSentence}", null);
        }
    }
}
