namespace YTDProject.Model
{
    public class StringGroup
    {
        public string GroupName { get; set; }
        public List<ValueStructure> Values { get; set; }

        public StringGroup()
        {
        }

        public StringGroup(string groupName, List<ValueStructure> values)
        {
            GroupName = groupName;
            Values = values;
        }
    }

    public class ValueStructure
    {
        public int Num { get; set; }
        public string Value { get; set; }

        public ValueStructure()
        {
        }

        public ValueStructure(int num, string value)
        {
            Num = num;
            Value = value;
        }
    }
}
