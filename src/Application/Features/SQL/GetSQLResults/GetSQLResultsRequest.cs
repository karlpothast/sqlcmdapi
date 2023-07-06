using Application.Common.Requests;
using Application.Common.Responses;
using MediatR;
using System;

namespace Application.Features.SQL.GetSQLObjects;

public record GetSQLResultsRequest : IRequest<GetSQLResponse?>
{
    public String? Username { get; init; }
    public String? Password { get; init; }
    public String? Database { get; init; }
    public String? SQLCommandText { get; init; }
}

