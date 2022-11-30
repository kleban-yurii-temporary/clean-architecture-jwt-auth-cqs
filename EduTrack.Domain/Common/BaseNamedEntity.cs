using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Domain.Common
{
    public class BaseNamedEntity : BaseEntity
    {
        public string Name { get; set; }
    }
}
