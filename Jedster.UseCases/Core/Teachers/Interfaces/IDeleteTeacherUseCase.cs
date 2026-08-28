using Jedster.CoreBusiness;

namespace Jedster.UseCases.Teachers.Interfaces;

public interface IDeleteTeacherUseCase
{
    Task ExecuteAsync(int id);
}