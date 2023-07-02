using StronglyTypedIds;
using System;

[assembly: StronglyTypedIdDefaults(
    backingType: StronglyTypedIdBackingType.Guid,
    converters: StronglyTypedIdConverter.SystemTextJson | StronglyTypedIdConverter.EfCoreValueConverter |
                StronglyTypedIdConverter.Default | StronglyTypedIdConverter.TypeConverter,
    implementations: StronglyTypedIdImplementations.IEquatable | StronglyTypedIdImplementations.Default)]

namespace Domain.Entities.Common;


public interface IGuid {}

[StronglyTypedId]
public partial struct SQLObjectId : IGuid
{
      public static implicit operator SQLObjectId(Guid guid)
    {
        return new SQLObjectId(guid);
    }
}



