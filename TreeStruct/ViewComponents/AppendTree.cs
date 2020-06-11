using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeStruct.Data;
using TreeStruct.Models;
using TreeStruct.ViewModels;

namespace TreeStruct.ViewComponents
{
    public class AppendTreeViewComponent : ViewComponent
    {
        private readonly TreeRepository _treeRepo;
        private readonly IMapper _mapper;

        public AppendTreeViewComponent(TreeRepository treeRepo, IMapper mapper)
        {
            _treeRepo = treeRepo;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var childsFromRepo = await _treeRepo.GetChilds(id);

            IEnumerable<TreeViewModel> childsModel =
                _mapper.Map<IEnumerable<Category>, IEnumerable<TreeViewModel>>(childsFromRepo);

            return await Task.Run(() => View(childsModel));
        }
    }
}
