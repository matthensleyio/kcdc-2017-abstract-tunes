using System.Collections.Generic;
using System.Text;
using AbstractTunes.Data.Models.Songs;
using AbstractTunes.Data.Storage.Repositories.Shared;

namespace AbstractTunes.Data.Storage.Repositories.Audio
{
    public class PremiumAudioFileRepository : S3Repository, IAudioFileRepository
    {
        private const string PremiumFileDirectory = @"Premium/Songs/";

        public void SaveAudioFile(AudioFile audio)
        {
            var audioFileContent = Encoding.Default.GetString(audio.FileBytes);

            base.UploadFile(audioFileContent, $"{PremiumFileDirectory}/{audio.Name}");
        }


        public AudioFile GetAudioFile(string fileName)
        {
            var fileContent = base.DownloadFile($"{PremiumFileDirectory}/{fileName}");

            var audioBytes = Encoding.Default.GetBytes(fileContent);

            return new AudioFile(audioBytes);
        }
    }
}