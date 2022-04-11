
using Newtonsoft.Json;

namespace ApiContainer.APIMergeOutput
{
    internal class PeekRawData
    {
        public async Task<string> GetResponseString()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://challenges.hackajob.co/swapi/api/films/");
            var contents = await response.Content.ReadAsStringAsync();

            return contents;
        }

        public void RawResults()
        {
            //Identify shape
            Task<string> result = GetResponseString();
            var jsonResult = result.Result;
            var js = JsonConvert.DeserializeObject(jsonResult);
            Console.WriteLine(js);
        }
    }
}
