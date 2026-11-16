namespace OnlineLearning.Application.DTOs;

public sealed record CourseDto(
    int Id,
    string Title,
    string Description,
    int TeacherId,
    DateTimeOffset CreatedAt);