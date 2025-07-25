﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Linq;
using Hackerzhuli.Code.Editor.Code;

namespace Hackerzhuli.Code.Editor
{
    internal static class Cli
    {
        internal static void Log(string message)
        {
            // Use writeline here, instead of UnityEngine.Debug.Log to not include the stacktrace in the editor.log
            Console.WriteLine($"[VisualStudio.Editor.{nameof(Cli)}] {message}");
        }

        internal static string GetInstallationDetails(ICodeEditorInstallation installation)
        {
            return
                $"{installation.ToCodeEditorInstallation().Name} Path:{installation.Path}, LanguageVersionSupport:{installation.LatestLanguageVersionSupported} AnalyzersSupport:{installation.SupportsAnalyzers}";
        }

        internal static void GenerateSolutionWith(CodeEditor vse, string installationPath)
        {
            if (vse != null && vse.TryGetVisualStudioInstallationForPath(installationPath, true, out var vsi))
            {
                Log($"Using {GetInstallationDetails(vsi)}");
                vse.SyncAll();
            }
            else
            {
                Log($"No Visual Studio installation found in ${installationPath}!");
            }
        }

        internal static void GenerateSolution()
        {
            if (Unity.CodeEditor.CodeEditor.CurrentEditor is CodeEditor vse)
            {
                Log("Using default editor settings for Visual Studio installation");
                GenerateSolutionWith(vse, Unity.CodeEditor.CodeEditor.CurrentEditorInstallation);
            }
            else
            {
                Log("Visual Studio is not set as your default editor, looking for installations");
                try
                {
                    var installations = Discovery
                        .GetVisualStudioInstallations()
                        .Cast<CodeEditorInstallation>()
                        .OrderByDescending(vsi => !vsi.IsPrerelease)
                        .ThenBy(vsi => vsi.Version)
                        .ToArray();

                    foreach (var vsi in installations) Log($"Detected {GetInstallationDetails(vsi)}");

                    var installation = installations
                        .FirstOrDefault();

                    if (installation != null)
                    {
                        var current = Unity.CodeEditor.CodeEditor.CurrentEditorInstallation;
                        try
                        {
                            Unity.CodeEditor.CodeEditor.SetExternalScriptEditor(installation.Path);
                            GenerateSolutionWith(Unity.CodeEditor.CodeEditor.CurrentEditor as CodeEditor,
                                installation.Path);
                        }
                        finally
                        {
                            Unity.CodeEditor.CodeEditor.SetExternalScriptEditor(current);
                        }
                    }
                    else
                    {
                        Log("No Visual Studio installation found!");
                    }
                }
                catch (Exception ex)
                {
                    Log($"Error detecting Visual Studio installations: {ex}");
                }
            }
        }
    }
}