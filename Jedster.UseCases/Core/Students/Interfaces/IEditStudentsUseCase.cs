using Jedster.CoreBusiness;

namespace Jedster.UseCases.Students;

public interface IEditStudentsUseCase
{
    Task ExecuteAsync(Student student);
}