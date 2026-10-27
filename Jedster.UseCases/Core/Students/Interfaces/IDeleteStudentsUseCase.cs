namespace Jedster.UseCases.Students.Interfaces;

public interface IDeleteStudentsUseCase
{
    Task ExecuteAsync(int studentId);
}