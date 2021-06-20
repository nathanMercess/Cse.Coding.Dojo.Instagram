using Bogus;
using System.Net;
using System.Threading.Tasks;

namespace Cse.Coding.Dojo.Instagram.Services.Bogus
{
    public class BogusImageProvider
    {
        private Faker _faker;

        public async Task<byte[]> RandomByteImageAsync()
        {
            _faker = new Faker();
            using WebClient myWebClient = new WebClient();
            string pictureUrl = _faker.Image.LoremFlickrUrl();
            return await myWebClient.DownloadDataTaskAsync(pictureUrl); 
        }

    }
}
