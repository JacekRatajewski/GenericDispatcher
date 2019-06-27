using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GenericDispatcher
{
    public class GDispatcher<T>
    {
        public static async Task<T> Dispatch(string path, Encoding encoding)
        {
            using (var file = new StreamReader(path))
            {
                string json = await file.ReadToEndAsync();
                var data = JsonConvert.DeserializeObject<T>(encoding.GetString(Encoding.Default.GetBytes(json)));
                return data;
            }
        }

        public static void Adopt(string path, T data)
        {
            using (StreamWriter file = (!File.Exists(path)) ? File.AppendText(path) : File.CreateText(path))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, data);
            }
        }
    }
}
