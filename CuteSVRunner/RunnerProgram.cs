using System;
using System.Collections.Generic;

namespace CuteSVRunner
{
    /// <summary>
    /// A simple program used to run some basic features of <see cref="CuteSV"/>.
    /// </summary>
    internal static class RunnerProgram
    {
        #region Test Collections
        /// <summary>A container for simple test objects.</summary>
        private static IList<object> SimpleObjects = new List<object>();

        /// <summary>A container for complex test objects.</summary>
        private static IList<object> ComplexObjects = new List<object>();
        #endregion

        #region Test Routines
        /// <summary>How many <see cref="TestSimpleClass"/>es to create.</summary>
        private const int SimpleListLength = 12;

        /// <summary>
        /// Attempts to load a series of simple objects from a single file.
        /// </summary>
        /// <returns><c>true</c> if the objects were successfully deserialized; <c>false</c> otherwise.</returns>
        private static bool TryLoadCollections()
        {
            for (var i = 0; i < SimpleListLength; i++)
            {
                SimpleObjects.Add(new TestSimpleClass(i, $"Test Object {i}", "A simple object to test."));
            }

            return SimpleObjects.Count == SimpleListLength;
        }

        /// <summary>
        /// Attempts to load a series of complex objects from several files.
        /// </summary>
        /// <returns><c>true</c> if the objects were successfully deserialized; <c>false</c> otherwise.</returns>
        private static bool TryLoadComplexObjects()
        {
            ComplexObjects.Add(new TestComplexClass());

            return ComplexObjects.Count > 0;
        }

        /// <summary>
        /// Attempts to save a series of complex objects to several files.
        /// </summary>
        /// <returns><c>true</c> if the objects were successfully serialized; <c>false</c> otherwise.</returns>
        private static bool TrySaveComplexObjects()
            => CuteSV.Save(ComplexObjects[0]);

        /// <summary>
        /// Attempts to save a series of simple objects to a single file.
        /// </summary>
        /// <returns><c>true</c> if the objects were successfully serialized; <c>false</c> otherwise.</returns>
        private static bool TrySaveCollections()
        {
            var result = true;

            for (var i = 0; i < SimpleListLength; i++)
            {
                result |= CuteSV.Save(SimpleObjects[i]);
            }

            return result;
        }
        #endregion

        /// <summary>
        /// A simple program used to run some basic features of the <see cref="CuteSV"/>.
        /// </summary>
        internal static void Main()
        {
            Console.WriteLine("Beginning smoke test.");
            Console.WriteLine();

            Console.WriteLine(TryLoadCollections() ? "Loaded simple objects." : "Failed to load simple objects!");
            Console.WriteLine(TryLoadComplexObjects() ? "Loaded complex objects." : "Failed to load complex objects!");

            Console.WriteLine(TrySaveComplexObjects() ? "Saved complex objects." : "Failed to save complex objects!");
            Console.WriteLine(TrySaveCollections() ? "Saved simple objects." : "Failed to save simple objects!");

            Console.WriteLine();
            Console.WriteLine("Test complete.");
        }
    }
}
