using Google_Docs_Clone.Models;
using Google_Docs_Clone.Models.Repository;
using Google_Docs_Clone.Models.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Google_Docs_Clone.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocumentRepository _repository;

        public DocumentController(IDocumentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Document> allDocuments = _repository.GetAll();
            return View(allDocuments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Document document)
        {
            DocumentValidator validations = new DocumentValidator();
            var result =  validations.Validate(document);
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    ModelState.AddModelError("", failure.ErrorMessage);
                    
                }
                return View(document);
            }
            _repository.Add(document);
            _repository.SaveChanges();
            return RedirectToAction("Details",new {id=document.DocumentID});
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Document document = _repository.GetById(id);
            // Return to create action if document not exists
            if (document == null)
            {
                return RedirectToAction("Create");
            }
            return View(document);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Document document = _repository.GetById(id);
            // Return to create action if document not exists
            if (document == null)
            {
                return RedirectToAction("Create");
            }
            return View(document);
        }

        //[HttpPost]
        //public IActionResult Edit(Document document)
        //{
        //    _repository.Update(document);
        //    _repository.SaveChanges();
        //    return RedirectToAction("Details", new {id=document.DocumentID});
        //}

        [HttpPost]
        public IActionResult Search(string query)
        {
            var result = _repository.Search(query);
            ViewData["query"] = query; 
            return View(result);
        }
    }
}
