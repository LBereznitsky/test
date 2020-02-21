using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;
using System;

namespace TestsCommon
{
    public class Logs 
    {  
        static public ILogger InitializeLogs(TestContext TestContext)
        {
            string currentDate = String.Join("-", DateTime.Today.ToString("yyyy-MM-dd"));
            string testClassName = TestContext.FullyQualifiedTestClassName;
            string testMethodName = TestContext.TestName;            

            ILogger logger = new LoggerConfiguration()
                .MinimumLevel.Information().WriteTo.Console()
                .WriteTo.File($@"C:\Logs\{currentDate}\{testClassName}\{testMethodName}.txt")
                .CreateLogger();

            return logger;
        }
    }
}
