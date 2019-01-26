using Cosmos.System.Graphics;
using Cosmos.System.ScanMaps;
using EcoPlusOS.Commands;
using EcoPlusOS.CustomLinq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Sys = Cosmos.System;

namespace EcoPlusOS
{
    public class Kernel : Sys.Kernel
    {
        public static Kernel Instance { get; private set; }
        protected override void BeforeRun()
        {
            Instance = this;
            SetKeyboardScanMap(new FR_Standard());
            var encoding = Sys.ExtendedASCII.CosmosEncodingProvider.Instance.GetEncoding(437);
            Console.OutputEncoding = encoding;
            Console.InputEncoding = encoding;
            Console.Clear();
            Console.WriteLine("Leclerc vous souhaite la bienvenue");
        }

        protected override void Run()
        {
            try
            {
                RunInternal();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nous sommes désolés, mais une erreur s'est produite et Leclerc s'en excuse.");
                Console.WriteLine("Un paquet de 10 hamburgers éco+ vous sera livré sous peu.");
                Console.WriteLine(
                    "Voici quelques informations que nos ingénieurs informatiques professionels peuvent utiliser :");
                Console.WriteLine($"{e.Message}");
                PrintDebug($"Exception {e.Message}");
                Console.ResetColor();
            }

        }

        private static void RunInternal()
        {
            Console.Write("éco+> ");
            var input = Console.ReadLine();
            if (input is null) return;
            foreach (var command in AllCommands)
            {
                foreach (var name in command.Names)
                {
                    string param = null;
                    if (input.TrimEnd().Length > name.Length)
                    {
                        param = input.Substring(name.Length).Trim();
                    }
                    if (input.StartsWith(name, StringComparison.OrdinalIgnoreCase) && input.Length >= name.Length)
                    {
                        command.Execute(param);
                        return;
                    }
                }
            }
            Console.WriteLine("Désolé, mais Leclerc n'a pas trouvé aucune commande correspondante à la votre.");
        }

        private static readonly List<ICommand> AllCommands = new List<ICommand>
        {
            new HelpCommand(),
            new GraphicsCommand(),
            new BenchmarkTestCommand(),
            new DebugCommand(),
            new ShutdownCommand(),
            new PlaySongCommand(),
            new ClearCommand(),
            new LidlCommand()
        };

        private class HelpCommand : ICommand
        {
            private const string UnknownHelpCommand = "Leclerc ne connait rien sur cette commande";
            public List<string> Names { get; } = new List<string>
            {
                "aide",
                "help",
                "aled",
                "aide-mwa",
                "ausecours",
                "osecours"
            };

            public string Description => "Montre l'aide haute qualité leclerc.";

            public void Execute(string parameter = null)
            {
                if (parameter != null)
                {
                    var selected = AllCommands.Where((val, r) =>
                        r.Value = val.Names.Any((s, innerResult) =>
                            innerResult.Value = s.Equals(parameter, StringComparison.OrdinalIgnoreCase)));
                    if (selected.Any())
                    {
                        var command = selected[0];
                        var builder = new StringBuilder();
                        builder.AppendLine($"Commande {command.Names[0]}");
                        builder.AppendLine($"Description: {command.Description}");
                        builder.AppendLine("Autres noms: ");
                        foreach (var name in command.Names)
                        {
                            builder.Append(name + ", ");
                        }
                        Console.WriteLine(builder.ToString());
                        return;
                    }
                    Console.WriteLine(UnknownHelpCommand);
                    return;
                }
                foreach (var cmd in AllCommands)
                {
                    Console.WriteLine($"{cmd.Names[0]} -> {cmd.Description ?? UnknownHelpCommand}");
                }
            }
        }
    }
}
