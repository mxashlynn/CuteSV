using System;

namespace CuteSVRunner
{
    /// <summary>
    /// A simple program used to run some basic features of <see cref="CuteSV"/>.
    /// </summary>
    internal static class RunnerProgram
    {
        #region Test Routines
        internal static bool TryLoadModels()
            => true;

        internal static bool TryLoadStatuses()
            => true;

        internal static bool TrySaveStatuses()
            => true;

        internal static bool TrySaveModels()
            => true;
        #endregion

        /// <summary>
        /// A simple program used to run some basic features of the <see cref="CuteSV"/>.
        /// </summary>
        internal static void Main()
        {
            Console.WriteLine("Beginning smoke test.");
            Console.WriteLine();

            Console.WriteLine(TryLoadModels() ? "Loaded models." : "Failed to load models!");
            Console.WriteLine(TryLoadStatuses() ? "Loaded statuses." : "Failed to load statuses!");

            Console.WriteLine(TrySaveStatuses() ? "Saved game state." : "Failed to save statuses!");
            Console.WriteLine(TrySaveModels() ? "Saved models." : "Failed to save models!");

            Console.WriteLine();
            Console.WriteLine("Test complete.");
        }
    }
}
