using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace SiteAngular.ApiControllers
{
    public abstract class BaseApiController : ApiController
    {
        public HttpResponseMessage ModelStateErrorResult(HttpStatusCode Code,ModelStateDictionary ModelState)
        {
            string Message = string.Empty;
            StringBuilder builder = new StringBuilder();
            List<string> Errors = ModelState.Values.Select(x => x.Errors).SelectMany(y => y.Where(x => !string.IsNullOrEmpty(x.ErrorMessage)).Select(x => x.ErrorMessage)).ToList<string>();
            Errors.ForEach(x =>
            {
                if (x != Errors.Last())
                {
                    builder.Append(x);
                    builder.Append("<br/>");
                }
                else
                {
                    builder.Append(x);
                }
            });
            Message = builder.ToString();
            HtmlString html = new HtmlString(Message);
            HttpResponseMessage message = new HttpResponseMessage(Code);
            message.Content = new StringContent(html.ToHtmlString());
            return message;
        }
    }
}
