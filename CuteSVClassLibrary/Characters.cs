namespace CuteSV
{
    /// <summary>
    /// Defines all of the ASCII character values that CuteSV worries about.
    /// </summary>
    internal static class Characters
    {
        #region Character Definitions
        // TODO Replace these casted ints with \u literals.

        /// An ASCII horizontal tab.
        internal const char HorizontalTab = '\u0009';

        /// An ASCII linefeed.
        internal const char LineFeed = '\u000A';

        /// An ASCII vertical tab.
        internal const char VerticalTab = '\u000B';

        /// An ASCII carriage return.
        internal const char CarriageReturn = '\u000D';

        /// The highest value in the lower range of ASCII control characters.
        internal const char EndControlRange = '\u001F';

        /// An ASCII breaking space.
        internal const char Space = '\u0020';

        /// An ASCII double quotation mark.
        internal const char DoubleQuote = '\u0022';

        /// An ASCII comma.
        internal const char Comma = '\u002C';

        /// An ASCII colon.
        internal const char Colon = '\u003A';

        /// An ASCII delete.
        internal const char Delete = '\u007F';

        /// An ASCII non-breaking space.
        internal const char NonBreakingSpace = '\u00FF';

        /// The lowest value outside the range of ASCII extended characters.
        internal const char EndExtendedRange = '\u0100';
        #endregion

        #region Validation Routines
        /// <summary>
        /// Determines if the given <see cref="char"/> is representable by CuteSV.
        /// </summary>
        /// <param name="character">The character to inspect.</param>
        /// <returns><c>true</c> if the given character is any Parquet-printable Extended ASCII character, <c>false</c> otherwise.</returns>
        internal static bool IsRepresentable(char character)
            => character == HorizontalTab
            || character == LineFeed
            || (character > EndControlRange && character < Delete)
            || (character > Delete && character < EndExtendedRange);
        #endregion
    }
}
