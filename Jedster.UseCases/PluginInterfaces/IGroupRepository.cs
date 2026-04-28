using System;
using System.Text.RegularExpressions;

namespace Jedster.UseCases.PluginInterfaces;

public interface IGroupRepository
{
    Task<IEnumerable<Group>> GetGroupsByNameAsync(string nome);

    Task RegisterGroup(Group group);
}
