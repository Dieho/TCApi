using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwsTC
{
    public interface IAwsMethods
    {
        Task<string> GetData(string name);
        //Task<string> UploadData(string name, string data);
    }
}
