using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeStruct.Models;

namespace TreeStruct.Data
{
    public interface ITreeRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<Category> GetCategory(int id);
        Task<Category> GetBranch(int id);
    }
}
