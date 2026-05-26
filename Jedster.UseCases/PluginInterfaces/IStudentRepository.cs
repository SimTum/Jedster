using System;
using Jedster.CoreBusiness;


namespace Jedster.UseCases.PluginInterfaces;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetStudentsByNameAsync(string name);
    Task<Student> GetStudentByIdAsync(int studentId);
    Task EditStudentAsyc(Student student);
    Task RegisterStudentAsync(Student student);
    Task DeleteStudenteById(int studentId);
}
