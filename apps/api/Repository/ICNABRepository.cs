using System.Collections.Generic;
using System.Threading.Tasks;
using api.Model;

namespace api.Repository
{
    public interface ICNABRepository
    {
        IEnumerable<CNABModel> GetAll();
        Task SaveAll(List<CNABModel> cnabList);
    }
}