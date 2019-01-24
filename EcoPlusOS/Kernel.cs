using Cosmos.System.ScanMaps;
using EcoPlusOS.Commands;
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
            Console.Write("éco+> ");
            var input = Console.ReadLine();
            foreach (var command in AllCommands)
            {
                foreach (var name in command.Names)
                {
                    if (input.StartsWith(name, StringComparison.OrdinalIgnoreCase))
                    {
                        try
                        {
                            string param = null;
                            if (input.TrimEnd().Length > name.Length)
                            {
                                param = input.Substring(name.Length).Trim();
                            }

                            command.Execute(param);
                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Nous sommes désolés, mais une erreur s'est produite et Leclerc s'en excuse.");
                            Console.WriteLine("Un paquet de 10 hamburgers éco+ vous sera livré sous peu.");
                            Console.WriteLine("Voici quelques informations que nos ingénieurs informatiques professionels peuvent utiliser :");
                            Console.WriteLine($"{e.Message}");
                            PrintDebug($"Exception {e.Message}");
                            Console.ResetColor();
                        }
                        return;
                    }
                }
            }
            Console.WriteLine("Désolé, mais nous avons trouvé aucune commande correspondante à la votre.");
        }

        private static readonly ICommand[] AllCommands =
        {
            new HelpCommand(),
            new GraphicsCommand(),
            new BenchmarkTestCommand(),
            new DebugCommand(),
            new ShutdownCommand()
        };

        private class HelpCommand : ICommand
        {
            public string[] Names { get; } =
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
                foreach (var cmd in AllCommands)
                {
                    Console.WriteLine($"{cmd.Names[0]} -> {cmd.Description ?? "Leclerc ne connait rien sur cette commande"}");
                }
            }
        }
    }
}
