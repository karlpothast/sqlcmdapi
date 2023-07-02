using Domain.Entities.Common;
using System;

namespace Application.Features.SQL;

public record GetSQLResponse
{
    public String? SQLResponse { get; init; }
}