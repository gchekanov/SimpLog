using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog.Services
{
    public interface ILogService
    {
        Task Trace(string message);

        Task Trace(string message, string path_to_save_log, string log_file_name);

        Task Debug(string message);

        Task Debug(string message, string path_to_save_log, string log_file_name);

        Task Info(string message);

        Task Info(string message, string path_to_save_log, string log_file_name);

        Task Notice(string message);

        Task Notice(string message, string path_to_save_log, string log_file_name);

        Task Warn(string message);

        Task Warn(string message, string path_to_save_log, string log_file_name);

        Task Error(string message);

        Task Error(string message, string path_to_save_log, string log_file_name);

        Task Fatal(string message);

        Task Fatal(string message, string path_to_save_log, string log_file_name);
    }
}
