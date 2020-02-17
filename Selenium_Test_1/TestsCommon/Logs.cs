using Serilog;
using System;


namespace TestsCommon
{
    public class Logs 
    {  
        static public ILogger InitializeLogs()
        {
            string currentDate = String.Join("-", DateTime.Today.ToString("yyyy-MM-dd"));
            string currentSeconds = String.Join("-", DateTime.Now.Millisecond.ToString());

            ILogger logger = new LoggerConfiguration()
                .MinimumLevel.Information().WriteTo.Console()
                .WriteTo.File($@"C:\Logs\Info-{currentDate}-{currentSeconds}.txt")
                .CreateLogger();

            return logger;
        }
    }
}
