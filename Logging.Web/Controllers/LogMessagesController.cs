using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using DataAccess.DataContext;
using Entities;
using Logger;
using System;

namespace Logging.Web.Controllers
{
    public class LogMessagesController : ApiController
    {
        private LogMessgeContext db = new LogMessgeContext();

        private ILogger _logger;

        public LogMessagesController(ILogger logger)
        {
            _logger = logger;
        }

        // GET: api/LogMessages
        public IQueryable<LogMessage> GetLogMessages()
        {
            return _logger.GetLogMessages();
        }

        // PUT: api/LogMessages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLogMessage(int id, LogMessage logMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != logMessage.ID)
            {
                return BadRequest();
            }

            try
            {
                _logger.UpdateLogMessage(id, logMessage);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/LogMessages
        [ResponseType(typeof(LogMessage))]
        public IHttpActionResult PostLogMessage(LogMessage logMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _logger.WriteLogMessage(logMessage);

            return CreatedAtRoute("DefaultApi", new { id = logMessage.ID }, logMessage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}