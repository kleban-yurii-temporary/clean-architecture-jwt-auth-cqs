using EduTrack.Contracts.Authentication;
using EduTrack.Domain.Entities;
using EduTrack.WebUI.Shared.Authentication;
using EduTrack.WebUI.Shared.Courses;
using EduTrack.WebUI.Shared.Dtos.Courses;
using EduTrack.WebUI.Shared.Dtos.Invites;
using EduTrack.WebUI.Shared.Dtos.StudentRecords;
using EduTrack.WebUI.Shared.Dtos.SubGroups;
using Mapster;

namespace EduTrack.WebUI.Server.Common.Mapping
{
    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CourseType, CourseTypeDto>();

            config.NewConfig<Course, CourseReadDto>();

            config.NewConfig<Course, CourseWithGroupsAndStudentsDto>()
              .Map(dest => dest.Students, src => src.Students)
              .Map(dest => dest.SubGroups, src => src.SubGroups)
              .Map(dest => dest.GroupsCount, src => Math.Max(src.LabsGroupsCount, src.PracticeGroupsCount));

            config.NewConfig<CourseInvite, DetailedInviteDto>()
               .Map(dest => dest.CourseId, src => src.Course.Id)
               .Map(dest => dest.CourseTitle, src => src.Course.Title)
               .Map(dest => dest.GroupCode, src => src.Course.GroupCode);

            config.NewConfig<StudentRecord, StudentRecordReadDto>()
             .Map(dest => dest.SubGroup, src => src.SubGroup);



            /*config.NewConfig<AuthenticationResult, AuthenticationResponseDto>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.User);*/
        }
    }
}
