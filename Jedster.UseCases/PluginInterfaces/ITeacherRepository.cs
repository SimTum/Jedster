using Jedster.CoreBusiness;

namespace Jedster.UseCases.PluginInterfaces;

public interface ITeacherRepository
{
    Task<IEnumerable<Teacher>> GetTeachersByNameAsync(string name);
    Task RegisterTeacherAsync(Teacher teacher);
    Task UpdateTeacherAsync(Teacher teacher);
}
