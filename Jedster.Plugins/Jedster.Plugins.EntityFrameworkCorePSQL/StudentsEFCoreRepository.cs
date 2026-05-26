using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class StudentsEFCoreRepository(IDbContextFactory<JedsterContext> contextFactorySource) : IStudentRepository
{
        
}