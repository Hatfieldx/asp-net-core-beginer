using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace lesson9.Controllers
{
    [Route("api")]
    public class FunctionController : Controller
    {
        [Route("GetMessage")]
        //[HttpPost]
        public async Task<IActionResult> GetMessage(string address)
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = await reader.ReadToEndAsync();

                string a = "";
            }


            string query = "";

            


            return Content("Im Web API");
        }
    }
}
