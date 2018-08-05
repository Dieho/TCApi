using System.Collections.Generic;
using System.Threading.Tasks;

namespace TCApi.AWS
{
    public interface IAwsMethods
    {
        Task<string> GetDataByKeyAsync(string name);
        Task<List<string>> GetAllRecordsNameAsync();
        //Task<string> UploadData(string name, string data);
    }
}
