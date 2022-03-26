using System.Collections;
using System.Numerics;

namespace CuteSVRunner
{
    /// <summary>
    /// A square, two-dimensional collection of <see cref="int"/>s.
    /// </summary>
    public class IntGrid
    {
        #region Class Defaults
        /// <summary>A value to use in place of uninitialized <see cref="IntGrid"/>s.</summary>
        public static IntGrid Empty => new();
        #endregion

        /// <summary>The backing collection of <see cref="MapChunk"/>s.</summary>
        private readonly int[,] Ints;

        #region Initialization
        /// <summary>
        /// Initializes a new <see cref="IntGrid"/> with dimensions determined by <see cref="TestComplexClass"/>.
        /// </summary>
        public IntGrid()
            : this(TestComplexClass.ElementsPerDimension, TestComplexClass.ElementsPerDimension) { }

        /// <summary>
        /// Initializes a new empty <see cref="IntGrid"/>.
        /// </summary>
        /// <param name="rowCount">The length of the Y dimension of the collection.</param>
        /// <param name="columnCount">The length of the X dimension of the collection.</param>
        public IntGrid(int rowCount, int columnCount)
        {
            Ints = new int[rowCount, columnCount];
            for (var y = 0; y < rowCount; y++)
            {
                for (var x = 0; x < columnCount; x++)
                {
                    Ints[y, x] = x * y % 10;
                }
            }
        }

        /// <summary>
        /// Initializes a new <see cref="IntGrid"/> from the given 2D <see cref="int"/> array.
        /// </summary>
        /// <param name="ints">An existing array of MapChunks.</param>
        public IntGrid(int[,] ints)
            => Ints = ints;
        #endregion

        #region IGrid Implementation
        /// <summary>Gets the number of elements in the Y dimension of the <see cref="IntGrid"/>.</summary>
        public int Rows
            => Ints?.GetLength(0) ?? 0;

        /// <summary>Gets the number of elements in the X dimension of the <see cref="IntGrid"/>.</summary>
        public int Columns
            => Ints?.GetLength(1) ?? 0;

        /// <summary>The total number of parquets collected.</summary>
        public int Count
        {
            get
            {
                var count = 0;
                for (var y = 0; y < Rows; y++)
                {
                    for (var x = 0; x < Columns; x++)
                    {
                        count += Ints[y, x];
                    }
                }
                return count;
            }
        }

        /// <summary>Access to any <see cref="MapChunk"/> in the grid.</summary>
        public ref int this[int y, int x]
            => ref Ints[y, x];

        /// <summary>
        /// Exposes an enumerator for the <see cref="IntGrid"/>, which supports simple iteration.
        /// </summary>
        /// <remarks>For serialization, this guarantees stable iteration order.</remarks>
        /// <returns>An enumerator.</returns>
        public IEnumerator GetEnumerator()
            => Ints.GetEnumerator();
        #endregion

        #region Utilities
        /// <summary>
        /// Determines if the given position corresponds to a point on the grid.
        /// </summary>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2 position)
            => position.X > -1
            && position.X < Rows
            && position.Y > -1
            && position.Y < Columns;
        #endregion
    }
}
