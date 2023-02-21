namespace DogWalker.Domain.DTO.Walker;

public class ScheduleDto
{
    public DayOfWeek DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }
}