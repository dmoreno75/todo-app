using CSharpFunctionalExtensions;

namespace FrozenLand.ToDo.Infrastructure
{
    public interface IBaseRepository<T>
    {
		Task<Result<IList<T>>> GetAll();
	}
}