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
    public interface ISiparisDAL : IEntityRepository<Siparis>
    {
        List<Siparis> GetListWithSiparisUrun(Expression<Func<Siparis, bool>> filter = null);
        List<Siparis> GetListWithSiparisUrunOdenmedi(Expression<Func<Siparis, bool>> filter = null);
        List<Siparis> GetListWithSiparisUrunOdendi(Expression<Func<Siparis, bool>> filter = null);
        void DeleteWithSiparisUrun(Siparis Siparis);

    }
}
