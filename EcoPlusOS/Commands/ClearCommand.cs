using System;
using System.Collections.Generic;

namespace EcoPlusOS.Commands
{
    public class ClearCommand : ICommand
    {
        public List<string> Names => new List<string>
        {
            "effacer",
            "efface",
            "clear",
            "éponge",
            "eponge",
            "ménage",
            "menage"
        };

        public string Description => "Nettoie l'écran à l'aide d'une éponge éco+ Leclerc.";

        public void Execute(string parameter = null)
        {
            Console.Clear();
        }
    }
}