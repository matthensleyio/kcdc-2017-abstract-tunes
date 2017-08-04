using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractTunes.Data.Models.Songs;

namespace AbstractTunes.Data.Storage.Repositories.Metadata
{
    public class MetadataRepository : IMetadataRepository
    {
        private readonly Dictionary<int, SongMetadata> _songMetadata;


        public MetadataRepository()
        {
            _songMetadata = new Dictionary<int, SongMetadata>();
        }


        public IEnumerable<SongMetadata> GetAllSongMetadata()
        {
            return _songMetadata.Values;
        }


        public SongMetadata GetSongMetadata(int songId)
        {
            return _songMetadata[songId];
        }
        

        public void SaveSongMetadata(SongMetadata metadata)
        {
            _songMetadata.Add(metadata.SongId, metadata);
        }


        public void UpdateSongMetadata(int songId, SongMetadata metadata)
        {
            _songMetadata[songId] = metadata;
        }


        public void DelteSongMetadata(int songId)
        {
            _songMetadata.Remove(songId);
        }
    }
}
