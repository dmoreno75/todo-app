using CSharpFunctionalExtensions;

namespace FrozenLand.ToDo.Infrastructure
{
    public interface IBaseRepository<T>
    {
		Task<Result<IList<T>>> GetAll();
		Task<Result<T>> Save(string description);
	}
}