using System.Collections.Generic;
using Cosmos.System.Graphics;
using EcoPlusOS.UI;

namespace EcoPlusOS.Commands
{
    public class GraphicsCommand : ICommand
    {
        public List<string> Names { get; } = new List<string>
        {
            "graphiques",
            "graphics",
            "ui",
            "interface"
        };

        public string Description => "Montre des jolis graphiques à prix Leclerc.";

        public void Execute(string parameter = null)
        {
            var env = new UIEnvironment();
        }
    }
}