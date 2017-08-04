using System.Collections.Generic;
using AbstractTunes.Data.Models.Songs;

namespace AbstractTunes.Data.Storage.Repositories.Audio
{
    public interface IAudioFileRepository
    {
        void SaveAudioFile(AudioFile audio);

        AudioFile GetAudioFile(string fileName);
    }
}
