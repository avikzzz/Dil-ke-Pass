using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Domain.Common
{
    public interface IAudit
    {
        DateTime? CreatedDate { get;  }
        DateTime? UpdatedDate { get; }
        string? CreatedBy { get;  }
        string? UpdatedBy { get;  }

    }
}
