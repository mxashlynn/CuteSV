using Xunit;

namespace CuteSVTests
{
    public class SpecTests
    {
        /*
        File = (ListFile / ObjectFile)
        ListFile = Header LF \*(Record LF) 
        ObjectFile = KVPHeader LF \*Grid
        Header = NonEscapedField \*(COMMA NonEscapedField)
        KVPHeader = TextData COLON TextData \*COMMA
        Record = Field \*(COMMA Field)
        Grid = Subheader LF \*(Record LF)
        Subheader = NonEscapedField \*COMMA
        Field = (NonEscapedField / EscapedField)
        NonEscapedField = \*(TextData / COLON / DQUOTE)
        EscapedField = DQUOTE \*(TextData / COMMA / COLON / 2DQUOTE) DQUOTE
        TextData = VCHAR *excluding* COMMA, COLON, LF, or DQUOTE.
        VCHAR = Any printable Extended ASCII character (or, equiavelently, any printable UTF-8 character from the Basic Multilingual Plane Blocks 1 or 2 U+0000 to U+00FF).
         */
        [Fact]

        public void Test1()
        {

        }
    }
}
