using System.Text;

namespace CuteSV
{
    /// <summary>
    /// Implements parsing routings.
    /// TODO: This class needs to change.  The architecture needs to be rethought.
    /// </summary>
    internal static class Parsing
    {
        #region Parse Routines
        /// <summary>
        /// Interprets the given file content as a collection of instances of the given type.
        /// </summary>
        /// <param name="content">The file content.</param>
        /// <param name="objectList">The collection of instances.</param>
        /// <typeparam name="T">The type collected.</typeparam>
        /// <returns><c>true</c> if and only if the content was parsed into a collection of the given type without error.</returns>
        public static bool TryParseSeries<T>(string content, out T objectList)
            // File Type 1 in the spec.
            => false;

        /// <summary>
        /// Interprets the given file content as a single instance whose class implements <see cref="Parquet.IGrid"/>.
        /// </summary>
        /// <param name="content">The file content.</param>
        /// <param name="instance">The instance.</param>
        /// <typeparam name="T">The <paramref>instance</paramref>'s type.</typeparam>
        /// <returns><c>true</c> if and only if the content was parsed into an instance of the given type without error.</returns>
        public static bool TryParseGrid<T>(string content, out T instnace)
            // File Type 2 in the spec.
            => false;
        #endregion

        #region Helper Routines
        /// <summary>
        /// Ensure that the given file content ends in a linefeed character.
        /// </summary>
        /// <param name="content">The file content to normalize.</param>
        /// <returns>The normalized file content.</returns>
        internal static string NormalizeFileContent(string content)
            => content[content.Length] == Characters.LineFeed
                ? content
                : $"{content}{Characters.LineFeed}";
        #endregion
    }
}
