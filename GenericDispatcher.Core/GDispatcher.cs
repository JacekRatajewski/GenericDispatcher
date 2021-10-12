using Newtonsoft.Json;
using System.Text;

namespace GenericDispatcher.Core
{
    public class GDispatcher<T>
    {
        public static async Task<T> Dispatch(string path, Encoding encoding = null) => JsonConvert.DeserializeObject<T>(encoding is null ? await new StreamReader(path).ReadToEndAsync() : encoding.GetString(Encoding.Default.GetBytes(await new StreamReader(path).ReadToEndAsync())));

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
