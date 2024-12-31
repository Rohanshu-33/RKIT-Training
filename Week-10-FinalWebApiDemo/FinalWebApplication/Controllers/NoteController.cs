using FinalWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace FinalWebApplication.Controllers
{
    public class NoteController : ApiController
    {
        private static readonly List<Note> Notes = new List<Note>();
        private static int CurrentId = 1;

        [HttpGet]
        [Route("api/notes")]
        [CacheOutput(ClientTimeSpan = 120, ServerTimeSpan = 60)] // Cache for 60 seconds
        public IHttpActionResult GetNotes()
        {
            try
            {
                return Ok(Notes);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/notes")]
        [InvalidateCacheOutput("GetNotes")] // Invalidate cache when new note is added bcoz now actual resource is modified
        public IHttpActionResult CreateNote([FromBody] Note note)
        {
            try
            {
                if (note == null) return BadRequest("Invalid data.");

                note.Id = CurrentId++;
                Notes.Add(note);
                return Ok(note);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("api/notes/{id}")]
        [InvalidateCacheOutput("GetNotes")] // Invalidate cache.
        public IHttpActionResult DeleteNote(int id)
        {
            try
            {
                var note = Notes.FirstOrDefault(n => n.Id == id);
                if (note == null) return NotFound();

                Notes.Remove(note);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
