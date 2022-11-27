using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Linq;

using Xunit.Sdk;

namespace GameEngine.Tests
{
    public class TestDamageHealthAttributeData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return  new object[] {   0, 100 };
            yield return  new object[] {  27, 73 };
            yield return  new object[] {   8, 92 };
            yield return  new object[] {  50, 50 };
            yield return  new object[] { 200,  1 } ;
        }
    }

    public class TestDamageHealthFileAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            string[] csvLines = File.ReadAllLines("test-data.csv");
            var testCases = new List<object[]>();

            foreach (var csvLine in csvLines)
            {
                IEnumerable<int> values = csvLine.Split(',').Select(int.Parse);
                object[] testCase = values.Cast<object>().ToArray();
                testCases.Add(testCase);
            }
            return testCases;
        }
    }
}