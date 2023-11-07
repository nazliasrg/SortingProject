using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YTDProject.Model;
using YTDProject.Services;

namespace YTDProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IMainService _mainService;
        public MainController(IMainService mainService)
        {
            _mainService = mainService;
        }

        [HttpPost("getSortedList")]
        public IActionResult GetResult()
        {
            List<string> notSortedList = new()
            {
                //"1_AB", "3_AB", "2_AB", "0_AB", "2_NC", "0_NC", "1_NC", "YTD-WTRA-Actual-Dts", "31_AB", "5ABA"
                "3_AB", "0_AB", "4_AB", "1_AC", "YTD-WTRD", "2_AC", "0_AC", "0_AA"
            };
            var result = _mainService.GetSortedList(notSortedList);
            return Ok(result);
        }
    }
}
