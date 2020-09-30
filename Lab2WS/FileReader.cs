using System.IO;

namespace Lab2WS
{
    class FileReader
    {
        public string[] Read(string filename)
        {
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                return lines;
            }
            else
            {
                return null;
            }
        }
    }
}
