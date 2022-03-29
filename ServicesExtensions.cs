using Microsoft.Extensions.DependencyInjection;
using SimpleLog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog
{
    public static class ServicesExtensions
    {
        public static void SimpleLog(this IServiceCollection services, string? path_to_save_log, string? log_file_name)
        {
            services.AddTransient<ILogService, LogService>(x => 
                new LogService(
                    path_to_save_log, 
                    log_file_name));

            //services.AddTransient<ILogService, LogService>(
            //    x => new LogService(path_to_save_log, log_file_name));
        }
    }
}
