using eCommerce.Core.DataAccess;
using eCommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DataAccess.Abstract
{
    public interface ISepetDAL : IEntityRepository<Sepet>
    {
        void AddUrunToSepet(int sepetId, SepetUrun sepetUrun);
        void RemoveUrunFromSepet(int sepetId, int sepeturunId);

        List<Sepet> GetList(Expression<Func<Sepet, bool>> filter = null, Expression<Func<Sepet, SepetUrun>> IncludeTableExp1 = null);
        
        List<SepetUrun> GetListSepetUrun(Expression<Func<SepetUrun, bool>> filter = null);

    }
}
