using System;
using System.Collections.Generic;
using System.Text;

namespace Classwork13
{
	class Helicopter : Aviation, IHelicopter
	{
		public byte BladesCount { get; private set; }
		public Helicopter(uint maxHeight, byte bladesCount) : base(maxHeight)
		{
			BladesCount = bladesCount;
		}

		public override void WriteAllProperties()
		{
			Console.WriteLine($"Blades Count: {BladesCount}\nCurrent Height: {CurrentHeight}\nMax height: {MaxHeight}");
		}
	}
}
