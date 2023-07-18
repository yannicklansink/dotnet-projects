using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Threading
{
	class SlowMath
	{


		public int Square(int n)
		{
			Thread.Sleep(3000);
			return n * n;
		}

	}
}
