namespace FlowerShop.UI.Models.ErrorModel
{
    public class RegisterErrorResponse
    {
        public string type { get; set; }
        public string title { get; set; }
        public int status { get; set; }
        public Dictionary<string, string[]> errors { get; set; }
    }
}
