using System;
using System.Collections;
using System.Collections.Generic;
using BS_API.Common;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text;
using BS_API.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Formatting = System.Xml.Formatting;

namespace BS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BsPostController : ControllerBase
    {
        private ILogger _logger;
        private readonly IPostInterface _service;


        public BsPostController(ILogger<BsPostController> logger, IPostInterface service)
        {
            _logger = logger;
            _service = service;

        }
        private string DataTableToJSONWithStringBuilder(DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }
            return JSONString.ToString();
        }

        [HttpGet("/api/GetPosts")]
        public ActionResult<string> GetPosts()
        {
            DataTable dt = _service.GetPosts();
            string returnValue = DataTableToJSONWithStringBuilder(dt);
            return returnValue;
        }

        [HttpGet("/api/SearchPosts/{id}")]
        public ActionResult<string> SearchPosts([FromRoute] string id)
        {
            DataSet dt = _service.SearchPosts(id);
            string returnValue = JsonConvert.SerializeObject(dt);
            return returnValue;
        }

        [HttpGet("/api/GetComments")]
        public ActionResult<string> GetComments()
        {
            DataTable dt = _service.GetComments();
            string returnValue = DataTableToJSONWithStringBuilder(dt);
            return returnValue;
        }

        [HttpPost("/api/CommentLike/{id}")]
        public ActionResult<string> CommentLike([FromRoute] string id)
        {
            try
            {
                _service.LikeComment(id);
                return "Success";
            }
            catch
            {
                return "Failed";
            }
        }

        [HttpPost("/api/CommentDisLike/{id}")]
        public ActionResult<string> CommentDisLike([FromRoute] string id)
        {
            try
            {
                _service.DislikeComment(id);
                return "Success";
            }
            catch
            {
                return "Failed";
            }
        }
    }
}
