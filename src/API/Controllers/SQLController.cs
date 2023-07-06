using Application.Common.Responses;
using System.Threading.Tasks;
using Application.Features.SQL.GetSQLResults;
using Domain.Entities.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Api.SQL;
using System.IO;
using System.Text;
using System;
using Application.Features.SQL;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Api.Controllers;

[ApiController]
[AllowAnonymous]
[Route("[controller]")]
[EnableCors]
public class SQLController : ControllerBase
{
  private readonly IMediator _mediator;
  public SQLController(IMediator mediator) {_mediator = mediator;}

  [HttpPost]
  [Route("SQLCommand")]
  [EnableCors]
  [Produces("application/json")]
  public ActionResult<String> GetSQLCommandResults(SQLCommandRequest? httpPost)
  {
    var result = "{}";

    SqlCmdWrapper sqlcmd1 = new SqlCmdWrapper();
    if (httpPost != null && httpPost.SQLCommandText != null)
    {
      SQLResultsResponse sqlResults = new SQLResultsResponse();
      if (httpPost.Username != null && httpPost.Password != null && httpPost.Database  != null && httpPost.SQLCommandText != null)
      {
        sqlResults.SQLResponse = sqlcmd1.ExecSQLQuery(httpPost.Username, httpPost.Password, httpPost.Database, httpPost.SQLCommandText);
      }

      var resp = JsonConvert.SerializeObject(sqlResults);
      result = resp;
    }
    return result;
  }

  class SQLResultsResponse
  {
    public String SQLResponse = "";
  }
}