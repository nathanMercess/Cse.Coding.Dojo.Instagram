using Cse.Coding.Dojo.Instagram.Services.InstagramApi;
using InstagramApiSharp.Classes.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cse.Coding.Dojo.Instagram.Strategy.AccountTraining
{
    internal class AccountTrainingComment : IAccountTraining
    {
        async Task<bool> IAccountTraining.AccountTraining(InstagramApi instagramApi)
        {
            try
            {
                InstaMediaList mediaList = await instagramApi.GetPostsInstagramFromUsernameAsync("nathan_merces");
                string[] mediaIdlist = mediaList.Select(x => x.Pk).ToArray();
                string mediaId = mediaIdlist.OrderBy(x => Guid.NewGuid()).First();

                await instagramApi.CommentMediaInstagramAsync(mediaId, "um teste qualquer");

                return true;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
