using System;
using System.Collections.Generic;
using System.Text;

namespace Classwork13
{
	interface IAviation : IAllProperties
	{
		uint MaxHeight { get; }
		uint CurrentHeight { get; }

		void TakeUpper(uint delta);
		void TakeLower(uint delta);
	}
}
