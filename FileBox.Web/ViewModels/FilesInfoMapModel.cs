using System;
using System.ComponentModel.DataAnnotations;

namespace FileBox.Web.ViewModels
{
    public class FilesInfoMapModel
    {
        [Required]
        public int FilesInfoID { get; set; }
        [Required(ErrorMessage = "Input filename")]
        public string FileName { get; set; }
        [Required]
        public string Extension { get; set; }
        public string ShortUrl { get; set; }
        public bool FileAccess { get; set; }
        public DateTime? WasCreated { get; set; }
        [Required]
        public int UserInfoID { get; set; }
        public UserInfoMapModel UserInfo { get; set; }
    }
}