using WormsStats.ReplayExtractor;

namespace WormsStats.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string wormsPath = @"D:\Games\steamapps\common\Worms Armageddon\";
            const string replayPath = @"D:\Games\steamapps\common\Worms Armageddon\User\Games\";

            var replayExtractor = new ReplayLogExtractor(wormsPath, replayPath);
            replayExtractor.ExtractAll();

            System.Console.ReadKey();
        }
    }
}
