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
        internal const char HorizontalTab = (char)9;

        /// An ASCII linefeed.
        internal const char LineFeed = (char)10;

        /// An ASCII vertical tab.
        internal const char VerticalTab = (char)11;

        /// An ASCII carriage return.
        internal const char CarriageReturn = (char)13;

        /// The highest value in the lower range of ASCII control characters.
        internal const char EndControlRange = (char)31;

        /// An ASCII breaking space.
        internal const char Space = (char)32;

        /// An ASCII double quotation mark.
        internal const char DoubleQuote = (char)34;

        /// An ASCII comma.
        internal const char Comma = (char)44;

        /// An ASCII colon.
        internal const char Colon = (char)58;

        /// An ASCII delete.
        internal const char Delete = (char)127;

        /// An ASCII non-breaking space.
        internal const char NonBreakingSpace = (char)255;

        /// The lowest value outside the range of ASCII extended characters.
        internal const char EndExtendedRange = (char)256;
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
