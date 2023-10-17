using Microsoft.AspNetCore.Mvc;
using RestCharpCourse.Models;
using RestCharpCourse.Services;
using RestSharp;
using System.Diagnostics;

namespace RestCharpCourse.Controllers
{
    public class HomeController : Controller
    {

        private readonly ITodoService _todoService;

        public HomeController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<IActionResult> Index()
        {
            List<Todo> todos = await _todoService.GetAsync(url:"posts"); 
            return View(todos);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Todo todo) 
        {
            if(todo == null) 
            {
                return BadRequest();
            }
            await _todoService.PostAsync(url:"posts",data:todo);
            return RedirectToAction("Index");
        }
    }
}