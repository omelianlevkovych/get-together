using Application.DTOs.Activities;
using Domain.Entities;

namespace Application.Common.Mapper
{
    public class Mapper : IMapper
    {
        public ActivityEntity MapActivityDtoToEntity(ActivityDto dto)
        {
            return new ActivityEntity
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Category = dto.Category,
                City = dto.City,
                Date = dto.Date,
                Venue = dto.Venue,
            };
        }

        public ActivityDto MapActivityToDto(ActivityEntity entity)
        {
            return new ActivityDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Category = entity.Category,
                City = entity.City,
                Date = entity.Date,
                Venue = entity.Venue,
            };
        }

        public IEnumerable<ActivityDto> MapActivityToDto(IEnumerable<ActivityEntity> entities)
        {
            return entities.Select(x => MapActivityToDto(x));
        }
    }
}
