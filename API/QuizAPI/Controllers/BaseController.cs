using Microsoft.AspNetCore.Mvc;
using QuizAPI.Helper;

namespace QuizAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        public CurrentUser CurrentUser
        {
            get { return Request.GetCurrentSession(); }
        }
    }
}
