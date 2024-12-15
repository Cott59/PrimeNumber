using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeNumber
{
    internal class DetectPrimeNumber
    {

        private long _number;
        public long Number { get { return _number; } }


        private CancellationTokenSource cancellationTokenSource;

        CancellationToken token;

        private Task<bool> task;

        public DetectPrimeNumber(long number)
        {
            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;
            this.token = token;
            _number = number;
            Task<bool> task = new Task<bool>(() =>
            {
                if(IsPrime(number))
                {
                    FileProcessing.SaveToFileTxt(number, "Простое число");
                    return true;
                }
                else
                {
                    FileProcessing.SaveToFileTxt(number, "Сложное число");
                    return false;
                }

            }, token);
            this.task = task;
        }

        public bool IsPrime(long number)
        {
            bool result = true;
            long _finish = Convert.ToInt64(Math.Sqrt(number));
            for (long i = 2; i < _finish; i++)
            {
                if (token.IsCancellationRequested)
                {
                    return false;
                }
                if (number % i == 0)
                {
                    return false;
                }
            }
            return result;
        }

        public void Stop()
        {
            this.cancellationTokenSource.Cancel();
        }

        public Task<bool> GetTask()
        {
            return task;
        }

    }

    

}
