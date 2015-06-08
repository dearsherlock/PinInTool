using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchConvertFile
{
    public class Benchmark : IDisposable
    {
        Stopwatch _watch;
        string _name;

        public static Benchmark Start(string name)
        {
            return new Benchmark(name);
        }

        private Benchmark(string name)
        {
            _name = name;
            _watch = new Stopwatch();
            _watch.Start();
        }

        #region IDisposable implementation

        // dispose stops stopwatch and prints time, could do anytying here
        public void Dispose()
        {
            _watch.Stop();
            Console.WriteLine("{0} Total seconds: {1}"
                               , _name, _watch.Elapsed.TotalSeconds);
        }

        #endregion
    }
}
