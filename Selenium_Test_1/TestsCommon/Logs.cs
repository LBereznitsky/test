using Serilog;
using Serilog.Core;
using System;

namespace TestsCommon
{
    public class Logs
    {
        public Logger InitializeLogs()
        {
            string currentDate = String.Join("-", DateTime.Today.ToString("yyyy-MM-dd"));

            return new LoggerConfiguration()
                .MinimumLevel.Information()                
                .WriteTo.File($@"C:\Logs\Info-{currentDate}.txt")
                .CreateLogger();             
        }

        public void Information(string information)
        {
            Log.Information(information); 
        }

        public void CloseAndFlush()
        {
            Log.CloseAndFlush();
        }
    }
}
