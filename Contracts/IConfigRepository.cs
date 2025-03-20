using Aspiron.MVC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspiron.MVC.Contracts
{
    public interface IConfigRepository
    {
        public Task<BaseBrowserPageModel> GetConfigValueAsync(string operationName);
        public Task<Boolean> SetConfigValueAsync(string operationName, BaseBrowserPageModel pageModel);
        

    }

}
