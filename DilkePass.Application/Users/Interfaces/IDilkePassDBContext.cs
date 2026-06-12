using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Application.Users.Interfaces
{
    public interface IDilkePassDBContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        // IDbContextTransaction This is an inbuilt Interface from EntityFrameworkCore.Storage 
        // It manages the transactions. using var 
        Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel);
    }
}
