using BookStore.DAL;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }
        public IActionResult Index()
        {
            var books = from book in _bookRepository.GetBooks() select book;
            
            return View(books);
        }

        public ViewResult Details(int id)
        {
            Book detail = _bookRepository.GetBookbyId(id);
            return View(detail);
        }

        public ActionResult Create()
        {
            return View(new Book());
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookRepository.Insert(book);
                    _bookRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to Save Changes.");
            }
            return View(book);
        }

        public ActionResult Edit(int id)
        {
            Book book = _bookRepository.GetBookbyId(id);
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _bookRepository.Update(book);
                    _bookRepository.Save();
                    return RedirectToAction("Index");
                }    
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to Save Changes");
            }
            return View(book);
        }

        //DeleteHere
        public ActionResult Delete(int id)
        {
                Book book = _bookRepository.GetBookbyId(id);
                return View(book);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteId(int id)
        {
            try
            {
                _bookRepository.Delete(id);
                _bookRepository.Save();
            }
            catch(DataException)
            {
                ModelState.AddModelError("", "Unable to Save Changes");
            }
            return RedirectToAction("Index");
        }
    }
}
