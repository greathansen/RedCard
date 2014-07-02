using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Daos;
using WebApp.Models;

namespace WebApp.Controllers.Api
{
    public class TeamController : ApiController
    {
        public List<Team> Get()
        {
            var teams = DataAccess<Team>.GetAll();

            return teams;
        }
    }
}
