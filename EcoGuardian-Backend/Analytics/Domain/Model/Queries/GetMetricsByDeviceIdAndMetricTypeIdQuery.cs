namespace EcoGuardian_Backend.Analytics.Domain.Model.Queries;

public record GetMetricsByDeviceIdAndMetricTypeIdQuery(int DeviceId, int MetricTypeId);

