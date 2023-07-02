using Domain.Entities.Common;
using MassTransit;

namespace Domain.Entities;

public class SQLObject : Entity<SQLObjectId>
{
    public override SQLObjectId Id { get; set; } = NewId.NextSequentialGuid();
}