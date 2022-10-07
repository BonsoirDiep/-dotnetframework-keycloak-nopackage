using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication4.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            var x1 = HeaderNames.Authorization;
            IEnumerable<String> accessTokenHeader;
            Request.Headers.TryGetValues(x1, out accessTokenHeader);
            if(accessTokenHeader== null)
            {
                return new string[] { "no permit" };
            }
            string accessToken = accessTokenHeader.First().Replace("Bearer ", "");
            if (ssoHelper.validateToken(accessToken))
                return new string[] { "value1", "value2" };
            else return new string[] { "error" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        public class Code
        {
            public string code { get; set; }
        }
        static SsoVinorsoft ssoHelper = new SsoVinorsoft(
            "http://117.4.247.68:10825/realms/DemoRealm/",
            "express-1",
            "Ih1aaQ6Jv1EFagzZjCRT8KIT2Nl9NovB",
            "http://localhost:52716/Content/sso.html",
            "l44n-kHYSyKY6LR-1t3QYhfVI6yobWi8sTSKMP9q3RZDHjkQNs8BMIx3MIOrx3h4yg6ony6TsVzt6BbKK6GP_Bz8fqh0nhlI90aGfd-06arMXcg2vnSMIoxns8rnC20vN_vpdOKCM5u4QLwBQMcQbA7Y7n0KBEHPhB-i1-nP9tWILihLVEQ9cpuHj-qCGqBq1E-CZV4hb8tyYMKuAxKzA_EF4O6ABpt1r6pP56CDRTUBzzzxrqDkssZ_abqbjkSngEbEixuvtgDu6WAuMlq0QlvoM24s117Cu24PC6hrGgXB_n7IkeDMtNaR8iselHsk1L3YY9DLijR16c-9J3g_Nw",
            "AQAB"
        );

        // POST api/values
        public Object Post([FromBody] Code code)
        {
            return Ok(ssoHelper.GetCode(code.code));
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
