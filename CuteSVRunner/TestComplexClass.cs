using System;
using System.Collections.Generic;
using System.Numerics;

namespace CuteSVRunner
{
    /// <summary>
    /// A complex game object stand-in containing a 2D grid.
    /// </summary>
    public class TestComplexClass
    {
        #region Class Defaults
        /// <summary>Provides a throwaway instance of the <see cref="TestComplexClass"/> class with default values.</summary>
        public static TestComplexClass Unused { get; } = new TestComplexClass();

        /// <summary>The length of each <see cref="TestComplexClass"/> dimension.</summary>
        public const int ElementsPerDimension = 64;

        /// <summary>The region's dimensions in parquets.</summary>
        public static Vector2 DimensionsInParquets { get; } = new(ElementsPerDimension, ElementsPerDimension);
        #endregion

        #region Status
        /// <summary>Stored data.</summary>
        public IntGrid Grid { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new <see cref="TestComplexClass"/> with no contents.
        /// </summary>
        public TestComplexClass()
            : this(null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestComplexClass"/> class.
        /// </summary>
        /// <param name="grid">The statuses to store.</param>
        public TestComplexClass(IntGrid grid)
            => Grid = grid ?? IntGrid.Empty;
        #endregion

        /*
        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static TestComplexClass ConverterFactory { get; } = Unused;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            => value is TestComplexClass status
                // NOTE Tertiary delimiter is used here to separate ParquetModelPackGrid from ParquetStatusPackGrid.
                ? $"{GridConverter<ParquetModelPack, ParquetModelPackGrid>.ConverterFactory.ConvertToString(ParquetModels, row, memberMapData)}{Delimiters.TertiaryDelimiter}" +
                  $"{GridConverter<ParquetStatusPack, ParquetStatusPackGrid>.ConverterFactory.ConvertToString(ParquetStatuses, row, memberMapData)}"
                : Logger.DefaultWithConvertLog(value?.ToString() ?? "null", nameof(MapChunk), nameof(Unused));

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrEmpty(text)
                || string.Equals(nameof(Unused), text, StringComparison.OrdinalIgnoreCase))
            {
                return Unused.DeepClone();
            }

            // NOTE Tertiary delimiter is used here to separate ParquetModelPackGrid from ParquetStatusPackGrid.
            var parameterText = text.Split(Delimiters.TertiaryDelimiter);
            var parsedParquetModels = (ParquetModelPackGrid)GridConverter<ParquetModelPack, ParquetModelPackGrid>
                .ConverterFactory
                .ConvertFromString(parameterText[0], row, memberMapData);
            var parsedParquetStatuses = (ParquetStatusPackGrid)GridConverter<ParquetStatusPack, ParquetStatusPackGrid>
                .ConverterFactory
                .ConvertFromString(parameterText[1], row, memberMapData);

            return new TestComplexClass(parsedParquetModels, parsedParquetStatuses);
        }
        #endregion

        #region IDeeplyCloneable Implementation
        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public override T DeepClone<T>()
            => new TestComplexClass((ParquetModelPackGrid)ParquetModels.DeepClone(),
                                (ParquetStatusPackGrid)ParquetStatuses.DeepClone()) as T;
        #endregion

        #region Self Serialization
        /// <summary>
        /// Reads all <see cref="TestComplexClass"/> records from the appropriate file.
        /// </summary>
        /// <returns>The instances read.</returns>
        public static Dictionary<ModelID, TestComplexClass> GetRecords()
        {
            using var reader = new StreamReader(FilePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(ModelID), All.IdentifierOptions);
            csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToUpperInvariant();
            foreach (var kvp in All.ConversionConverters)
            {
                csv.Configuration.TypeConverterCache.AddConverter(kvp.Key, kvp.Value);
            }

            return new Dictionary<ModelID, TestComplexClass>(csv.GetRecords<KeyValuePair<ModelID, TestComplexClass>>());
        }

        /// <summary>
        /// Writes the given <see cref="TestComplexClass"/> records to the appropriate file.
        /// </summary>
        public static void PutRecords(IEnumerable<KeyValuePair<ModelID, TestComplexClass>> regionStatuses)
        {
            if (regionStatuses is null)
            {
                regionStatuses = Enumerable.Empty<KeyValuePair<ModelID, TestComplexClass>>();
            }

            using var writer = new StreamWriter(FilePath, false, new UTF8Encoding(true, true));
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Configuration.NewLine = NewLine.LF;
            csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(ModelID), All.IdentifierOptions);
            foreach (var kvp in All.ConversionConverters)
            {
                csv.Configuration.TypeConverterCache.AddConverter(kvp.Key, kvp.Value);
            }

            csv.WriteHeader<KeyValuePair<ModelID, TestComplexClass>>();
            csv.NextRecord();
            csv.WriteRecords(regionStatuses);
        }
        #endregion
        */

        #region Utilities
        /// <summary>
        /// Determines if the given position corresponds to a point on the grid.
        /// </summary>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public static bool IsValidPosition(Vector2 position)
            => position.X > -1
            && position.X < ElementsPerDimension
            && position.Y > -1
            && position.Y < ElementsPerDimension;

        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="TestComplexClass"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"[{Grid.Count} Elements]";
        #endregion
    }
}
