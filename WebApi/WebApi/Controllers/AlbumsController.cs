using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private ITokenService _tokenService;

        public AlbumsController(DatabaseContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        // GET: api/Albums
        //modify to get only albums of logged user
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums( string search, string field)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var id = _tokenService.ValidateToken(token);
            if (id != null)
            {
                var albums = _context.Albums.Where(a => a.UserID == id);//.ToListAsync();
                try
                {
                    if (!String.IsNullOrEmpty(search) && !String.IsNullOrEmpty(field))
                    {
                        if (field == "date")
                        {
                            albums = albums.Where(a => a.ReleaseYear == int.Parse(search));
                        }
                        else if (field == "artist")
                        {
                            albums = albums.Where(a => a.ArtistName.Contains(search));
                        }
                        else if (field == "title")
                        {
                            albums = albums.Where(a => a.Title.Contains(search));
                        }
                    }
                    var result = await albums.OrderByDescending(a=> a.ReleaseYear).Include(album => album.Tracks.OrderBy(t => t.TrackNumber)).ToListAsync();
                    if (result != null)
                    {
                        return Ok(result);
                    }
                }
                catch (InvalidOperationException e)
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }

        // GET: api/Albums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = _tokenService.ValidateToken(token);
            if (userId != null)
            {
                var album =  await _context.Albums.Where(a => a.UserID == userId && a.AlbumID == id)
                    .Include(album => album.Tracks.OrderBy(t=>t.TrackNumber)).SingleOrDefaultAsync();
                
                if (album != null)
                {
                    return Ok(album);
                }
            }

            return NotFound();
        }

        // PUT: api/Albums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbum(int id, Album album)
        {
            if (id != album.AlbumID)
            {
                return BadRequest();
            }

            _context.Entry(album).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Albums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Album>> PostAlbum(Album album)
        {
            _context.Albums.Add(album);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlbum", new { id = album.AlbumID }, album);
        }

        // DELETE: api/Albums/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.AlbumID == id);
        }
    }
}
