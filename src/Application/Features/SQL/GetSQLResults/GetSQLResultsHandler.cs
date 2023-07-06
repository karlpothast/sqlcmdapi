using AutoMapper;
using Application.Common;
using Application.Common.Responses;
using Application.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Application.Features.SQL.GetSQLResults;

public class SQLCommandRequest
{
    public String? Username { get; init; }
    public String? Password { get; init; }
    public String? Database { get; init; }
    public String? SQLCommandText { get; init; }
}

public class SQLCommandResponse
{
    public String? SQLCommandResults { get; set; }
}



