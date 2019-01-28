using System;
using System.Collections.Generic;
using System.Text;

namespace EcoPlusOS.Commands
{
    public class EcoverCommand : ICommand
    {
        public List<string> Names { get; } = new List<string>
        {
            "ecover",
            "winver",
            "about",
            "version"
        };

        public string Description => "éco+os version 1.0 build 1000 !!! (c) 2019 leclerc corporation";

        public void Execute(string parameter = null)
        {
            
        }
    }
}