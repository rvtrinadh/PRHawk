namespace PRHawk.Repository
{
    using PRHawk.Models;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IRepository
    {
        /// <summary>
        /// Get all repos
        /// </summary>
        /// <param name="client"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<List<GitRepo>> GetAllRepos(HttpClient client, string userName);        
    }
}