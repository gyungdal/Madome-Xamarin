using System;
using System.Threading;
using Xamarin.Forms;

namespace Madome.Helpers {
	public class TimerHelper {
        private readonly TimeSpan _timeSpan;
        private readonly Action _callback;

        private static CancellationTokenSource _cancellationTokenSource;

        public TimerHelper(TimeSpan timeSpan, Action callback){
            _timeSpan = timeSpan;
            _callback = callback;
            _cancellationTokenSource = new CancellationTokenSource();
        }
        public void Start(){
            CancellationTokenSource cts = _cancellationTokenSource; // safe copy
            Device.StartTimer(_timeSpan, () =>
            {
                if (cts.IsCancellationRequested)
                {
                    return false;
                }
                _callback.Invoke();
                return true; //true to continuous, false to single use
            });
        }

		public void Stop(){
            Interlocked.Exchange(ref _cancellationTokenSource, new CancellationTokenSource()).Cancel();
        }
    }
}
