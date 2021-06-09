using System;

namespace Classwork13
{
	class Program
	{
		static void Main(string[] args)
		{
			Helicopter heli = new Helicopter(100, 8);			
			Plane plane = new Plane(200, 4);

			heli.WriteAllProperties();
			heli.TakeUpper(50);
			heli.WriteAllProperties();
			heli.TakeLower(10);
			heli.WriteAllProperties();
			heli.TakeUpper(100);
			heli.WriteAllProperties();
			heli.TakeLower(200);
			heli.WriteAllProperties();

			Aviation[] avia = new Aviation[2];
			avia[1] = new Helicopter(20, 4);
			avia[0] = new Plane(500, 6);

			foreach (var avias in avia)
			{
				avias.TakeUpper(10);
				avias.TakeLower(10);
				avias.WriteAllProperties();
			}
		}
	}
}
