using Jedster.CoreBusiness;

namespace Jedster.UseCases.PluginInterfaces;

public interface ITeacherRepository
{
    Task<IEnumerable<Teacher>> GetTeachersByNameAsync(string name);
    Task RegisterTeacherAsync(Teacher teacher);
    Task EditTeacherAsync(Teacher teacher);
    Task<Teacher?> GetTeacherByIdAsync(int id);
}
