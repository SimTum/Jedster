namespace Jedster.UseCases.Groups;

public interface IDeleteGroupUseCase
{
    Task ExecuteAsync(int groupId);
}