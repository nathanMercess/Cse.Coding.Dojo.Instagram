using InstagramApiSharp.API;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.Models;
using InstagramApiSharp.Logger;
using System.Threading.Tasks;

namespace Cse.Coding.Dojo.Instagram.Services.InstagramApi
{
    public class InstagramApi
    {

        private IInstaApi _instaApiSdk;

        public IInstaApi InstaApiSdk { get; }

        public void SetBuild(UserSessionData userSessionData) => _instaApiSdk = InstaApiBuilder.CreateBuilder()
                                                                        .SetUser(userSessionData)
                                                                        .UseLogger(new DebugLogger(LogLevel.All))
                                                                        .SetRequestDelay(RequestDelay.FromSeconds(2, 2))
                                                                        .Build();
        public async Task<IResult<InstaLoginResult>> InstagramLoginAsync() => await _instaApiSdk.LoginAsync();
        public async Task<IResult<InstaMedia>> CreatePostInstagram(InstaImageUpload image, string caption)
            => await _instaApiSdk.MediaProcessor.UploadPhotoAsync(image, caption);

        public bool GetIsUserAuthenticated() => _instaApiSdk.IsUserAuthenticated;
    }
}
