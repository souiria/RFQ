using System;
using System.Threading.Tasks;
using Common.SF.Contracts.Interfaces.Base;
using Common.SF.Contracts.Interfaces.Base.Base64;

namespace Common.SF.Contracts.Interfaces.GlobalMastersAssociation
{
    public interface ISourceApplicationArticleAssociation : IBase
    {
        Task<string> Get(Guid id);
        Task<string> GetAll();
    }
}