using Jedster.CoreBusiness;

namespace Jedster.UseCases.Teachers.Interfaces;

public interface IViewTeacherUseCase
{
    //All teachers method
    Task<IEnumerable<Teacher>> ExecuteAsync(string name = " ");
    //Teacher by id method
    Task<Teacher?> ExecuteAsync(int id);
}