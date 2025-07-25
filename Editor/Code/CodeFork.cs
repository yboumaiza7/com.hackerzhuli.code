using System;

namespace Hackerzhuli.Code.Editor.Code
{
	/// <summary>
	///     Data for a Visual Studio Code fork.
	/// </summary>
	public record CodeFork : IAppInfo
    {
	    /// <summary>
	    ///     Static array of supported Visual Studio Code forks.<br />
	    ///     VS Code Insiders is treated as a fork because it have a different executable name than the stable version<br />
	    ///     If for a fork, a prerelease version and the stable version have same executable name, then it should be treated as
	    ///     the same fork
	    /// </summary>
	    public static readonly CodeFork[] Forks =
        {
            new()
            {
                Name = "Visual Studio Code",
                WindowsDefaultDirName = "Microsoft VS Code",
                WindowsExeName = "Code.exe",
                MacAppName = "Visual Studio Code.app",
                LinuxExeName = "code",
                UserDataDirName = ".vscode",
                LatestLanguageVersion = new Version(13, 0),
                IsPrerelease = false
            },
            new()
            {
                Name = "Visual Studio Code Insiders",
                WindowsDefaultDirName = "Microsoft VS Code Insiders",
                WindowsExeName = "Code - Insiders.exe",
                MacAppName = "Visual Studio Code - Insiders.app",
                LinuxExeName = "code-insiders",
                UserDataDirName = ".vscode-insiders",
                LatestLanguageVersion = new Version(13, 0),
                IsPrerelease = true
            },
            new()
            {
                Name = "Cursor",
                WindowsDefaultDirName = "Cursor",
                WindowsExeName = "Cursor.exe",
                MacAppName = "Cursor.app",
                LinuxExeName = "cursor",
                UserDataDirName = ".cursor"
            },
            new()
            {
                Name = "Windsurf",
                WindowsDefaultDirName = "Windsurf",
                WindowsExeName = "Windsurf.exe",
                MacAppName = "Windsurf.app",
                LinuxExeName = "windsurf",
                UserDataDirName = ".windsurf"
            },
            new()
            {
                Name = "Windsurf Next",
                WindowsDefaultDirName = "Windsurf Next",
                WindowsExeName = "Windsurf - Next.exe",
                MacAppName = "Windsurf - Next.app",
                LinuxExeName = "windsurf-next",
                UserDataDirName = ".windsurf-next"
            },
            new()
            {
                Name = "Trae",
                WindowsDefaultDirName = "Trae",
                WindowsExeName = "Trae.exe",
                MacAppName = "Trae.app",
                LinuxExeName = "trae",
                UserDataDirName = ".trae"
            }
        };

	    /// <summary>
	    ///     The name of the fork (that is displayed to the user).
	    /// </summary>
	    public string Name { get; set; }

	    /// <summary>
	    ///     The user data directory name in the user profile (including the leading dot)(it's the same across different
	    ///     platforms).
	    /// </summary>
	    public string UserDataDirName { get; set; }

	    /// <summary>
	    ///     The latest C# language version supported by this fork.
	    /// </summary>
	    public Version LatestLanguageVersion { get; set; }

	    /// <summary>
	    ///     True if this fork is always a pre-release version, otherwise false(then is pre-release version will be checked
	    ///     dynamically)
	    /// </summary>
	    public bool IsPrerelease { get; set; }

	    /// <summary>
	    ///     The default folder name for a fork used on Windows (typically in Program Files or Local AppData).
	    /// </summary>
	    public string WindowsDefaultDirName { get; set; }

	    /// <summary>
	    ///     The executable name on Windows (without .exe extension).
	    /// </summary>
	    public string WindowsExeName { get; set; }

	    /// <summary>
	    ///     The app name on macOS (without .app extension).
	    /// </summary>
	    public string MacAppName { get; set; }

	    /// <summary>
	    ///     The executable name on Linux.
	    /// </summary>
	    public string LinuxExeName { get; set; }
    }
}