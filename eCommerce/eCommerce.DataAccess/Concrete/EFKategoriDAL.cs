using eCommerce.Core.DataAccess.EntityFramework;
using eCommerce.DataAccess.Abstract;
using eCommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DataAccess.Concrete
{
    public class EFKategoriDAL:EFEntityRepositoryBase<Kategori, eCommerceContext>, IKategoriDAL
    {
    }
}
