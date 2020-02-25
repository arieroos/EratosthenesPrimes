# EratosthenesPrimes
Finds prime numbers using the sieve of Eratosthenes.

The sieve can be made smaller in case of limited memory. The default size of the sieve is 1000, which means that the sieve alone uses about 8kB of memory by default.

## Usage
```
./EratosthenesPrimes 1234567890 10000
```

The first parameter gives the limit where we will stop searching. The example will search for all primes up to 1 234 567 890. There are 62 106 578 of those primes, and this implementation finds them in 24.07 seconds on my machine.

The second parameter gives the size of the sieve, measured in amount of numbers, which is also the amount of bytes because the sieve is a boolean array.
