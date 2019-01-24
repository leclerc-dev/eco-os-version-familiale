using Cosmos.Core;
using System;
using System.Collections.Generic;

namespace EcoPlusOS.Commands
{
    public class BenchmarkTestCommand : ICommand
    {
        public List<string> Names { get; } = new List<string>
        {
            "performance",
            "perftest",
            "pf"
        };

        public string Description => "Fait un test de performance, à vitesse Leclerc.";

        public unsafe void Execute(string parameter = null)
        {
            if (parameter == null || !int.TryParse(parameter, out var length))
            {
                length = 64000;
            }
            var array = new int[length];
            var points = new[]
            {
                4,2,3
            };
            fixed (int* dest = array)
            {
                MemoryOperations.Fill(dest, 42, length);
            }
            Console.WriteLine($"Voilà super rapide les {length} éléments ptdr *transition Leclerc*");
        }
    }
}