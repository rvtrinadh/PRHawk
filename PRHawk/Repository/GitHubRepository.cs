namespace PRHawk.Repository
{
    using PRHawk.Models;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class GitHubRepository : IRepository
    {
        public static HttpClient client = new HttpClient();
        private const string ApiPath = "https://api.github.com/";

        /// <summary>
        /// Asynchronously fetches git repositories of a user
        /// </summary>
        /// <param name="client"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<List<GitRepo>> GetAllRepos(HttpClient client, string userName)
        {
            List<GitRepo> gitHubRepos = new List<GitRepo>();
            string url = string.Format(ApiPath + "users/{0}/repos", userName);
            
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                gitHubRepos = await response.Content.ReadAsAsync<List<GitRepo>>();
                if (gitHubRepos.Count > 0)
                {   
                    foreach (var git in gitHubRepos)
                    {
                        git.PRCount = GetPullRequests(client, userName, git.Name).Result;
                    }
                }
            }
            
            return gitHubRepos;
        }

        /// <summary>
        /// Asynchronously fetches PRs associated to a repo
        /// </summary>
        /// <param name="client"></param>
        /// <param name="userName"></param>
        /// <param name="repoName"></param>
        /// <returns></returns>
        private async Task<int> GetPullRequests(HttpClient client, string userName, string repoName)
        {
            List<PullRequest> pullRequests = new List<PullRequest>();
            string url = string.Format(ApiPath + "repos/{0}/{1}/pulls", userName, repoName);
            
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                pullRequests = await response.Content.ReadAsAsync<List<PullRequest>>();
            }
            return pullRequests.Count;
        }
    }
}