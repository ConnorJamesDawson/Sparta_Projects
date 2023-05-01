using RestaurantWebApp.DataAccess.Data;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApp.DataAccess.Repository
{
    public class ProjectRepository : Repository<Projects> , IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public void Update(Projects project)
        {
            var objFromDb = _context.Project.FirstOrDefault(c=> c.Id == project.Id);
            objFromDb.Name = project.Name;
            objFromDb.Description = project.Description;
            objFromDb.GitHubRepositoryURL = project.GitHubRepositoryURL;
            objFromDb.ImageURL = project.ImageURL;
        }
    }
}
