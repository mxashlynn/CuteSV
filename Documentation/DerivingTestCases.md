# CuteSV Test Cases

This contains test cases initially procuded as part of the design process.

These cases were derived from the specification on March 23rd, 2022.

Once initial design and implementation are complete this file may not be updated as the spec and test cases themselves are updated.

## Format Tests

1. Basic ASCII is accepted.
    - The program does not produce an error when given a stream of printable ASCII characters.
2. UTF-8 with characters from the Multilingual Plane Blocks 1 and 2 are accepted.
    - The program does not produce an error when given a stream of UTF-8 characters, including when those characters begin with a BOM.
3. Carriage Return-Linefeed pairs are replaced by Linefeeds alone.
    - This is a preprocess step.
4. An input stream that does not end in a linefeed does not produce an error.
5. An input stream that contains no Double-quotation-marks and `N` commas produces `N + 1` string results.
6. An output stream ends in a linefeed.

## Content Tests

7. A Header can be identified and parsed.
8. A Header that contains an Escaped Field produces an error.
9. An input stream without a Header produces an error.
10. An input stream containing a Record that has more Fields than the Header produces an error.
11. An input stream containing a Record that has fewer Fields than the Header produces an error.
12. A Record preceded by whitespace does not produce an error.
    - The whitespace is ignored.
13. A Record followed by whitespace does not produce an error.
    - The whitespace is ignored.
14. A NonEscaped Field preceded by whitespace does not produce an error.
    - The whitespace is ignored.
15. A NonEscaped Field followed by whitespace does not produce an error.
    - The whitespace is ignored.
16. An Escaped Field preceded by whitespace produces a string that contains that whitespace.
17. An Escaped Field followed by whitespace produces a string that contains that whitespace.
18. An empty line between Records produces an error.
19. An Escaped Field containing a linefeed produces an error.
20. An Escaped Field containing a comma does not produce an error.
21. An Escaped Field containing two side-by-side double-quotation-marks does not produce an error.
22. An Escaped Field containing a single double-quotation-mark produces an error.

## Feature Tests

23. An object containing multiple named properties can be serialized, using commas and linefeeds as delimiters.
24. A string describing an object containing multiple named properties can be deserialized.
25. An object containing a list of objects whose types are identical can be serialized.
26. A string describing a list of objects whose types are identical can be deserialized.
27. Serializing a collection of objects produces a file named according to the collection type.
28. Each Field in a serialized collection corresponds to the name of a property of the collected type.
29. Serializing a single complex instance produces a file named according to its type, ID, and Name. 
30. Desrializing a single complex instance for which more than while file is named with its type, ID, and Name does not produce an error.
    - Moreover, the first such file is selected and the second such file is ignored.
31. Only the first Field of the Header in a serialized complex object is populated.
32. The first Field of the Header in a serialized complex object contains a key-value pair expressing the object's internal ID, using the colon character as a delimiter.
33. Each array within a complex object produces one or more Grids
34. Each Grid begins with a Subheader.
35. Only the first Field of the Subheader in a Grid is populated.
36. There are precisely as many Fields in the Subheader as there are Fields in the Header.
37. There are precisely as many Records per Grid as there are Fields in the Subheader.
38. Desrializing an instance for which no corresponding file exists produces an error.

## Smoke Tests

39. The entire set of Parquet ExampleData can be successfully deserialized.
40. The entire set of Parquet ExampleData can be successfully serialized.
    - No data on disc is changed when tests 39 and 40 are performed in sequence and also in isolation from other operations.  In other words, serialization and deserialization do not themselves alter data.
