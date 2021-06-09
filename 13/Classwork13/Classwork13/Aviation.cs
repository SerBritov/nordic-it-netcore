using System;
using System.Collections.Generic;
using System.Text;

namespace Classwork13
{
	public abstract class Aviation : IAviation
	{
		public uint MaxHeight { get; private set; }
		public uint CurrentHeight { get; private set; }

		protected Aviation(uint maxHeight)
		{
			MaxHeight = maxHeight;
			CurrentHeight = 10;
		}
		public void TakeUpper(uint delta)
		{
			try
			{
				CurrentHeight += delta;
			}
			catch (ArgumentOutOfRangeException e)
			{
				Console.WriteLine(e);
				throw;
			}
			CurrentHeight = CurrentHeight > MaxHeight ? MaxHeight : CurrentHeight;
		}

		public void TakeLower(uint delta)
		{
			if (delta > CurrentHeight)
			{
				InvalidOperationException e1 = new InvalidOperationException();
				Console.WriteLine("Crash!");
				throw (e1);
			}
			CurrentHeight -= delta;
		}
		public abstract void WriteAllProperties();

	}
}
