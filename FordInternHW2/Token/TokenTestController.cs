using FordInternHW2.Base.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FordInternHW2.Token
{
    [Route("fordhw2/api/v1.0/[controller]")]
    [ApiController]
    public class TokenTestController : ControllerBase
    {

        public TokenTestController()
        {
        }


        [HttpGet("NoToken")]
        public string NoToken()
        {
            return "NoToken";
        }

        [HttpGet("Authorize")]
        [Authorize]
        public string Authorize()
        {
            return "Authorize";
        }

        [HttpGet("Admin")]
        [Authorize(Roles = Role.Admin)]
        public string Admin()
        {
            return "Admin";
        }

        [HttpGet("Viewer")]
        [Authorize(Roles = Role.Viewer)]
        public string Viewer()
        {
            return "Viewer";
        }

        [HttpGet("AdminViewer")]
        [Authorize(Roles = $"{Role.Admin},{Role.Viewer}")]
        public string AdminViewer()
        {
            return "AdminViewer";
        }

        [HttpGet("EditorQTDAEditorQTNS")]
        [Authorize(Roles = $"{Role.EditorQTNS},{Role.EditorQTDA}")]
        public string EditorQTDAEditorQTNS()
        {
            return "EditorQTDAEditorQTNS";
        }


        [HttpGet("TestAccount")]
        [Authorize]
        public string TestAccount()
        {
            var claimsList = User.Claims;

            var account = claimsList.Where(a => a.Type == "AccountId").FirstOrDefault();
            var accountId = account.Value;


            var url = HttpContext.Request.Path;

            var id = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            return "TestAccount";
        }
    }
}
