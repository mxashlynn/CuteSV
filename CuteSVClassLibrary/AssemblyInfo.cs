using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Make no promises to maintain public services.
[assembly: ComVisible(false)]

// Show warnings on CLS-noncompliant statements to better support .NET languages other than C#.
[assembly: CLSCompliant(true)]

// Allow tests to access classes and members with internal accessibility.
[assembly: InternalsVisibleTo("CuteSVTests")]

namespace CuteSV
{
    /// <summary>
    /// Provides assembly-wide information.
    /// </summary>
    [SuppressMessage("Performance", "CA1815:Override equals and operator equals on value types",
                     Justification = "Comparing two AssemblyInfos is nonsensical.")]
    public readonly struct AssemblyInfo
    {
        /// <summary>Describes the version of the class library itself.</summary>
        /// <remarks>
        /// The version has the format "{Major}.{Minor}.{Patch}.{Build}".
        /// - Major: Enhancements or fixes that break the API or its serialized data.
        /// - Minor: Enhancements that do not break the API or its serialized data.
        /// - Patch: Fixes that do not break the API or its serialized data.
        /// - Build: Procedural updates that do not imply any changes, such as when rebuilding for APK/IPA submission.
        /// </remarks>
        public static readonly string LibraryVersion = typeof(AssemblyInfo).Assembly?.GetName()?.Version?.ToString() ?? "?.?.?.?";
    }
}
