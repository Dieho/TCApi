using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TCApi.Models;


namespace TCApi.Controllers
{
    [Route("api/note")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly NoteContext _context;
        private readonly ILogger _logger;


        public NoteController(NoteContext context,
            ILogger<NoteContext> logger)
        {
            _context = context;
            _logger = logger;
            //if (_context.Notes.Count() == 0)
            //{
            //    _context.Notes.Add(new Note() { Frequency = 333, NoteName = "E" });
            //    _context.SaveChanges();
            //}
        }

        [HttpGet]
        public ActionResult<List<Note>> GetAll()
        {
            _logger.Log(LogLevel.Information, "GetAll");
            return _context.Notes.ToList();
        }

        [HttpGet("{id}", Name = "GetNote")]
        public ActionResult<Note> GetById(int id)
        {
            _logger.Log(LogLevel.Information, "GetById = {id}");
            var item = _context.Notes.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }


        [HttpPost]
        public IActionResult Create(Note item)
        {
            _logger.Log(LogLevel.Information, "Create = " + item.NoteId+" " + item.Frequency +" "+ item.NoteName );
            _context.Notes.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetNote", new { id = item.NoteId }, item);
        }

        //[HttpGet("{id}")]
        //public int Get(int id)
        //{
        //    return id;
        //}
    }
}
