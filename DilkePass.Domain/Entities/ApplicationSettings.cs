using DilkePass.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilkePass.Domain.Entities
{
    public class ApplicationSettings: Entity<int>, IAudit
    {
        public string SettingKey { get; private set; } = string.Empty;
        public string SettingValue { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public char IsActive { get; private set; }
        public DateTime? CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
        public string? CreatedBy { get; private set; }
        public string? UpdatedBy { get; private set; }

        public ApplicationSettings()
        {
                
        }

    }
}
