using Jedster.CoreBusiness;

namespace Jedster.UseCases.Teachers.Interfaces;

public interface IEditTeacherUseCase
{
    Task ExecuteAsync(Teacher teacher);
    Task<Teacher> ExecuteAsync(int id);
}