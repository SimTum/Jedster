namespace Jedster.UseCases.Lessons;

public interface IDeleteLessonUseCase
{
    Task ExecuteAsync(int id);
}