using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Data.Service.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool SaveChanges();
    }
}
