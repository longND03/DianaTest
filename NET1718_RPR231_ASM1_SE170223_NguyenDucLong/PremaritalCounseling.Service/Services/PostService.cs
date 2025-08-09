using PremaritalCounseling.Repository.Models;
using PremaritalCounseling.Repository.Repositories;
using PremaritalCounseling.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremaritalCounseling.Service.Services
{
    public class PostService : IPostService
    {
        private PostRepository _repository;
        public PostService()
        {
            _repository = new PostRepository();
        }

        public async Task<List<Post>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Post> GetById(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<int> Create(Post post)
        {
            return await _repository.CreateAsync(post);
        }

        public async Task<int> Update(Post post)
        {
            return await _repository.UpdateAsync(post);
        }

        public async Task<bool> Delete(string id)
        {
            var item = await _repository.GetByIdAsync(id);

            if (item != null)
            {
                return await _repository.RemoveAsync(item);
            }

            return false;
        }

        public async Task<List<Post>> Search(string username, string title, string typeName)
        {
            return await _repository.Search(username, title, typeName);
        }

        public async Task<int> save(Post post)
        {
            var item = await _repository.GetByIdAsync(post.Id);

            if (item != null)
            {
                return await _repository.UpdateAsync(post);
            }
            else
            {
                return await _repository.CreateAsync(post);
            }
        }
    }
}
