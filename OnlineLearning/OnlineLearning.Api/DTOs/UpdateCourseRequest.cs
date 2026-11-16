namespace OnlineLearning.Application.DTOs;

public sealed record UpdateCourseRequest(
    string Title,
    string Description);