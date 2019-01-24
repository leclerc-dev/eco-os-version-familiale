using System;
using System.Collections.Generic;
using Cosmos.Core;
using EcoPlusOS.CustomLinq;

namespace EcoPlusOS.Commands
{
    public class DebugCommand : ICommand
    {
        public string[] Names { get; } =
        {
            "débogage",
            "debogage",
            "debug"
        };

        public string Description => "Pour faire un débogage certifié Leclerc.";

        public void Execute(string parameter = null)
        {
            var arr = new List<int> {5, 2};
            Kernel.PrintDebug("array ok");
            Extensions.AnyDelegate<int> predicate = (int val, out bool r) => r = val < 3;
            Kernel.PrintDebug("delegate ok");
            Console.WriteLine("Test any (should be true): " + arr.Any(predicate));
        }
    }
}