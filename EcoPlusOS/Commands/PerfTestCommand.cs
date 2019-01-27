using Cosmos.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EcoPlusOS.Commands
{
    public class PerfTestCommand : ICommand
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
            var smallerLength = length / 4;
            var array2 = new int[smallerLength];
            var array3 = new int[smallerLength];
            var timeStamp = CStopwatch.GetTimestamp();
            Console.WriteLine($"Test: {smallerLength} elements");
            // no pointer
            for (int i = 0; i < smallerLength; i++)
            {
                array2[i] = i + i * i;
            }
            Console.WriteLine($"Completed with no pointers in {CStopwatch.GetTimestamp() - timeStamp} units");
            timeStamp = CStopwatch.GetTimestamp();
            fixed (int* array3P = array3)
            {
                for (int i = 0; i < smallerLength; i++)
                {
                    *(array3P + i) = i + i * i;
                }
            }       
            Console.WriteLine($"Completed with a pointy pointer in {CStopwatch.GetTimestamp() - timeStamp} units");
        }
    }
}