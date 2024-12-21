namespace MancalaLibrary.DataAccess.Models
{
    public class ConfiguredSqlStatement
    {
        public string Statement { get; set; }


        public ConfiguredSqlStatement(string statement)
        {
            Statement = statement;

            PrependStatement("pragma foreign_keys = ON;");
        }


        public ConfiguredSqlStatement PrependStatement(string newStatement)
        {
            if (newStatement[0] != ';')
            {
                newStatement += ";";
            }


            Statement = string.Concat(new string[] { newStatement, Statement });

            return this;
        }

        public ConfiguredSqlStatement AppendStatement(string newStatement)
        {
            char lastSqlStatementChar = Statement[Statement.Length - 1];

            if (lastSqlStatementChar != ';')
            {
                Statement += ";";
            }


            Statement += newStatement;

            return this;
        }

        public override string ToString()
        {
            return Statement;
        }
    }
}
