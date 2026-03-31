using System;
using System.Collections;
using Jedster.CoreBuisness;

namespace Jedster.UseCases.PluginInterfaces;

public interface ITeacherRepository
{
    Task<IEnumerable<Teacher>> GetTeachersByNameAsync(string name);
    Task RegisterTeacherAsync(Teacher teacher);
}
