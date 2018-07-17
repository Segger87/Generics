
namespace Generics
{
	public class Apple : ICountable
	{
		public string Color { get; }
		public Apple(string color) => Color = color;

		public int Count
		{
			get
			{
				return 1;
			}
		}
	}
}