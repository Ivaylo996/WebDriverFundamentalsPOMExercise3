using System.Collections.Generic;

namespace AutomationPractice.version2.Modules
{
    public class TestCasePerformanceData
    {
        public TestCasePerformanceData()
        {
            PagePerformanceData = new List<PagePerformanceData>();
        }

        public string TestName { get; set; }
        public double TestArrangeTime { get; set; }
        public double TestTotalTime { get; set; }
        public List<PagePerformanceData> PagePerformanceData { get; set; }
    }
}
