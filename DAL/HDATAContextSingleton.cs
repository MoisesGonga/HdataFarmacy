using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class HDATAContextSingleton
    {
        private static HDATAContext instance;

        static HDATAContextSingleton() { }

        public static HDATAContext Instance
        {
            get
            {
                if (instance == null)
                    instance = new HDATAContext();
                return instance;
            }
        }
    }
}
