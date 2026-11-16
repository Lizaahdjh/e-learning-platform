using OnlineLearning.Application.DTOs;
using OnlineLearning.Domain.Entities;
using OnlineLearning.Domain.Interfaces;

namespace OnlineLearning.Application.Services;

public sealed class CourseService(ICourseRepository repository) : ICourseService
{
    public async Task<IReadOnlyList<CourseDto>> GetAllAsync()
    {
        var courses = await repository.GetAllAsync();
        return courses.Select(ToDto).ToList();
    }

    public async Task<CourseDto?> GetByIdAsync(int id)
    {
        var course = await repository.GetByIdAsync(id);
        return course is null ? null : ToDto(course);
    }

    public async Task<CourseDto> CreateAsync(CreateCourseRequest request)
    {
        var course = new Course
        {
            Title = request.Title,
            Description = request.Description,
            TeacherId = request.TeacherId
        };

        await repository.AddAsync(course);
        return ToDto(course);
    }

    public async Task<bool> UpdateAsync(int id, UpdateCourseRequest request)
    {
        var course = await repository.GetByIdAsync(id);
        if (course is null) return false;

        course.Title = request.Title;
        course.Description = request.Description;

        await repository.UpdateAsync(course);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var course = await repository.GetByIdAsync(id);
        if (course is null) return false;

        await repository.DeleteAsync(course);
        return true;
    }

    private static CourseDto ToDto(Course c) =>
        new(c.Id, c.Title, c.Description, c.TeacherId, c.CreatedAt);
}