using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBox.Model.Models
{
    public class FilesInfo
    {
        public int FilesInfoID { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string ShortUrl { get; set; }
        public bool FileAccess { get; set; }
        public DateTime? WasCreated { get; set; }
        public byte[] FileBytes { get; set; }

        public int UserInfoID { get; set; }
        public virtual UserInfo UserInfo { get; set; }

        public FilesInfo()
        {
            WasCreated = DateTime.Now;
        }
    }
}
