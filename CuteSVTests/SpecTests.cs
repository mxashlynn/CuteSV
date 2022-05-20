using Xunit;

namespace CuteSVTests
{
    public class SpecTests
    {
        /*
        File = (ListFile / ObjectFile)
        ListFile = Header LF *(Record LF) 
        ObjectFile = KVPHeader LF *Grid
        Header = NonEscapedField *(COMMA NonEscapedField)
        KVPHeader = TextData COLON TextData *COMMA
        Record = Field *(COMMA Field)
        Grid = Subheader LF *(Record LF)
        Subheader = NonEscapedField *COMMA
        Field = (NonEscapedField / EscapedField)
        NonEscapedField = *NonEscapedTextData
        EscapedField = DQUOTE *(EscapedTextData / 2DQUOTE) DQUOTE
        NonEscapedTextData = Printable Extended ASCII *excluding* COMMA, LF.
        EscapedTextData = Printable Extended ASCII *excluding* LF or single DQUOTE.
         */
        [Fact]

        public void Test1()
        {

        }
    }
}
