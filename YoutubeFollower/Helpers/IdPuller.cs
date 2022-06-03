using System.Web;

namespace YoutubeFollower.Helpers
{
    public class IdPuller
    {
        private const int ID_LENGTH = 24;
        private const int ID_POSITION = 32;

        private HttpClient _client { get; }
        public IdPuller()
        {
            _client = new HttpClient();
        }


        public async Task<string> PullFrom(string encodedUrl) 
        {
            try
            {
                string Url = HttpUtility.UrlDecode(encodedUrl);// We should decode url to send it to back end

                string id = Url.Substring(ID_POSITION);
                if (id.Length == ID_LENGTH && !id.Contains("/")) // Check if id is already in url
                {
                    return id;
                }
                else
                {
                    string result = await _client.GetStringAsync(Url);

                    int pFrom = result.IndexOf("itemprop=\"channelId\" content=") + "itemprop=\"channelId\" content=\"".Length;
                    int pTo = result.IndexOf("\">");

                    id = result.Substring(pFrom, pTo);
                    id = id.Substring(0, ID_LENGTH);

                    return id;
                }
                Console.WriteLine(id);
            }
            catch
            {
                throw new Exception("Please type in valid url!");
            }
        }
    }
}
