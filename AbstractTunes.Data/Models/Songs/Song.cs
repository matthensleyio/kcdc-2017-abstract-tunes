namespace AbstractTunes.Data.Models.Songs
{
    public class Song
    {
        public AudioFile File { get; set; } = new AudioFile();
        public SongMetadata Metadata { get; set; } = new SongMetadata();
    }
}
