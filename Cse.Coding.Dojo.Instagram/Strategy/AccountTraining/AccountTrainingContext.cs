using Cse.Coding.Dojo.Instagram.Services.Bogus;
using Cse.Coding.Dojo.Instagram.Services.InstagramApi;
using Cse.Coding.Dojo.Instagram.Strategy.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cse.Coding.Dojo.Instagram.Strategy.AccountTraining
{
    public class AccountTrainingContext
    {
        private readonly Dictionary<AccountTrainingTypeEnum, IAccountTraining> _strategiesContext = new Dictionary<AccountTrainingTypeEnum, IAccountTraining>();

        public AccountTrainingContext()
        {
            _strategiesContext.Add(AccountTrainingTypeEnum.LOGIN, new AccountTrainingLogin());
            _strategiesContext.Add(AccountTrainingTypeEnum.LIKE, new AccountTrainingLike());
            _strategiesContext.Add(AccountTrainingTypeEnum.COMMENTS, new AccountTrainingComment());
            _strategiesContext.Add(AccountTrainingTypeEnum.POST, new AccountTrainingPost());
        }

        public Task<bool> AccountTraining(AccountTrainingTypeEnum accountTrainingTypeEnum, InstagramApi instagramApi)
        {
            return _strategiesContext[accountTrainingTypeEnum].AccountTraining(instagramApi);
        }
    }
}
