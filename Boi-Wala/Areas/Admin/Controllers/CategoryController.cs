﻿using Boi_Wala.DataAccess.Repository.IRepository;
using Boi_Wala.Utility;
using BoiWala.DataAccess.Data;
using BoiWala.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Boi_Wala.Areas.Admin.Controllers
{
    [Area("Admin")]
   [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }

        //Create Page
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Category obj)
        {
            //Same Name Error Validation
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");
            }

            //if (obj.Name.ToLower() == "test")
            //{
            //    ModelState.AddModelError("", "Test is an invalid value");
            //}


            //Validation
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        //Edit Page in Create Page

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();


            if (categoryFromDb == null)
            {
                {
                    return NotFound();
                }
            }
            return View(categoryFromDb);

        }

        [HttpPost]

        public IActionResult Edit(Category obj)
        {
            //Same Name Error Validation
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");
            }

            //Validation
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Category Updated  successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        // Delete Option
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);

            if (categoryFromDb == null)
            {
                {
                    return NotFound();
                }
            }
            return View(categoryFromDb);

        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePOST(int? id)
        {

            Category? obj = _unitOfWork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Remove(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Category Delete successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

    }
}
