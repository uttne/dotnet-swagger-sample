using System;

namespace Sample01
{
    /// <summary>
    /// WeatherForecast
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Data
        /// </summary>
        /// <value></value>
        public DateTime Date { get; set; }
        /// <summary>
        /// Temperature C
        /// </summary>
        /// <value></value>

        public int TemperatureC { get; set; }

        /// <summary>
        /// Temperature F
        /// </summary>
        /// <returns></returns>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// Summary
        /// </summary>
        /// <value></value>
        public string Summary { get; set; }
    }
}
