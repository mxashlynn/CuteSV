using System;

namespace CuteSVRunner
{
    /// <summary>
    /// A simple game object stand-in.
    /// </summary>
    public class TestSimpleClass
    {
        #region Characteristics
        /// <summary>Unique identifier.</summary>
        public int ID { get; private set; }

        /// <summary>Player-facing name.</summary>
        public string Name { get; private set; }

        /// <summary>Optional comment.</summary>
        public string Comment { get; private set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of concrete implementations of the <see cref="TestSimpleClass"/> class.
        /// </summary>
        /// <param name="id">Unique identifier for the <see cref="TestSimpleClass"/>.  Cannot be less than 0.</param>
        /// <param name="name">Player-friendly name of the <see cref="TestSimpleClass"/>.  Cannot be null or empty.</param>
        /// <param name="comment">Comment of, on, or by the <see cref="TestSimpleClass"/>.</param>
        public TestSimpleClass(int id, string name, string comment)
        {
            if (id < 0) { throw new ArgumentOutOfRangeException(nameof(id)); }
            if (string.IsNullOrEmpty(name)) { throw new ArgumentOutOfRangeException(nameof(name)); }

            ID = id;
            Name = name;
            Comment = comment ?? "";
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="TestSimpleClass"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => Name;
        #endregion
    }
}
