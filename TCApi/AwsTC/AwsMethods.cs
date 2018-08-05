using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime.Internal.Util;
using Amazon.S3;
using Amazon.S3.Model;

// Add using statements to access AWS SDK for .NET services. 
// Both the Service and its Model namespace need to be added 
// in order to gain access to a service. For example, to access
// the EC2 service, add:
// using Amazon.EC2;
// using Amazon.EC2.Model;

namespace AwsTC
{
    public class AwsMethods : IAwsMethods
    {
        private readonly RegionEndpoint _bucketRegion = RegionEndpoint.EUCentral1;
        private readonly IAmazonS3 _amazonS3Client;

        public AwsMethods(IAmazonS3 amazonS3Client)
        {
            _amazonS3Client = amazonS3Client;
        }

        private const string BucketName = "diehotestbucket";

        // Specify your bucket region (an example region is shown).
 

        public async Task<string> GetData(string name)
        {
            GetObjectRequest request = new GetObjectRequest
            {
                BucketName = BucketName,
                Key = name
            };
            using (GetObjectResponse response = await _amazonS3Client.GetObjectAsync(request))
            using (Stream responseStream = response.ResponseStream)
            using (StreamReader reader = new StreamReader(responseStream))
            {
                return reader.ReadToEnd(); // Now you process the response body.
            }

        }

        //public async Task<string> UploadData(string name, string data)
        //{

        //    return "";
        //}
    }
}