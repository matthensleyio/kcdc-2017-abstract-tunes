using System.Collections.Generic;
using System.IO;

namespace AbstractTunes.Data.Storage.Repositories.Shared
{
    public abstract class FileSystemRepository
    {
        protected void SaveFile(string fileContents, string filePath)
        {
            File.WriteAllText(filePath, fileContents);
        }

        protected string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        protected void DeleteFile(string filePath)
        {
            File.Delete(filePath);
        }
    }
}