using Cse.Coding.Dojo.Instagram.Strategy.Enum;
using System.Collections.Generic;

namespace Cse.Coding.Dojo.Instagram.Strategy.AccountTraining
{
    public class AccountTrainingContext
    {
        private readonly Dictionary<AccountTrainingTypeEnum, IAccountTraining> _strategiesContext = new Dictionary<AccountTrainingTypeEnum, IAccountTraining>();

        public AccountTrainingContext()
        {
            _strategiesContext.Add(AccountTrainingTypeEnum.LIKE, new AccountTrainingLike());
            _strategiesContext.Add(AccountTrainingTypeEnum.COMMENTS, new AccountTrainingComment());
            _strategiesContext.Add(AccountTrainingTypeEnum.POST, new AccountTrainingPost());
        }

        public string AccountTraining(AccountTrainingTypeEnum accountTrainingTypeEnum)
        {
            return _strategiesContext[accountTrainingTypeEnum].AccountTraining();
        }
    }
}
