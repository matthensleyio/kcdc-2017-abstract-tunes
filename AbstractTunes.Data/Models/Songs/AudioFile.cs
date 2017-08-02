using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractTunes.Data.Models.Songs
{
    public enum AudioFileType
    {
        Mp3,
        Wav
    }


    public class AudioFile
    {
        [Key]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Audio File Name")]
        public string Name { get; set; }

        [Display(Name = "Audio File Type")]
        public AudioFileType Type { get; set; }

        [Required]
        public byte[] FileBytes { get; set; }


        public AudioFile()
        {
            FileBytes = new byte[0];
        }

        public AudioFile(byte[] fileBytes)
        {
            FileBytes = fileBytes;
        }
    }
}
