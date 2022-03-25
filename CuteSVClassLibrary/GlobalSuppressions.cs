using System.Diagnostics.CodeAnalysis;
// This file is used by Code Analysis to maintain SuppressMessage
// attributes.  Project-level suppressions have no target.

[assembly: SuppressMessage("Design", "CA1031:Do not catch general exception types",
                           Justification = "Parquet logs errors and returns results; it does not throw exceptions.",
                           Scope = "namespaceanddescendants", Target = "~N:CuteSV")]

[assembly: SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional",
                           Justification = "Parquet requires rectangular multidimensional arrays.",
                           Scope = "namespaceanddescendants", Target = "~N:CuteSV")]

[assembly: SuppressMessage("Major Code Smell", "S3358:Ternary operators should not be nested",
                           Justification = "This rule is incorrect.",
                           Scope = "namespaceanddescendants", Target = "~N:CuteSV")]
