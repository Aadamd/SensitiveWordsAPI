using Microsoft.AspNetCore.Mvc;
using sensitive_words.core.Abstractions;
using sensitive_words.services.Commands;
using sensitive_words.services.Queries;

namespace sensitive_words.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensitiveWordsController : BaseController
    {

        [HttpGet("getSensitiveWords")]
        public async Task<ActionResult<List<string>>> GetSensitiveWords()
        {
            var sensitiveWords = await Mediator.Send(new GetSensitiveWordsQuery());
            return Ok(sensitiveWords);
        }

        [HttpPost("addSensitiveWord")]
        public async Task<ActionResult<string>> AddSensitiveWord([FromBody] AddSensitiveWordCommand command)
        {
            var sensitiveWord = await Mediator.Send(command);
            return Ok(sensitiveWord);
        }

        [HttpPost("addSensitiveWords")]
        public async Task<ActionResult<string>> AddSensitiveWords([FromBody] AddSensitiveWordsCommand command)
        {
            var sensitiveWords = await Mediator.Send(command);
            return Ok(sensitiveWords);
        }

        [HttpDelete("deleteSensitiveWord")]
        public async Task<ActionResult<string>> DeleteSensitiveWord([FromBody] DeleteSensitiveWordCommand command)
        {
            var sensitiveWord = await Mediator.Send(command);
            return Ok(sensitiveWord);
        }

        [HttpPut("updateSensitiveWord")]
        public async Task<ActionResult<string>> UpdateSensitiveWord([FromBody] UpdateSensitiveWordCommand command)
        {
            var sensitiveWord = await Mediator.Send(command);
            return Ok(sensitiveWord);
        }

        [HttpPost("sanitizeString")]
        public async Task<ActionResult<string>> SanitizeString([FromBody] SanitizeStringCommand command)
        {
            var sanitizedString = await Mediator.Send(command);
            return Ok(sanitizedString);  
        }
    }
}
