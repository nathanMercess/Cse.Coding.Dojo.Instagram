using Cse.Coding.Dojo.Instagram.Services.InstagramApi;
using InstagramApiSharp.Classes;
using System.Threading.Tasks;

namespace Cse.Coding.Dojo.Instagram.Strategy.AccountTraining
{
    public class AccountTrainingLogin : IAccountTraining
    {
        public async Task<bool> AccountTraining(InstagramApi instagramApi)
        {
            if (!instagramApi.GetIsUserAuthenticated())
            {
                InstaLoginResult logInResult = await instagramApi.InstagramLoginAsync();
                if (logInResult == InstaLoginResult.Success)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
