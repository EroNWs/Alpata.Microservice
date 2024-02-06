namespace Meeting.Dtos.MeetingCrudDtos;

public class MeetingBaseDto
{
    public string MeetingName { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime FinishDateTime { get; set; }
    public string MeetingDescription { get; set; }
    public string DocumentPath { get; set; }

}
