using Application.Common.Requests;
using Application.Common.Responses;
using MediatR;
using System;

namespace Application.Features.SQL.GetSQLObjects;

public record GetSQLResultsRequest : IRequest<GetSQLResponse?>
{
    public String? SQLCommandText { get; init; }
}

