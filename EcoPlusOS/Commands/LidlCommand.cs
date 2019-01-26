using System.Collections.Generic;
using System;
using Cosmos.Core;

namespace EcoPlusOS.Commands
{
    public class LidlCommand : ICommand
    {
        public List<string> Names { get; } = new List<string>
        {
            "lidl"
        };

        public string Description => "N'utilisez surtout pas cette commande.";

        public void Execute(string parameter = null)
        {
            Console.WriteLine($"nique bien ta grosse race");
        }
    }
}