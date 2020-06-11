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
        private TreeRepository _treeRepo { get; set; }
        private readonly IMapper _mapper;

        public TreeController(TreeRepository treeRepo, IMapper mapper)
        {
            _treeRepo = treeRepo;
            _mapper = mapper;
        }
        
        // GET: Tree
        public async Task<IActionResult> Index()
        {
            var rootsFromRepo = await _treeRepo.GetBranch(1);
            
            TreeViewModel treeModel = _mapper.Map<TreeViewModel>(rootsFromRepo);

            return await Task.Run(() => View(treeModel));
        }

        // Appending tree
        public async Task<IActionResult> ExpandBranch(int id = 1)
        {
            var childsFromRepo = await _treeRepo.GetChilds(id);

            IEnumerable<TreeViewModel> childsModel =
                _mapper.Map<IEnumerable<Category>, IEnumerable<TreeViewModel>>(childsFromRepo);

            return await Task.Run(() => PartialView("_ExpandBranch", childsModel));
        }



        // GET: Tree/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Category treeFromRepo = await _treeRepo.GetBranch(1);
            TreeViewModel treeModel = new TreeViewModel();

            _mapper.Map(treeFromRepo, treeModel);

            return await Task.Run(() => View(treeModel));
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