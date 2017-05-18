using WormsStats.ReplayExtractor;

namespace WormsStats.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string wormsPath = @"C:\Program Files (x86)\Steam\steamapps\common\Worms Armageddon\";
            const string replayPath = @"C:\Program Files (x86)\Steam\steamapps\common\Worms Armageddon\User\Games\";

            var replayExtractor = new ReplayLogExtractor(wormsPath, replayPath);
            replayExtractor.ExtractAll();

            System.Console.ReadKey();
        }
    }
}
