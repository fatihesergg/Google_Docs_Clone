
namespace Google_Docs_Clone.Models.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly AppDbContext _context;

        public DocumentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Document document)
        {
           _context.Documents.Add(document);
        }

        public void DeleteById(int id)
        {
            Document doc = GetById(id);
            _context.Documents.Remove(doc);
        }

        public List<Document> GetAll()
        {
            List<Document> documents = _context.Documents.ToList();
            return documents;
        }

        public Document GetById(int id)
        {
            Document doc = _context.Documents.Find(id);
            return doc;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<Document> Search(string query)
        {
            var result = _context.Documents.Where(doc => doc.Content.Contains(query) || doc.Content.Contains(query)).ToList();
            return result;
        }

        public void Update(Document document)
        {
            _context.Documents.Update(document);
        }
    }
}
