using System;
namespace EcoPlusOS.Commands
{
    public class BenchmarkTestCommand : ICommand
    {
        public string[] Names { get; } =
        {
            "performance",
            "perftest",
            "pf"
        };

        public string Description => "Fait un test de performance, à vitesse Leclerc.";

        public void Execute(string parameter = null)
        {
            if (parameter == null || !int.TryParse(parameter, out var length))
            {
                length = 64000;
            }
            var array = new int[length];
            for (var i = 0; i + 9 < array.Length; i += 9)
            {
                Array.Copy(new[] { 5, 2, 8, 4, 5, 6, 7, 8, 9 }, 0, array, i, 9);
            }
            Console.WriteLine($"Voilà super rapide les {length} éléments ptdr *transition Leclerc*");
        }
    }
}