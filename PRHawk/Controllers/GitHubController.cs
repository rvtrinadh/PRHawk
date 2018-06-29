namespace PRHawk.Controllers
{
    using PRHawk.Models;
    using PRHawk.Repository;
    using PRHawk.Service;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Cors;

    /// <summary>
    /// GitHub Controller
    /// </summary>
    [RoutePrefix("user")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GitHubController : ApiController
    {
        private readonly IGitHubService _service;
        private readonly IRepository _gitRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        public GitHubController()
        {
            _gitRepository = new GitHubRepository();
            _service = new GitHubService(_gitRepository);
        }

        /// <summary>
        /// GET method to fetch repo information
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [Route("{userName}")]
        [HttpGet]
        public async Task<List<GitRepo>> GetAllRepos([FromUri]string userName)
        {   
            if (Request.Headers.Contains("Authorization"))
            {
                string token = Request.Headers.GetValues("Authorization").First();
                return await _service.GetReposAsync(token, userName);
            }
            return new List<GitRepo>();
        }
    }
}