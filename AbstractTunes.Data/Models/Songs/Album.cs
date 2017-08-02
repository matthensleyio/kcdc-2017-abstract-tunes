using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractTunes.Data.Models.Songs
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumId { get; set; }

        [Display(Name = "Album Name")]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Display(Name = "Artwork Link")]
        [Required(AllowEmptyStrings = false)]
        public string ArtworkLink { get; set; }
    }
}
