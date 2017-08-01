using eCommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Business.Abstract
{
    public interface ISepetService
    {
        List<Sepet> GetAll();
        void Add(Sepet sepet);
        void AddUrunToSepet(int sepetId, SepetUrun sepetUrun);
        void Update(Sepet sepet);
        void Delete(Sepet sepet);
        Sepet GetById(int sepetId);

    }

}
