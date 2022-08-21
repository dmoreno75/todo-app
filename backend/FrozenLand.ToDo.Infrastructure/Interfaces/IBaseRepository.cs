using CSharpFunctionalExtensions;

namespace FrozenLand.ToDo.Infrastructure
{
    public interface IBaseRepository<T>
    {
		Task<Result<IList<T>>> Get(Func<T, bool> specification);
		Task<Result<IList<T>>> GetAll();
	}
}