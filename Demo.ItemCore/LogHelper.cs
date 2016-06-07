using System;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Demo.ItemCore
{
    public class LogHelper
    {
        public static void WriteLog(Type type, Exception ex)
        {
            var log = log4net.LogManager.GetLogger(type);
            log.Error("Error",ex);
        }

        public static void WriteLog(Type type, string msg)
        {
            var log = log4net.LogManager.GetLogger(type);
            log.Error(msg);
        }
    }
}