using Castle.Core.Logging;
using System;
using TestStack.White.Configuration;
using static CsDynamicLib.Attributes;

namespace CSWhiteLibrary
{
    [RobotKeywordClass]
    public class SettingsKeywords : LibraryElement
    {

        public SettingsKeywords(WhiteLibrary state) : base(state)
        {
        }

        [RobotKeyword]
        public bool set_logging_level(string level)
        {
            set_logging(level);
            return true;
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
