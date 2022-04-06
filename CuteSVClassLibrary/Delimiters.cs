namespace CuteSV
{
    /// <summary>
    /// Provides a unified source of serialization separators for the library.
    /// </summary>
    public static class Delimiters
    {
        /// <summary>Separator between Records; terminates lines.</summary>
        public const string RecordDelimiter = "\n";

        /// <summary>Separator between Fields.</summary>
        public const string FieldDelimiter = ",";

        /// <summary>Separates sequences of verbatim characters within Escaped Fields.</summary>
        public const string EscapedFieldDelimiter = "\"";

        /// <summary>Separator between Keys and Values withing Fields.</summary>
        public const string EscapedEscapedFieldDelimiter = $"{EscapedFieldDelimiter}{EscapedFieldDelimiter}";

        /// <summary>Separator between Keys and Values withing Fields.</summary>
        public const string KeyValuePairDelimiter = ":";
    }
}
