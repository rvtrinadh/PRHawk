namespace PRHawk.Service
{
    using PRHawk.Models;
    using PRHawk.Repository;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class GitHubService : IGitHubService
    {
        #region Variables
        private readonly IRepository _gitRepository;
        private readonly HttpClient _client;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public GitHubService(IRepository gitRepository)
        {
            this._gitRepository = gitRepository;
            this._client = new HttpClient();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Function to fetch Repos information for the logged in user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<List<GitRepo>> GetReposAsync(string token, string userName)
        {
            SetClientHeaders(_client, token, userName);
            var lstRepos = await _gitRepository.GetAllRepos(_client, userName);
            return lstRepos;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Method to set the client headers
        /// </summary>
        /// <param name="client"></param>
        /// <param name="user"></param>
        private void SetClientHeaders(HttpClient client,string token, string userName)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);
            client.DefaultRequestHeaders.Add("User-Agent", "PRHawk");
        }
        #endregion
    }
}