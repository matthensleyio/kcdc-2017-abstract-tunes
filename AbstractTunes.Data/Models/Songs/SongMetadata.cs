using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractTunes.Data.Models.Songs
{
    public class SongMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SongId { get; set; }

        [Display(Name = "Artist")]
        [Required(AllowEmptyStrings = false)]
        public string Artist { get; set; }

        [Required(AllowEmptyStrings = false)]
        public Album AlbumInfo { get; set; } = new Album();

        [Display(Name = "Title")]
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Display(Name = "Genre")]
        [Required(AllowEmptyStrings = false)]
        public string Genre { get; set; }
    }
}
