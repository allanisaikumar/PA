namespace PA.Api.Models;

public class LogDetail
{
    public string ID { get; set; }
    public DateTime? RequestTime { get; internal set; }
    public string Request { get; internal set; }
    public DateTime? ResponseTime { get; internal set; }
    public string Response { get; internal set; }
    public string Duration { get; internal set; }
}