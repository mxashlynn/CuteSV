# CuteSV

This CSV parser is built expressly for the needs of the Parquet library and its tools.
Here are the assumptions CuteSV makes about the files it reads and writes.

## Format Specification

### Types of Files

Two file subtypes are recognized:
1. Those whose records represent a list of objects, each a distinct instance of the same type of object.
2. Those whose records represent of a single complex object, typically including data that depends on a specific 2D layout.

### For All Files

- Every file begins with a Header. <a id="Ref1"></a><sup>[1](#Note1)</sup>
    - There is only one Header per file.
- Every file ends with a terminal linefeed character  (ASCII 10, Unicode U+000A `\n`). <a id="Ref2"></a><sup>[2](#Note2)</sup>
- The Header and each Record contain exactly the same number of Fields.
    - However, Fields in a Header are never escaped.
- Whitespace leading or trailing the Header or any Record is ignored.
- Records are delimited by a single linefeed character. <a id="Ref3"></a><sup>[3](#Note3)</sup>
    - The last Record in a file is always followed by a linefeed.
    - Linefeeds are never permitted within Records.
- Fields within the Header and within Records are delimited by a single comma character (ASCII 44, Unicode U+002C `,`).
    - Commas are permitted within a Field only if that Field is escaped.
- Whitespace leading or trailing any Field is ignored. <a id="Ref4"></a><sup>[4](#Note4)</sup>
    - Leading and trailing whitespace is preserved in a Field only if that Field is escaped.
- Fields are escaped by enclosing their entire contents in double-quotation-marks (ASCII 34, Unicode U+0022 `"`).
    - Double-quotation-marks within an escaped field must themselves be escaped by duplication; that is, by preceding each double quote with another double quote.

### For File Subtype 1, Lists of Objects

- The File Name names the collection of objects. <a id="Ref5"></a><sup>[5](#Note5)</sup>
    - More specifically, the name is of the form `[Object Collection Name].csv`.
    - For example, `BlockModels.csv` represents a collection of BlockModel objects.
- The Header names each Field, such that the names may correspond to the variable used by Parquet to store this datum and the label that presents this datum to the game designer via tools.
    - For example, `CurrentBehaviorID` could be the name of a both a Parquet variable and a CuteSV Header Field, with `Current Behavior ID` being the associated label in Scribe.

### For File Subtype 2, Single Objects

- The File Name names the specific instance of this object and its type.
    - More specifically, the name is of the form `[Object Type Name].[Internal ID].(Optional Human-Readable Name).csv`. <a id="Ref6"></a><sup>[6](#Note6)</sup>
    - For example, `RegionModel.110000.VanillaRock.csv` represents a RegionModel object with ID 110000 that models a game object named Vanilla Rock.
- Only the first Field of the Header is populated, containing a key-value pair expressing the object's internal ID.
    - More specifically, the key-value pair is of the form `[Internal ID Name]:[Internal ID]`.
    - For example, `ModelID:110000`.
    - Note that the delimiter used by this key-value pair is a single colon character (ASCII 58, Unicode U+003A `:`).
- The Header is followed by one or more Grids.
- Each Grid begins with a Subheader.
    - Like the Header proper, only the first Field of a Subheader is populated, containing the internal name of the collected data.
    - For example, `ParquetStatuses` names a grid of ParquetStatus objects.
- Each Grid is concluded by a set of Records.
    - There are precisely as many Records per Grid as there are Fields in the Header, so that all Grid Collections represent square arrays of data.
    - Because the size of each Grid is known in advance, no termination marker is required.
- The file ends at the conclusion of the last Grid.

## Notes On Compatibility

CuteSV produces valid, traditional CSV files.

To ease the implementation of Parquet, additional constraints are imposed when writing these files and expected when they are read.

This means that CuteSV is more strict than, for example, [RFC 4180](https://www.rfc-editor.org/rfc/rfc4180).

However, any software capable of working with CSV files should accept files created by CuteSV.

CuteSV is tolerant only of certain deviations from its assumptions.

In particular:

1. <a id="Note1"></a>If a CSV file does not begin with a Header, CuteSV will not be able to interpret it. [↑](#Ref1)
2. <a id="Note2"></a>If a CSV file does not end in a linefeed, one will be appended. [↑](#Ref2)
3. <a id="Note3"></a>CuteSV always outputs linefeeds but will accept linefeed-carriage return pairs. [↑](#Ref3)
4. <a id="Note4"></a>Any whitespace ignored when reading is not preserved when writing. [↑](#Ref4)
5. <a id="Note5"></a>Unlike most CSV readers, CuteSV specifies the names of the files it reads and writes. [↑](#Ref5)
6. <a id="Note6"></a>Only the object type name and internal ID are used when looking up a file of subtype 2.  If more than one file name begins with these strings, the first such file found is used. [↑](#Ref6)

## Formal Grammar

Aside from naming conventions and the rule about the number of Records per Grid, this specification may be expressed using Augmented Backus-Naur Form in the following way:

> File = (ListFile / ObjectFile)
> 
> ListFile = Header LF \*(Record LF)
> 
> ObjectFile = KVPHeader LF \*Grid
> 
> Header = NonEscapedField \*(COMMA NonEscapedField)
> 
> KVPHeader = TextData COLON TextData \*COMMA
> 
> Record = Field \*(COMMA Field)
> 
> Grid = Subheader LF \*(Record LF)
> 
> Subheader = NonEscapedField \*COMMA
> 
> Field = (EscapedField / NonEscapedField)
> 
> NonEscapedField = \*(TextData / COLON / DQUOTE)
> 
> EscapedField = DQUOTE \*(TextData / COMMA / COLON / 2DQUOTE) DQUOTE
> 
> TextData = VCHAR *excluding* COMMA, COLON, LF, or DQUOTE.
> 
> COMMA = %d44
> 
> COLON = %d58
> 
> DQUOTE =  %d34
> 
> LF = %d10
> 
> VCHAR = Any printable Extended ASCII character (or, equiavelently, any printable UTF-8 character from the Basic Multilingual Plane Blocks 1 or 2 U+0000 to U+00FF).

## Formal Dialect

Much of this specification can be summarized in the following [CSV Dialect](https://specs.frictionlessdata.io//csv-dialect/) JSON object.

```json
{
  "dialect": {
    "csvddfVersion": 1.2,
    "delimiter": ",",
    "doubleQuote": true,
    "lineTerminator": "\n",
    "quoteChar": ,
    "skipInitialSpace": true,
    "header": true,
    "commentChar":
  }
}
```
