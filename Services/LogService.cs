using SimpleLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SimpleLog.Models.Constants;

namespace SimpleLog.Services
{
    public class LogService : ILogService
    {
        public string filePath;
        public string fileName;

        public LogService(string filePath, string fileName)
        {
            this.filePath = filePath;
            this.fileName = fileName;
        }

        /// <summary>
        /// This should be used during development to track bugs.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task Trace(string message)
        {
            await CreateFile(filePath, fileName, LogType.Trace, message);
        }

        /// <summary>
        /// This should be used during development to track bugs.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="path_to_save_log"></param>
        /// <param name="log_file_name"></param>
        /// <returns></returns>
        public async Task Trace(string message, string path_to_save_log, string log_file_name)
        {
            await CreateFile(path_to_save_log, log_file_name, LogType.Trace, message);
        }

        /// <summary>
        /// This is mostly used during 
        /// debugging, and I’d advocate trimming down the number of debug statement before entering the production 
        /// stage, so that only the most meaningful entries are left, and can be activated during troubleshooting.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task Debug(string message)
        {
            await CreateFile(filePath, fileName, LogType.Debug, message);
        }

        /// <summary>
        /// This is mostly used during 
        /// debugging, and I’d advocate trimming down the number of debug statement before entering the production 
        /// stage, so that only the most meaningful entries are left, and can be activated during troubleshooting.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="path_to_save_log"></param>
        /// <param name="log_file_name"></param>
        /// <returns></returns>
        public async Task Debug(string message, string path_to_save_log, string log_file_name)
        {
            await CreateFile(path_to_save_log, log_file_name, LogType.Debug, message);
        }

        /// <summary>
        /// Log at this level all actions that are user-driven, or system 
        /// specific (ie regularly scheduled operations…)
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task Info(string message)
        {
            await CreateFile(filePath, fileName, LogType.Info, message);
        }

        /// <summary>
        /// Log at this level all actions that are user-driven, or system 
        /// specific (ie regularly scheduled operations…)
        /// </summary>
        /// <param name="message"></param>
        /// <param name="path_to_save_log"></param>
        /// <param name="log_file_name"></param>
        /// <returns></returns>
        public async Task Info(string message, string path_to_save_log, string log_file_name)
        {
            await CreateFile(path_to_save_log, log_file_name, LogType.Info, message);
        }

        /// <summary>
        /// This will certainly be the level at which the program will run when 
        /// in production. Log at this level all the notable events that are not considered an error.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task Notice(string message)
        {
            await CreateFile(filePath, fileName, LogType.Notice, message);
        }

        /// <summary>
        /// This will certainly be the level at which the program will run when 
        /// in production. Log at this level all the notable events that are not considered an error.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="path_to_save_log"></param>
        /// <param name="log_file_name"></param>
        /// <returns></returns>
        public async Task Notice(string message, string path_to_save_log, string log_file_name)
        {
            await CreateFile(path_to_save_log, log_file_name, LogType.Notice, message);
        }

        /// <summary>
        /// Log at this level all events that could potentially become an error.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task Warn(string message)
        {
            await CreateFile(filePath, fileName, LogType.Warn, message);
        }

        /// <summary>
        /// log at this level all events that could potentially become an error.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="path_to_save_log"></param>
        /// <param name="log_file_name"></param>
        /// <returns></returns>
        public async Task Warn(string message, string path_to_save_log, string log_file_name)
        {
            await CreateFile(path_to_save_log, log_file_name, LogType.Warn, message);
        }

        /// <summary>
        /// Log every error condition at this level. That can be API calls that return errors or internal error conditions.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task Error(string message)
        {
            await CreateFile(filePath, fileName, LogType.Error, message);
        }

        /// <summary>
        /// Log every error condition at this level. That can be API calls that return errors or internal error conditions.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="path_to_save_log"></param>
        /// <param name="log_file_name"></param>
        /// <returns></returns>
        public async Task Error(string message, string path_to_save_log, string log_file_name)
        {
            await CreateFile(path_to_save_log, log_file_name, LogType.Error, message);
        }

        /// <summary>
        /// Too bad, it’s doomsday. Use this very 
        /// scarcely, this shouldn’t happen a lot in a real program. Usually 
        /// logging at this level signifies the end of the program. 
        /// For instance, if a network daemon can’t bind a network socket, log at 
        /// this level and exit is the only sensible thing to do.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task Fatal(string message)
        {
            await CreateFile(filePath, fileName, LogType.Fatal, message);
        }

        /// <summary>
        /// Too bad, it’s doomsday. Use this very 
        /// scarcely, this shouldn’t happen a lot in a real program. Usually 
        /// logging at this level signifies the end of the program. 
        /// For instance, if a network daemon can’t bind a network socket, log at 
        /// this level and exit is the only sensible thing to do.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="path_to_save_log"></param>
        /// <param name="log_file_name"></param>
        /// <returns></returns>
        public async Task Fatal(string message, string path_to_save_log, string log_file_name)
        {
            await CreateFile(path_to_save_log, log_file_name, LogType.Fatal, message);
        }

        public async Task CreateFile(string filePath_final, string fileName_final, LogType logType, string message)
        {
            if (File.Exists(filePath + PathSeparator + fileName + FileFormat))
            {
                // This text is always added, making the file longer over time
                // if it is not deleted.
                using (StreamWriter sw = File.AppendText(filePath_final + PathSeparator + fileName_final + FileFormat))
                {
                    sw.WriteLine(DateTime.UtcNow.ToString(DateFormat) + Separator + MessageType(logType) + Separator + message + Environment.NewLine);
                }
            }
            else
                await File.WriteAllTextAsync(filePath_final + PathSeparator + fileName_final + FileFormat, DateTime.UtcNow.ToString(DateFormat) + Separator + MessageType(logType) + Separator + message + Environment.NewLine);
        }

        public string MessageType(LogType logType)
        {
            switch (logType)
            {
                case LogType.Trace:
                    return LogType_Trace;
                case LogType.Debug:
                    return LogType_Debug;
                case LogType.Info:
                    return LogType_Info;
                case LogType.Notice:
                    return LogType_Notice;
                case LogType.Warn:
                    return LogType_Warn;
                case LogType.Error:
                    return LogType_Error;
                case LogType.Fatal:
                    return LogType_Fatal;
                default:
                    return LogType_NoType;
            }
        }
    }
}
