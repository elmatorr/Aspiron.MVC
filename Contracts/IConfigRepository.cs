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
        public Task<BaseBrowserPageModel> GetConfigValue(string operationName);
        public Task<Boolean> SetConfigValue(string operationName, BaseBrowserPageModel pageModel);
        

    }

}
