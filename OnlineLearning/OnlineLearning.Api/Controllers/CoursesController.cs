using Microsoft.AspNetCore.Mvc;
using OnlineLearning.Domain.Entities;

namespace OnlineLearning.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private static readonly List<Course> _courses = new()
    {
        new Course { Id = 1, Title = "C# Basics",   Description = "Intro to C#", TeacherId = 1 },
        new Course { Id = 2, Title = "ASP.NET Core", Description = "Web API",    TeacherId = 1 },
    };

    [HttpGet]
    public IEnumerable<Course> Get() => _courses;

    [HttpGet("{id:int}")]
    public ActionResult<Course> GetById(int id)
    {
        var c = _courses.FirstOrDefault(x => x.Id == id);
        return c is null ? NotFound() : c;
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] Course updated)
    {
        var c = _courses.FirstOrDefault(x => x.Id == id);
        if (c is null) return NotFound();
        c.Title = updated.Title;
        c.Description = updated.Description;
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var c = _courses.FirstOrDefault(x => x.Id == id);
        if (c is null) return NotFound();
        _courses.Remove(c);
        return NoContent();
    }
}