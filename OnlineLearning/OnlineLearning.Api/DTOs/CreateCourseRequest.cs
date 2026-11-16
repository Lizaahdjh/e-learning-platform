namespace OnlineLearning.Application.DTOs;

public sealed record CreateCourseRequest(
    string Title,
    string Description,
    int TeacherId);