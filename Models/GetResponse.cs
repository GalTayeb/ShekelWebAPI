namespace ShekelWebAPI.Models
{
    public class GetResponse
    {
        public int StatusCode {  get; set; }
        public string StatusMessage { get; set; }
        public List<Group> List { get; set; }
    }
}
