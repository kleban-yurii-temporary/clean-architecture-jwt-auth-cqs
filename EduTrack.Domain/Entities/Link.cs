using EduTrack.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Domain.Entities
{
    public class Link : BaseEntity
    {
        public string Url { get; set; }
    }

    public class BrandIcons
    {
        [Key]
        public string Key { get; set; }
        public string Domain { get; set; }
        public string Title { get; set; }
        public string IconCss { get; set; }
    }
}
