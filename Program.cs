using System;
using System.Diagnostics;

namespace EratosthenesPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            long limit = 1000;
            int size = 1000;

            if(args.Length >= 1)
            {
                if(!Int64.TryParse(args[0], out limit))
                {
                    limit = 1000;
                }
            }
            if(args.Length >= 2)
            {
                if(!Int32.TryParse(args[1], out size))
                {
                    size = 1000;
                }
            }
            
            var sw = new Stopwatch();
            sw.Start();
            var primes = Eratosthenes.FindPrimes(limit, size);
            sw.Stop();
            Console.WriteLine($"{primes.Count} primes found in {sw.Elapsed.Seconds}.{sw.ElapsedMilliseconds % 1000, 3:D3} seconds");

            Console.WriteLine("Press Enter to print the primes or Ctrl-C to quit.");
            Console.ReadLine();

            foreach(var p in primes)
            {
                Console.WriteLine(p);
            }
        }
    }
}
