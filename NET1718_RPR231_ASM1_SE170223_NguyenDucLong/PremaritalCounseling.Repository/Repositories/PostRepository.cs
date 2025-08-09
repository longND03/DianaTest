using Microsoft.EntityFrameworkCore;
using PremaritalCounseling.Repository.Base;
using PremaritalCounseling.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremaritalCounseling.Repository.Repositories
{
    public class PostRepository : GenericRepository<Post>
    {
        public PostRepository()
        {

        }

        public async Task<List<Post>> GetAll()
        {
            var posts = await _context.Posts.Include(b => b.Type).ToListAsync();

            return posts;
        }

        public async Task<List<Post>> Search(string username, string title, string typeName)
        {

            var posts = await _context.Posts
                .Include(b => b.Type)
                .Where(ba =>
                (ba.UserName.Contains(username) || string.IsNullOrEmpty(username))
                && (ba.Title.Contains(title) || string.IsNullOrEmpty(title))
                && (ba.Type.Name.Contains(typeName) || string.IsNullOrEmpty(typeName))  //Ref table: foreign key                
            ).ToListAsync();

            return posts;
        }
    }
}
