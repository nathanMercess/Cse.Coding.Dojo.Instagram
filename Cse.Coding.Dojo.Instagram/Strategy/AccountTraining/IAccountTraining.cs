using Cse.Coding.Dojo.Instagram.Services.InstagramApi;
using InstagramApiSharp.API;
using System.Threading.Tasks;

namespace Cse.Coding.Dojo.Instagram.Strategy.AccountTraining
{
    interface IAccountTraining
    {
        Task<bool> AccountTraining(InstagramApi instagramApi);
    }
}
