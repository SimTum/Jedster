namespace Jedster.UseCases.Lessons;

public interface ILessonExistsUseCase
{
    Task<bool> ExecuteAsync(int groupId, DateTime date);
}