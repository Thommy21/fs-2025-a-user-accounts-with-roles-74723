using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using fs_user_accounts.Data;

namespace AppTest.Tests
{
    public class MockDataTests
    {
        [Fact]
        public void Patients_ReturnsNonNullList()
        {
            var result = MockData.Patients();
            Assert.NotNull(result);
        }

        [Fact]
        public void Patients_ReturnsEmptyList()
        {
            var result = MockData.Patients();
            Assert.Empty(result);
        }

        [Fact]
        public void Patients_ReturnsNewInstanceEachCall()
        {
            var first = MockData.Patients();
            var second = MockData.Patients();
            Assert.NotSame(first, second);
        }
    }
}
