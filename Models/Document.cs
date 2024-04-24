namespace Google_Docs_Clone.Models
{
    public class Document
    {
        public int DocumentID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public DateTime LastAccess = DateTime.Now;
    }
}
