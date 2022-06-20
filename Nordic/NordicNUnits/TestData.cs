using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NordicNUnits
{
    public class TestData
    {
        public int n;
        public int expected;

        public static List<TestData> GetData()
        { 
            var list = new List<TestData>();
            list.Add(new TestData() { n = 0, expected = 0 });
            list.Add(new TestData() { n = 1, expected = 1 });
            list.Add(new TestData() { n = 2, expected = 1 });
            list.Add(new TestData() { n = 3, expected = 2 });
            list.Add(new TestData() { n = 4, expected = 3 });
            list.Add(new TestData() { n = 5, expected = 5 });
            return list;
        }

        public override string ToString()
        {
            return $"F({n}) = {expected}";
        }
    }
}
