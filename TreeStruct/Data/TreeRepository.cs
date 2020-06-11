using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeStruct.Models;

namespace TreeStruct.Data
{
    public class TreeRepository
    {
        public Context _context { get; set; }
        public TreeRepository(Context context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Category> GetNode(int id)
        {
            return await _context.Categories
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Category> GetBranch(int id)
        {
            return await _context.Categories
                .Include(c => c.Childs)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Category>> GetChilds(int id)
        {
            return await _context.Categories
                .Include(c => c.Childs)
                .Where(c => c.ParentId == id)
                .ToListAsync();
        }
    }
}
