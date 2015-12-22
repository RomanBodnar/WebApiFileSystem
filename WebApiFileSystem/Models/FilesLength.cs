using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
namespace WebApiFileSystem.Models
{
    public class DirectoryContent
    {
        [JsonProperty("parent")]
        public DirectoryInfo Parent { get; set; }
        [JsonProperty("directories")]
        public DirectoryInfo[] Directories { get; set; }
        [JsonProperty("files")]
        public FileInfo[] Files { get; set; }
    }
    public class FilesLength
    {
        [JsonProperty("to_ten")]
        public int ToTen { get; set; }
        [JsonProperty("ten_to_fifty")]
        public int TenToFifty { get; set; }
        [JsonProperty("above_hundred")]
        public int AboveHundred { get; set; }
    }
}
