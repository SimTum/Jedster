using Jedster.CoreBusiness;

namespace Jedster.UseCases.Students;

public interface IRegisterStudentsUseCase
{
    Task ExecuteAsync(Student student);
}