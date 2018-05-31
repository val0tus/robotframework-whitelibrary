using Castle.Core.Logging;
using System;
using TestStack.White;
using TestStack.White.Configuration;
using WhiteLibrary;

namespace CSWhiteLibrary
{
	public partial class Keywords : WhiteFW
    {
        public void set_log_level(string level)
        {
            set_logging(level);
        }

        private void set_logging(string level)
        {
            switch (level.ToLower())
            {
                case "info":
                    CoreAppXmlConfiguration.Instance.LoggerFactory = new WhiteDefaultLoggerFactory(LoggerLevel.Info);
                    break;
                case "warn":
                    CoreAppXmlConfiguration.Instance.LoggerFactory = new WhiteDefaultLoggerFactory(LoggerLevel.Warn);
                    break;
                case "debug":
                    CoreAppXmlConfiguration.Instance.LoggerFactory = new WhiteDefaultLoggerFactory(LoggerLevel.Debug);
                    break;
            }
        }

    }
}
