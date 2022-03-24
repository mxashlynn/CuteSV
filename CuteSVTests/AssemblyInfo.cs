using System;
using System.Runtime.InteropServices;
using CuteSV;
using Xunit;

// Make no promises to maintain internal services.
[assembly: ComVisible(false)]

// Tests are API consumers, not API providers.
[assembly: CLSCompliant(false)]

namespace CuteSVTests
{
    /// <summary>
    /// Tests <see cref="AssemblyInfo"/>.
    /// </summary>
    public class AssemblyInfoTests
    {
        #region Values for Tests
        /// <summary>This is the canonical invalid library version string used in serialization tests.</summary>
        private const string invalidLibVersion = "0.0.0.0";

        /// <summary>This is the string used if the library version cannot be loaded.</summary>
        private const string errorLibVersion = "?.?.?.?";
        #endregion

        [Fact]
        internal void SupportedLibraryVersionIsDefinedTest()
        {
            Assert.False(string.IsNullOrEmpty(AssemblyInfo.LibraryVersion));
        }

        [Fact]
        internal void SupportedLibraryVersionIsNotInvalidTest()
        {
            Assert.NotEqual(invalidLibVersion, AssemblyInfo.LibraryVersion);
        }

        [Fact]
        internal void SupportedLibraryVersionWasFoundTest()
        {
            Assert.NotEqual(errorLibVersion, AssemblyInfo.LibraryVersion);
        }
    }
}
