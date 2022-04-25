using App.Metrics;
using App.Metrics.Counter;

namespace CollectMetrics.Metrics
{
    public class MetricsRegistry
    {
        public static CounterOptions CreatedUserCounter => new CounterOptions 
        {
            Name = "Created User",
            Context = "UserApi" ,
            MeasurementUnit = Unit.Calls
        } ;

        public static CounterOptions CreatedDbConnectionCounter => new CounterOptions 
        {
            Name = "Created Db Connection",
            Context = "Database" ,
            MeasurementUnit = Unit.Calls
        } ;
    }
}