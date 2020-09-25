using System.IO;

namespace Lab2WS
{
    class FileReader
    {
        public string[] Read(string filename)
        {
            if (!File.Exists(filename))
            {
                return null;
            }
            else
            {
                string[] lines = File.ReadAllLines(filename);
                return lines;
            }
        }
    }
}
