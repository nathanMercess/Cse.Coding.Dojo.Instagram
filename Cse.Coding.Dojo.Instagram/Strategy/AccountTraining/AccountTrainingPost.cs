using Cse.Coding.Dojo.Instagram.Services.Bogus;
using Cse.Coding.Dojo.Instagram.Services.InstagramApi;
using InstagramApiSharp.Classes.Models;
using System.Threading.Tasks;

namespace Cse.Coding.Dojo.Instagram.Strategy.AccountTraining
{
    internal class AccountTrainingPost : IAccountTraining
    {
        private BogusImageProvider _bogusImageProvider;

        async Task<bool> IAccountTraining.AccountTraining(InstagramApi instagramApi)
        {
            _bogusImageProvider = new BogusImageProvider();
            try
            {
                InstaImageUpload imageUpload = new InstaImageUpload();
                imageUpload.ImageBytes = await _bogusImageProvider.RandomByteImageAsync();
                await instagramApi.CreatePostInstagram(imageUpload, "Qualquer legenda");
                return true;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
    }
}
