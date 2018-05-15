
namespace Generics
{
	class Counter<T> where T : ICountable
	{
		public int Count { get; set; }
		public void Add(T item)
		{
			Count += item.Count;
		}
	}
}