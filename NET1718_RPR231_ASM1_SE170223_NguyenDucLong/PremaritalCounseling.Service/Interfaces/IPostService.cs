using PremaritalCounseling.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremaritalCounseling.Service.Interfaces
{
    public interface IPostService
    {
        Task<List<Post>> GetAll();
        Task<Post> GetById(string id);
        Task<int> Create(Post post);
        Task<int> Update(Post post);
        Task<bool> Delete(string id);
        Task<List<Post>> Search(string username, string title, string typeName);

        //Task<int> save(CategoryBankAccount categoryBankAccount);
    }
}
