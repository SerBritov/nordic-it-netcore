using System;
using System.Collections.Generic;
using System.Text;

namespace Classwork13
{
	class Plane : Aviation, IPlane
	{
		public byte EnginesCount { get; set; }
		public Plane(uint maxHeight, byte enginesCount) : base(maxHeight)
		{
			EnginesCount = enginesCount;
		}

		public override void WriteAllProperties()
		{
			Console.WriteLine($"Engines Count: {EnginesCount}\nCurrent Height: {CurrentHeight}\nMax height: {MaxHeight}");
		}
	}
}
