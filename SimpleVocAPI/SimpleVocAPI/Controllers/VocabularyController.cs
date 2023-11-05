using Microsoft.AspNetCore.Mvc;
using SimpleVocAPI.DTO.Vocabulary;
using SimpleVocAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleVocAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VocabularyController : ControllerBase
    {
        private readonly IVocabularyService vocabularyService;

        public VocabularyController(IVocabularyService vocabularyService)
        {
            this.vocabularyService = vocabularyService;
        }

        // GET: api/<VocabularyController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var vocabularies = await vocabularyService.GetAll();
                return Ok(vocabularies);
            }
            catch (Exception ex)
            {
                //todo: Logger
                return StatusCode(500);
            }

        }

        // GET api/<VocabularyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var vocabulary = await vocabularyService.GetByID(id);
                return Ok(vocabulary);
            }
            catch (Exception ex)
            {
                //todo: Logger
                return StatusCode(500);
            }
        }

        // POST api/<VocabularyController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddVocabularyRequest value)
        {
            try
            {
                var vocabulary = await vocabularyService.Add(value);
                return Ok(vocabulary);
            }
            catch (Exception ex)
            {
                //todo: Logger
                return StatusCode(500);
            }
        }

        // PUT api/<VocabularyController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateVocabularyRequest value)
        {
            try
            {
                await vocabularyService.UpdateVocabulary(value, id);
                return Ok();
            }
            catch (Exception ex)
            {
                //todo: Logger
                return StatusCode(500);
            }
        }

        // DELETE api/<VocabularyController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await vocabularyService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                //todo: Logger
                return StatusCode(500);
            }
        }
    }
}
