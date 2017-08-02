using System;
using System.Collections.Generic;
using AbstractTunes.Data.Models;
using AbstractTunes.Data.Models.Accounts;
using AbstractTunes.Data.Models.Songs;
using AbstractTunes.Data.Storage.Repositories;
using AbstractTunes.Data.Storage.Repositories.Audio;
using AbstractTunes.Data.Storage.Repositories.Metadata;
using AbstractTunes.Data.Storage.Repositories.Shared;

namespace AbstractTunes.Data.Storage
{
    public class SongDataStore
    {
        private readonly IAudioFileRepository _audioFileRepository;
        private readonly IMetadataRepository _metadataRepository;


        public SongDataStore(AccountSubscriptionType accountSubscriptionType)
        {
            _metadataRepository = new StandardRepository();

            switch (accountSubscriptionType)
            {
                case AccountSubscriptionType.Standard:
                    _audioFileRepository = new StandardRepository();
                    break;
                case AccountSubscriptionType.Premium:
                    _audioFileRepository = new PremiumAudioFileRepository();
                    break;
            }
        }


        public IEnumerable<Song> GetAllSongs()
        {
            var allSongMetadata = _metadataRepository.GetAllSongMetadata();

            var songs = new List<Song>();
            foreach (var songMetadata in allSongMetadata)
            {
                var audioFile = _audioFileRepository.Get(songMetadata.Title);

                var song = new Song
                {
                    File = audioFile,
                    Metadata = songMetadata
                };

                songs.Add(song);
            }

            return songs;
        }


        public Song GetSong(int songId)
        {
            var metadata = _metadataRepository.GetSongMetadata(songId);
            var audioFile = _audioFileRepository.Get(metadata.Title);
            
            return new Song
            {
                File = audioFile,
                Metadata = metadata
            };
        }


        public void SaveSong(Song song)
        {
            _metadataRepository.SaveSongMetadata(song.Metadata);
            _audioFileRepository.Save(song.File);
        }


        public void UpdateSong(int songId, Song song)
        {
            _metadataRepository.UpdateSongMetadata(songId, song.Metadata);
            _audioFileRepository.Save(song.File);
        }


        public void DeleteSong(int songId)
        {
            _metadataRepository.DelteSongMetadata(songId);
        }
    }
}
