using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Example.Models;
using Example.BUS;

namespace Example.Controllers
{
    public class MoviesController : Controller
    {
        

        private readonly IMovieService _movieService;
        private readonly ILogger<HomeController> _logger;
        //Constructor Injection
        public MoviesController(IMovieService movieService, ILogger<HomeController> logger)
        {
            _movieService = movieService;
            _logger = logger;
        }

        // Setter Injection
        //public readonly MovieContext _context;
        //public MovieContext Context { set { _context = value; } }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Trang chủ được truy cập.");
            return View(await _movieService.GetAll());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var movie = await _movieService.GetById((int)id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movieService.Create(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                _logger.LogCritical("Request {traceId} started at: {time}", HttpContext.TraceIdentifier, DateTimeOffset.Now);
                return NotFound();
            }

            var movie = await _movieService.GetById((int)id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _logger.LogInformation("Entering into database, update movie");
                    await _movieService.Update(movie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _movieService.IsExsist(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        _logger.LogDebug("Request {traceId} started at: {time}", HttpContext.TraceIdentifier, DateTimeOffset.Now);
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _movieService.GetById((int)id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _movieService.GetById((int)id);
            if (movie != null)
            {
                await _movieService.Delete(movie);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
