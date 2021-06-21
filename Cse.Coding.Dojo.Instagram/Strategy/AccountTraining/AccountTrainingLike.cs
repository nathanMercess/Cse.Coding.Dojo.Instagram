
using Cse.Coding.Dojo.Instagram.Services.InstagramApi;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cse.Coding.Dojo.Instagram.Strategy.AccountTraining
{
    internal class AccountTrainingLike : IAccountTraining
    {
        async Task<bool> IAccountTraining.AccountTraining(InstagramApi instagramApi)
        {
            try
            {
                string[] allUserName = new string[] { "nathan_merces", "augustoarvelos", "henriquepn99", "marcoancarvalho", "leopeli" };

                string randomUsername = allUserName.OrderBy(x => Guid.NewGuid()).First();
                
                InstaMediaList mediaList = await instagramApi.GetPostsInstagramFromUsernameAsync(randomUsername);
                string[] midiaIdlist = mediaList.Select(x => x.Pk).ToArray();

                foreach (var item in midiaIdlist)
                {
                    await instagramApi.LikeMediaInstagramAsync(item);
                }
                return true;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
