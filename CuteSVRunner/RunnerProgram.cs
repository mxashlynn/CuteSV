using System;
using System.Collections.Generic;

namespace CuteSVRunner
{
    /// <summary>
    /// A simple program used to run some basic features of <see cref="CuteSV"/>.
    /// </summary>
    internal static class RunnerProgram
    {
        #region Test Objects
        /// <summary>A container for simple test objects.</summary>
        private static IList<object> SimpleObjects = new List<object>();

        /// <summary>A container for complex test objects.</summary>
        private static IList<object> ComplexObjects = new List<object>();
        #endregion

        #region Test Routines
        /// <summary>
        /// Attempts to load a series of simple objects from a single file.
        /// </summary>
        /// <returns><c>true</c> if the objects were successfully deserialized; <c>false</c> otherwise.</returns>
        private static bool TryLoadCollections()
        {
            SimpleObjects.Add(1);
            SimpleObjects.Add(2);
            SimpleObjects.Add(3);

            return SimpleObjects.Count > 0;
        }

        /// <summary>
        /// Attempts to load a series of complex objects from several files.
        /// </summary>
        /// <returns><c>true</c> if the objects were successfully deserialized; <c>false</c> otherwise.</returns>
        private static bool TryLoadComplexObjects()
        {
            ComplexObjects.Add(1);
            ComplexObjects.Add(2);
            ComplexObjects.Add(3);

            return ComplexObjects.Count > 0;
        }

        /// <summary>
        /// Attempts to save a series of complex objects to several files.
        /// </summary>
        /// <returns><c>true</c> if the objects were successfully serialized; <c>false</c> otherwise.</returns>
        private static bool TrySaveComplexObjects()
        {
            ComplexObjects.Remove(1);
            ComplexObjects.Remove(2);
            ComplexObjects.Remove(3);

            return ComplexObjects.Count == 0;
        }

        /// <summary>
        /// Attempts to save a series of simple objects to a single file.
        /// </summary>
        /// <returns><c>true</c> if the objects were successfully serialized; <c>false</c> otherwise.</returns>
        private static bool TrySaveCollections()
        {
            SimpleObjects.Remove(1);
            SimpleObjects.Remove(2);
            SimpleObjects.Remove(3);

            return SimpleObjects.Count == 0;
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
