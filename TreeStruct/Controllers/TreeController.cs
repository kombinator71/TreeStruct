using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TreeStruct.Data;
using TreeStruct.Models;
using TreeStruct.ViewModels;

namespace TreeStruct.Controllers
{
    public class TreeController : Controller
    {
        private ITreeRepository _treeRepo { get; set; }
        private readonly IMapper _mapper;

        public TreeController(ITreeRepository treeRepo, IMapper mapper)
        {
            _treeRepo = treeRepo;
            _mapper = mapper;
        }
        
        // GET: Tree
        public async Task<IActionResult> Index()
        {
            TreeViewModel treeModel = new TreeViewModel();

            Category treeFromRepo = await _treeRepo.GetBranch(1);

            _mapper.Map(treeFromRepo, treeModel);

            return await Task.Run(() => View(treeModel));
        }

        // GET: Tree/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tree/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tree/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tree/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tree/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tree/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}