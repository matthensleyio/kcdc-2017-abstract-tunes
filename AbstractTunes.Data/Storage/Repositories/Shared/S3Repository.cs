using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;

namespace AbstractTunes.Data.Storage.Repositories.Shared
{
    public abstract class S3Repository
    {
        private readonly AmazonS3Client _s3Client;

        protected S3Repository()
        {
            var awsAccessId = "MyAwsAccount";
            var awsSecretKey = "ItsASecret";
            _s3Client = new AmazonS3Client(awsAccessId, awsSecretKey);
        }


        protected void UploadFile(string filePath, string fileContent)
        {
            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream);

            streamWriter.Write(fileContent);
            memoryStream.Position = 0;

            var uploadPartRequest = new UploadPartRequest
            {
                BucketName = "MyAwsBucket",
                FilePath = filePath,
                InputStream = memoryStream
            };

            _s3Client.UploadPart(uploadPartRequest);
        }


        protected string DownloadFile(string filePath)
        {
            var s3Object = _s3Client.GetObject("MyAwsBucket", filePath);

            var streamReader = new StreamReader(s3Object.ResponseStream);

            return streamReader.ReadToEnd();
        }
    }
}
