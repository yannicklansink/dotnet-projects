using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
	class SlowMath
	{

		public async Task<int> SquareAsync(int n)
		{
			await Task.Delay(3000);
			return n*n;
		}

	}
}
