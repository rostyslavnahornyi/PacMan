using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading;

namespace PacMan
{
    class Program
    {
        static void Main(string[] args)
        {
            new Runner().Run();
            Console.ReadKey();
        }
    }
}
