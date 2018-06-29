namespace PRHawk.Service
{
    using PRHawk.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGitHubService
    {
        /// <summary>
        /// Fetches repos collection asynchronously.
        /// </summary>
        Task<List<GitRepo>> GetReposAsync(string token, string userName);
    }
}