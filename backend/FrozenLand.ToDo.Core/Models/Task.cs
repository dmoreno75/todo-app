namespace FrozenLand.ToDo.Core.Models
{
	public record Task(string Id, DateTime CreationDate, bool Completed, string Description)
	{
		public DateTime CompleteDate { get; }
		public Task Complete()
		{
			return this with { Completed = true, CreationDate = DateTime.Now };
		}
	}
}