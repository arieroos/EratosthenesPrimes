using System;
using System.Collections.Generic;
using System.Linq;

namespace EratosthenesPrimes
{
    static class Eratosthenes
    {
        public static List<long> FindPrimes(long maxNum, int sampleSize = 1000)
        {
            if (maxNum < 2)
            {
                return new List<long>();
            }
            List<long> foundPrimes = new List<long> { 2 };
            long sampleStart = 3;
            long largestSample = 2;

            while (largestSample < maxNum)
            {
                var realSampleSize = maxNum - largestSample < sampleSize ? (int)(maxNum - largestSample) : sampleSize;
                var sample = Enumerable.Repeat(true, realSampleSize).ToArray();

                largestSample = sampleStart + realSampleSize;
                var sqrt = Math.Sqrt(largestSample);

                foreach (var prime in foundPrimes)
                {
                    if (prime > sqrt)
                    {
                        // None of the composite numbers in our current sample will be divisible by a prime > sqrt.
                        break;
                    }

                    var multiple = prime * (sampleStart / prime); // The largest multiple less than or equal to sampleStart.
                    multiple += multiple < sampleStart ? prime : 0;
                    while (multiple < largestSample)
                    {
                        sample[multiple - sampleStart] = false;
                        multiple += prime;
                    }
                }
                for (int i = 0; i < sample.Length; i++)
                {
                    if (sample[i])
                    {
                        var prime = sampleStart + i;
                        foundPrimes.Add(prime);

                        var multiple = prime * 2;
                        while (multiple < largestSample)
                        {
                            sample[multiple - sampleStart] = false;
                            multiple += prime;
                        }
                    }
                }

                sampleStart = largestSample;
            }

            return foundPrimes;
        }

        public static bool IsPrime(long prime)
        {
            if(prime < 2)
            {
                return false;
            }

            long sqrt = (long)Math.Sqrt(prime);
            foreach(var i in FindPrimes(sqrt))
            {
                if(prime % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}