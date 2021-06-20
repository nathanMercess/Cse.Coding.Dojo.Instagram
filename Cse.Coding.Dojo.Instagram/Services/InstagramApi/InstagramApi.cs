using Cse.Coding.Dojo.Instagram.Helpers;
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

        public async Task<IResult<bool>> LikeMediaInstagramAsync(string mediaId)
            => await _instaApiSdk.MediaProcessor.LikeMediaAsync(mediaId);

        public async Task<InstaComment> CommentMediaInstagramAsync(string mediaId, string text)
            => await ExtractResultFromFunctionAsync(_instaApiSdk.CommentProcessor.CommentMediaAsync(mediaId, text));

        public async Task<InstaMediaList> GetPostsInstagramFromUsernameAsync(string userName)
            => await ExtractResultFromFunctionAsync(_instaApiSdk.UserProcessor.GetUserMediaAsync(userName, null));

        public bool GetIsUserAuthenticated() => _instaApiSdk.IsUserAuthenticated;

        private async Task<T> ExtractResultFromFunctionAsync<T>(Task<IResult<T>> ResultTask)
        {
            try
            {
                IResult<T> result = await ResultTask;
                return result.Value;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }
    }
}
