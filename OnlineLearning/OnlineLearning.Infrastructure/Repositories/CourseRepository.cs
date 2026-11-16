using Microsoft.EntityFrameworkCore;
using OnlineLearning.Domain.Entities;
using OnlineLearning.Domain.Interfaces;

namespace OnlineLearning.Infrastructure.Persistence.Repositories;

public sealed class CourseRepository(AppDbContext dbContext) : ICourseRepository
{
    public async Task<IReadOnlyList<Course>> GetAllAsync()
    {
        return await dbContext.Courses
            .AsNoTracking()
            .OrderBy(c => c.Id)
            .ToListAsync();
    }

    public async Task<Course?> GetByIdAsync(int id)
    {
        return await dbContext.Courses
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(Course course)
    {
        dbContext.Courses.Add(course);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Course course)
    {
        dbContext.Courses.Update(course);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Course course)
    {
        dbContext.Courses.Remove(course);
        await dbContext.SaveChangesAsync();
    }
}