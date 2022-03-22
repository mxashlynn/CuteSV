# CuteSV
A simplistic C# serialization library for [Parquet](https://github.com/mxashlynn/Parquet).

This is not a robust or general-purpose CSV solution.
Instead, it is built expressly for the needs of the Parquet library and associated tools.

You probably don't want to use this in non-Parquet projects.

For more details see the [format specification](https://github.com/mxashlynn/CuteSV/blob/main/Documentation/SPEC.md).


## Version 0.1 Warning
This project is incomplete and not yet ready for use.

# Repository Structure

The solution contains several related projects.
Each C# namespace gets its own folder.

- **CuteSVLibrary**
    - The serialization solution itself.
- **CuteSVRunner**
    - A simple smoke test for CuteSV.
- **CuteSVUnitTests**
    - Unit tests for CuteSV.
- **Documentation**
    - How to use the library.
- **ExampleData**
    - Test CSV files.

# Requirements

To work with this repository you will need:

- [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0)

# Contributors
- Design and code by [Paige Ashlynn](https://github.com/mxashlynn/).
