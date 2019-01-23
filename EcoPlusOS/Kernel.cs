using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace EcoPlusOS
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
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
            Console.Write("Oui j'adore le ");
            Console.WriteLine(input);
        }
    }
}
