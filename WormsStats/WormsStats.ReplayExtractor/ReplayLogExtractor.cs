using System.Diagnostics;
using System.IO;

namespace WormsStats.ReplayExtractor
{
    public class ReplayLogExtractor
    {
        private readonly string m_WormsReplayPath;
        private readonly string m_WormsExe;

        public ReplayLogExtractor(string wormsPath, string wormsReplayPath)
        {
            m_WormsReplayPath = wormsReplayPath;
            m_WormsExe = Path.Combine(wormsPath, "WA.exe");
        }

        public void ExtractAll()
        {
            var d = new DirectoryInfo(m_WormsReplayPath);

            foreach (var file in d.GetFiles("*.WAgame"))
            {
                ExtractReplayFile(file.Name);
            }
        }

        public void ExtractReplayFile(string fileName)
        {
            var fullPathToReplay = Path.Combine(m_WormsReplayPath, fileName);
            var parameters = $@"/getLog ""{fullPathToReplay}"" /q";

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = m_WormsExe,
                    Arguments = parameters
                }
            };

            proc.Start();
            proc.WaitForExit();
        }
    }
}
