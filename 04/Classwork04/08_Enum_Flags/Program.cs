using System;

namespace _08_Enum_Flags
{
	class Program
	{
		/*
		 * 
		 */
		[Flags] //атрибут
		enum Days : byte//побитовый атрибут
		{ 
			None = 0,
			Monday = 1,		//==0x1 -- шестнадцатеричная	//0b00000001	двоичная
			Tuesday = 2,	//==0x2							//0b00000010
			Wensday = 4,	//==0x4							//0b00000100
			Thursday = 8,	//==0x8							//0b00001000
			Friday = 16,	//==0x10						//0b00010000
			Saturday = 32,	//==0x20
			Sunday = 64		//==0x40
			//XX = 128
		};
		/* таким образом появляется возможность в одной перменной хранить несколько значений*/
		static void Main(string[] args)
		{
			Console.WriteLine("Enum flags");
			Days workingDays = (Days)0b00011111;
			Console.WriteLine(workingDays);
			workingDays |= Days.Saturday;		//добавление бита
			Console.WriteLine(workingDays);
			workingDays ^= (Days.Monday);		//замена бита
			Console.WriteLine(workingDays);
			workingDays &= !(Days.Monday);

			bool thursdayIsWorking = 
				(workingDays & Days.Thursday) != Days.Thursday;
		}
	}
}
