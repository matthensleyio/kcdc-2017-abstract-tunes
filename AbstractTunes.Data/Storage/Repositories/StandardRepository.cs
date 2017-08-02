using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using AbstractTunes.Data.Models.Songs;
using AbstractTunes.Data.Storage.Repositories.Audio;
using AbstractTunes.Data.Storage.Repositories.Metadata;

namespace AbstractTunes.Data.Storage.Repositories
{
    public class StandardRepository: IAudioFileRepository, IMetadataRepository
    {
        public void Save(AudioFile audio)
        {
            using (var dataContext = new AbstractTunesDataContext())
            {
                dataContext.AudioFiles.Add(audio);

                dataContext.SaveChanges();
            }
        }

        public AudioFile Get(string fileName)
        {
            using (var dataContext = new AbstractTunesDataContext())
            {
                return dataContext.AudioFiles.FirstOrDefault(af => af.Name == fileName);
            }
        }

        public IEnumerable<AudioFile> GetAll()
        {
            using (var dataContext = new AbstractTunesDataContext())
            {
                return dataContext.AudioFiles.ToList();
            }
        }

        public IEnumerable<SongMetadata> GetAllSongMetadata()
        {
            using (var dataContext = new AbstractTunesDataContext())
            {
                return dataContext.SongMetadata
                    .Include(sm => sm.AlbumInfo)
                    .ToList();
            }
        }

        public SongMetadata GetSongMetadata(int songId)
        {
            using (var dataContext = new AbstractTunesDataContext())
            {
                return dataContext.SongMetadata
                    .Include(sm => sm.AlbumInfo)
                    .FirstOrDefault(sm => sm.SongId == songId);
            }
        }

        public void SaveSongMetadata(SongMetadata metadata)
        {
            using (var dataContext = new AbstractTunesDataContext())
            {
                dataContext.Albums.Add(metadata.AlbumInfo);
                dataContext.SongMetadata.Add(metadata);

                dataContext.SaveChanges();
            }
        }

        public void UpdateSongMetadata(int songId, SongMetadata metadata)
        {
            using (var dataContext = new AbstractTunesDataContext())
            {
                metadata.SongId = songId;
                dataContext.SongMetadata.AddOrUpdate(metadata);

                dataContext.SaveChanges();
            }
        }

        public void DelteSongMetadata(int songId)
        {
            using (var repository = new AbstractTunesDataContext())
            {
                var metadata = repository.SongMetadata
                    .Include(sm => sm.AlbumInfo)
                    .FirstOrDefault(sm => sm.SongId == songId);
                repository.SongMetadata.Remove(metadata);

                repository.SaveChanges();
            }
        }
    }




    public class AbstractTunesDataContext : DbContext
    {
        public virtual DbSet<AudioFile> AudioFiles { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<SongMetadata> SongMetadata { get; set; }


        public AbstractTunesDataContext()
            : base("SqlConnection")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}