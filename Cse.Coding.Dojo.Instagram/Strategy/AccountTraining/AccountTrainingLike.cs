﻿
using Cse.Coding.Dojo.Instagram.Services.InstagramApi;
using System.Threading.Tasks;

namespace Cse.Coding.Dojo.Instagram.Strategy.AccountTraining
{
    internal class AccountTrainingLike : IAccountTraining
    {
        Task<bool> IAccountTraining.AccountTraining(InstagramApi instagramApi)
        {
            throw new System.NotImplementedException();
        }
    }
}
