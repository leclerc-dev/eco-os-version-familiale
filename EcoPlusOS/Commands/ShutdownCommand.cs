namespace EcoPlusOS.Commands
{
    public class ShutdownCommand : ICommand
    {
        public string[] Names { get; } =
        {
            "eteindre",
            "shutdown",
            "éteindre",
            "stop",
            "ilsuffit",
            "aplus",
            "àplus",
            "ademain",
            "à-demain",
            "a-demain",
            "ademain",
            "a+",
            "suicide",
            "à plus dans l'bus",
            "a plus dans l'bus",
            "à plus dans le bus",
            "a plus dans le bus",
            "au revoir, messieurs dames",
            "au revoir messieurs dames",
            "au revoir"
        };

        public string Description => "Eteint l'ordi à vitesse Leclerc.";

        public void Execute(string parameter = null)
        {
            Kernel.Instance.Stop();
        }
    }
}