using System;
using Jedster.CoreBusiness;


namespace Jedster.UseCases.PluginInterfaces;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetStudentsByNameAsync(string name);
    Task RegisterStudent(Student student);
}
