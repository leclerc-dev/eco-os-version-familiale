using System;
using System.Collections.Generic;
using System.Text;

namespace EcoPlusOS.Commands
{
    public class KiwiCommand : ICommand
    {
        public List<string> Names { get; } = new List<string>
        {
            "kiwi",
            "kiwindows",
            "KiWindows",
            "Kiwi"
        };

        public string Description => "Un des devs de ce gange éco+";

        public void Execute(string parameter = null)
        {
            
        }
    }
}