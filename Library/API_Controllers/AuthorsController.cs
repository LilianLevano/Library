using Library.Data;
using Library.Data.Migrations;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.API_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly LibraryDbContext _context;
        public AuthorsController(LibraryDbContext context)
        {
            _context = context;
        }


        // GET: api/<AuthorsController>
        [HttpGet]
        public IEnumerable<Author> GetAsync()
        {
            return _context.Authors
                .Where(a => a.isDeleted > DateTime.Now)
                .OrderBy(a => a.Achternaam)
                .ThenBy(a => a.Voornaam)
                .ToArray();
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
