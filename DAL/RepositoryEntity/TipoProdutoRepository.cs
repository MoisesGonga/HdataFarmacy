﻿
using DAL.IRepositoryEntity;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryEntity
{
    public class TipoProdutoRepository : Repository<tipo_produto>, ITipoProdutoRepository
    {

        public long TotalItems()
        {
            return this.Count();
        }

       


    }

}
