
using DAL.IRepositoryEntity;
using DAL.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryEntity
{
    public class FornecedorRepository : Repository<fornecedor>, IFornecedorRepository
    {

      /*  public long ListarTotal()
        {
            return this.Count();
        }

        public long ListarClientMaior1000()
        {
            return this.Count(t => t.idade > 1000);
        }

        public long ListarClientMenor1000()
        {
            return this.Count(t => t.idade < 1000);
        }*/
    }

}
