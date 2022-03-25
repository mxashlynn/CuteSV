// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters",
                           Justification = "Not needed for a simple smoke test.", Scope = "member",
                           Target = "~M:CuteSVRunner.RunnerProgram.Main")]