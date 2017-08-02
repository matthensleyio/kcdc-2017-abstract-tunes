using System.Collections.Generic;
using AbstractTunes.Data.Models.Songs;

namespace AbstractTunes.Data.Storage.Repositories.Metadata
{
    public interface IMetadataRepository
    {
        IEnumerable<SongMetadata> GetAllSongMetadata();

        SongMetadata GetSongMetadata(int songId);

        void SaveSongMetadata(SongMetadata metadata);

        void UpdateSongMetadata(int songId, SongMetadata metadata);

        void DelteSongMetadata(int songId);
    }
}
