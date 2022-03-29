# SimpLog NuGet Package
Simple NuGet package to write log files when you need.

# Statuses
1) Trace -> This should be used during development to track bugs, but never committed to your VCS.
2) Debug -> log at this level about anything that happens in the program. This is mostly used during debugging, and I’d advocate trimming down the number of debug statement before entering the production stage, so that only the most meaningful entries are left, and can be activated during troubleshooting.
3) Info -> Log at this level all actions that are user-driven, or system specific (ie regularly scheduled operations…)
4) Notice -> This will certainly be the level at which the program will run when in production. Log at this level all the notable events that are not considered an error.
5) Warn -> Log at this level all events that could potentially become an error. For instance if one database call took more than a predefined time, or if an in-memory cache is near capacity. This will allow proper automated alerting, and during troubleshooting will allow to better understand how the system was behaving before the failure.
6) Error -> Log every error condition at this level. That can be API calls that return errors or internal error conditions.
7) Fatal -> Too bad, it’s doomsday. Use this very scarcely, this shouldn’t happen a lot in a real program. Usually logging at this level signifies the end of the program. For instance, if a network daemon can’t bind a network socket, log at this level and exit is the only sensible thing to do.

# Configuration in Program.cs
builder.Services.SimpleLog({1}, {2});
{1} -> can be null or path of the folder where the log to be saved
{2} -> can be null or name of the log file for the project

# Configuration in Controller
private readonly ILogService logService;

public HomeController(
    ILogService logService)
{
    logService = logService;
}

# Use it in Action method
logService.Info("Your message here!");
logService.Info("Your message here!", {3}, {4});

{3} and {4} are optional if {1} and {2} are not null!

{3} -> path of the log file
{4} -> name of the log file

If you did not set file name and path then the library won't work.
If you set both, the file path and name will be {3} and {4}.

Hope you enjoy the NuGet Package! :)
