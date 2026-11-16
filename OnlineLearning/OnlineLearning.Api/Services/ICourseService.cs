using OnlineLearning.Application.DTOs;

namespace OnlineLearning.Application.Services;

public interface ICourseService
{
    Task<IReadOnlyList<CourseDto>> GetAllAsync();
    Task<CourseDto?> GetByIdAsync(int id);
    Task<CourseDto> CreateAsync(CreateCourseRequest request);
    Task<bool> UpdateAsync(int id, UpdateCourseRequest request);
    Task<bool> DeleteAsync(int id);
}