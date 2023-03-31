using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag14.Oefening2AdventOfCode
{
    public class FileParser : IDisposable
    {
        private FileStream stream;
        private string FileName;

        public FileParser(string filename)
        {
            FileName = filename;
            stream = new FileStream(filename, FileMode.Open);
        }

        public void GetHighestNumberFromFile()
        {
            stream.WriteByte(65);

        }
        public void Dispose()
        {
            stream?.Dispose();
        }
    }
}
