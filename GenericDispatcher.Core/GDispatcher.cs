using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GenericDispatcher.Core
{
    public class GDispatcher<T>
    {
        public static async Task<T> Dispatch(string path, Encoding encoding = null) => JsonConvert.DeserializeObject<T>(await new StreamReader(path, encoding, true).ReadToEndAsync());

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
