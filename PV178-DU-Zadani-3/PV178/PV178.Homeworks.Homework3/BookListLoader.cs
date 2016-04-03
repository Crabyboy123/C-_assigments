using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.
namespace PV178.Homeworks.Homework3
{
    public class BookListLoader : IBookListLoader
    {
        private string FilePath_;
        public BookListLoader(string FilePath)
        {
            if (String.IsNullOrEmpty(FilePath))
                throw new ArgumentException("Path is null or empty");
            FilePath_ = FilePath;   
        }
        public IEnumerable<BookListRecord> LoadList()
        {
            byte[] unzip;
            using(FileStream fs = new FileStream(FilePath_,FileMode.Open))
            {
                using (GZipStream gz = new GZipStream(fs, CompressionMode.Decompress))
                {
                    string line;
                    using (StreamReader sr = new StreamReader(gz))
                        while((line = sr.ReadLine()) != null)
                        {
                            string[] values = line.Split(';');
                            
                        }
                }
            }
        }
    }
}
