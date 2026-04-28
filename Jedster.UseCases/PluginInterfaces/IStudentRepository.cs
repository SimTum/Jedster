using System;
using Jedster.CoreBuisness;


namespace Jedster.UseCases.PluginInterfaces;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetStudentsByNameAsync(string name);
    Task RegisterStudent(Student student);
}
