﻿namespace ProductManagementService.Common.Interfaces
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
        DateTimeOffset OffsetNow { get; }
        DateTimeOffset OffsetUtcNow { get; }
        DateTime UtcNow { get; }
    }
}