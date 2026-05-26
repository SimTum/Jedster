using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class StudentsEfCoreRepository(IDbContextFactory<JedsterContext> contextFactorySource) : IStudentRepository
{
    public Task<IEnumerable<Student>> GetStudentsByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<Student> GetStudentByIdAsync(int studentId)
    {
        throw new NotImplementedException();
    }

    public Task EditStudentAsyc(Student student)
    {
        throw new NotImplementedException();
    }

    public Task RegisterStudentAsync(Student student)
    {
        throw new NotImplementedException();
    }

    public Task DeleteStudenteById(int studentId)
    {
        throw new NotImplementedException();
    }
}