using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class ObjectState
    {
        public SlowMath instance;
        public int number;
        public AsyncCallback callback;
    }
    class MyAsyncResult : IAsyncResult
    {
        private ManualResetEventSlim manualReset;
        private bool completedSynchronously;
        private object state;
        private int result;
        public MyAsyncResult(object s)
        {
            state = s;
            manualReset = new ManualResetEventSlim();
            completedSynchronously = manualReset.IsSet;
        }
        public void myRunMethod(object state)
        {
            ObjectState os = (ObjectState)state;
            result = os.instance.Square(os.number);
            manualReset.Set();
            os.callback(this);
        }
        public object AsyncState => state;

        public WaitHandle AsyncWaitHandle => manualReset.WaitHandle;

        public bool CompletedSynchronously => completedSynchronously;

        public bool IsCompleted => manualReset.IsSet;
        public int Result => result;
    }
    class SlowMath
	{
		public IAsyncResult BeginSquare(int n, AsyncCallback callback,object state)
        {
            MyAsyncResult mar =  new MyAsyncResult(state);
            ObjectState os = new ObjectState() { instance = this, number = n, callback = callback };
            ThreadPool.QueueUserWorkItem(mar.myRunMethod,os);
            return mar;
        }

		public int EndSquare(IAsyncResult ia)
        {
			MyAsyncResult mar = (MyAsyncResult)ia;
            mar.AsyncWaitHandle.WaitOne();
            return mar.Result;

        }

		public int Square(int n)
		{
			Thread.Sleep(3000);
			return n * n;
		}


	}
}
