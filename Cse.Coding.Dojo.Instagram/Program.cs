using Cse.Coding.Dojo.Instagram.Services.Bogus;
using Cse.Coding.Dojo.Instagram.Strategy.AccountTraining;
using Cse.Coding.Dojo.Instagram.Strategy.Enum;
using Cse.Coding.Dojo.Instagram.Services.InstagramApi;
using System.Threading.Tasks;
using Bogus;
using InstagramApiSharp.API;
using InstagramApiSharp.Classes;

namespace Cse.Coding.Dojo.Instagram
{
    public class Program
    {
        private static AccountTrainingContext AccountTrainingContext;
        private static InstagramApi InstaApi;
        static void Main(string[] args)
        {
            var result = Task.Run(MainAsync).GetAwaiter().GetResult();
            if (result)
                return;
        }

        private static async Task<bool> MainAsync()
        {
            InstaApi = new InstagramApi();
            AccountTrainingContext = new AccountTrainingContext();

            var userSession = new UserSessionData
            {
                UserName = "nathanmerces",
                Password = "cse12345"
            };

            InstaApi.SetBuild(userSession);

            if (!InstaApi.GetIsUserAuthenticated()) 
            {
                var logInResult = await InstaApi.InstagramLoginAsync();
                if (!logInResult.Succeeded)
                {
                    return false;
                }
            }

            await AccountTrainingContext.AccountTraining(AccountTrainingTypeEnum.POST, InstaApi);
            return true;
        }
    }
}
