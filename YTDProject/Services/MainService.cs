using System.Text.RegularExpressions;
using YTDProject.Model;

namespace YTDProject.Services
{
    public class MainService : IMainService
    {
        public List<string> GetSortedList(List<string> notSortedList)
        {
            List<string> result = new();
            List<StringGroup> groups = new();

            foreach (var item in notSortedList)
            {
                string[] splitedItem = item.Split("_");
                if (item[..3].Equals("YTD"))
                {
                    result.Add(item);
                }
                else if (splitedItem.Length == 2 && int.TryParse(splitedItem[0], out int numvalue) && Regex.IsMatch(splitedItem[1], @"^[a-zA-Z]+$"))
                {
                    if (groups.Select(x => x.GroupName).Contains(splitedItem[1]))
                    {
                        var group = groups.FirstOrDefault(x => x.GroupName.Equals(splitedItem[1]));
                        var value = new ValueStructure(int.Parse(splitedItem[0]), item);
                        if (group != null)
                        {
                            group.Values.Add(value);
                        }
                    }
                    else
                    {
                        StringGroup newGroup = new()
                        {
                            GroupName = splitedItem[1],
                            Values = new List<ValueStructure>()
                            {
                                new ValueStructure()
                                {
                                    Num = int.Parse(splitedItem[0]),
                                    Value = item
                                }
                            }
                        };
                        groups.Add(newGroup);
                    }
                }
            }
            var sortedGroups = new List<StringGroup>();
            sortedGroups.AddRange(groups.OrderBy(x => x.GroupName));
            foreach (var group in sortedGroups)
            {
                var values = group.Values.OrderBy(x=> x.Num == 0).ThenBy(x => x.Num).Select(x => x.Value).ToList();
                result.AddRange(values);
            }
            
            return result;
        }
    }
}
