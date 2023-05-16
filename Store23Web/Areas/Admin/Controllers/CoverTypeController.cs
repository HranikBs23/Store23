using Microsoft.AspNetCore.Mvc;
using Store23.DataAccess.Repository.IRepository;
using Store23.Models;

namespace Store23Web.Areas.Admin.Controllers;
[Area("Admin")]
public class CoverTypeController : Controller
{

	private readonly IUnitOfWork _unitOfWork;
    public CoverTypeController(IUnitOfWork unitOfWork )
    {
        _unitOfWork = unitOfWork;  
    }
    public IActionResult Index()
	{
        IEnumerable<CoverType> objCoverType = _unitOfWork.CoverType.GetAll();
		return View(objCoverType);
	}

    

	public ActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Create(CoverType objCoverType) {

        if (ModelState.IsValid)
        {
            _unitOfWork.CoverType.Add(objCoverType);
            _unitOfWork.Save();
            
			TempData["Success"] = "CoverType Created Successfully";
			return RedirectToAction("Index");
		}
		return View(objCoverType);
	}
	//Get 

	public IActionResult Edit(int? id)
	{
		if (id == null || id == 0)
		{
			return NotFound();
		}
		var objCoverType = _unitOfWork.CoverType.GetFirstOrDefault(a => a.Id == id);

		if (objCoverType == null)
		{

			return NotFound();
		}

		return View(objCoverType);
	}

	//POST
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Edit(CoverType editObj)
	{
		
		if (ModelState.IsValid)
		{
			_unitOfWork.CoverType.Update(editObj);
			_unitOfWork.Save();
			TempData["Success"] = "CoverType Updated Successfully";
			return RedirectToAction("Index");
		}

		return View(editObj);


	}

	public IActionResult Delete(int? id)
	{
		if (id == null || id == 0)
		{
			return NotFound();
		}
		//var deleteCategory = _db.Categories.Find(id);
		var deleteCoverType = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
		//var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

		if (deleteCoverType == null)
		{
			return NotFound();
		}

		return View(deleteCoverType);
	}

	//POST
	[HttpPost, ActionName("Delete")]
	[ValidateAntiForgeryToken]
	public IActionResult DeletePOST(int? id)
	{
		var deleteCoverType = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
		if (deleteCoverType == null)
		{
			return NotFound();
		}

		_unitOfWork.CoverType.Remove(deleteCoverType);
		_unitOfWork.Save();

		TempData["Success"] = "CoverType Deleted Successfully";
		return RedirectToAction("Index");

	}
}
