using InstagramApiSharp.Classes;
using System.Threading.Tasks;

namespace Cse.Coding.Dojo.Instagram.Helpers
{
    public class ExtractHelper
    {
        public async Task<bool> ExtractBoolResultFromFunctionAsync(Task<IResult<bool>> booleanResultTask)
        {
            IResult<bool> result = await booleanResultTask;
            return result.Value && result.Succeeded;
        }
    }
}
