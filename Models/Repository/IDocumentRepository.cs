namespace Google_Docs_Clone.Models.Repository
{
    public interface IDocumentRepository
    {
        public List<Document> GetAll();
        public Document GetById(int id);
        public void Add(Document document);
        public void Update(Document document);
        public void DeleteById(int id);
        public void SaveChanges();
        public List<Document> Search(string query);
    }
}
