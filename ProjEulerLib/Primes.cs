using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjEulerLib
{
    public class Primes : IEnumerable<BigInteger>
    {
        private static List<BigInteger> cache = new List<BigInteger>() { 2 };
        private List<BigInteger> list = new List<BigInteger>() { 2 };

        //IEnumerable<>
        public IEnumerator<BigInteger> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        //Extension methods
        public static bool IsPrime(this int n)
        {
            return IsPrime((BigInteger)n);
        }

        public static bool IsPrime(this BigInteger n)
        {
            while (cache.Last() < n)
            {
                CalculateNext();
            }

            return cache.Contains(n);
        }

        //private methods
        private static void CalculateNext()
        {
            var i = cache.Last() + 1;

            while (!cache.Where(prime => i % prime == 0).Any())
            {
                i++;
            }

            cache.Add(i);
        }

        //public methods
        public BigInteger Next()
        {
            var nextPrime = cache.Where(prime => prime > list.Last()).FirstOrDefault();

            if (nextPrime != null)
            {
                return nextPrime;
            }
            else
            {
                CalculateNext();
                return cache.Last();
            }
        }

        public void CalculateUpTo(BigInteger n)
        {
            while (Next() < n)
            {
                list.Add(Next());
            }
        }
    }
}
