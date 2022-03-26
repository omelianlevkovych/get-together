using Application.DTOs.Activities;
using Domain.Entities;

namespace Application.Common.Mapper
{
    public interface IMapper
    {
        ActivityDto MapActivityToDto(ActivityEntity entity);
        IEnumerable<ActivityDto> MapActivityToDto(IEnumerable<ActivityEntity> entities);
        ActivityEntity MapActivityDtoToEntity(ActivityDto dto);

    }
}
