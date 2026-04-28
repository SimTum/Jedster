using System;
using Jedster.CoreBuisness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.Plugins.InMemory;

public class StudentRepository : IStudentRepository
{
    public Task<IEnumerable<Student>> GetStudentsByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task RegisterStudent(Student student)
    {
        throw new NotImplementedException();
    }
}
