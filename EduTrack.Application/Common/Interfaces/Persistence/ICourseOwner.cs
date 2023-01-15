using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Common.Interfaces.Persistence
{
    public interface ICourseOwner<T>
    {
        T GetOwnerId(T objectId);
    }
}
