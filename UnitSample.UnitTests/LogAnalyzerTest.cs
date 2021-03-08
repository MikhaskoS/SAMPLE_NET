using NUnit.Framework;
using System;

namespace UnitSample.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTest
    {
        #region Пример1
        // Не самый рациональный способ тестирования. Много проблем при изменении
        // исходного кода

        [Test]
        public void IsInvalidLogFileName_BadExt_ReturnFalse()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = LogAnalyzer.IsInvalidLogFileName("badfile.foo");

            Assert.False(result);
        }

        [Test]
        public void IsInvalidLogFileName_GoodExt_ReturnTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = LogAnalyzer.IsInvalidLogFileName("truefile.slf");

            Assert.True(result);
        }

        [Test]
        public void IsInvalidLogFileName_GoodExtUpperCase_ReturnTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = LogAnalyzer.IsInvalidLogFileName("truefile.SLF");

            Assert.True(result);
        }

        #endregion

        #region Пример2 - параметризованные тесты

        [TestCase("badfile.foo", false)]
        [TestCase("truefile.slf", true)]
        [TestCase("truefile.SLF", true)]
        public void IsInvalidLogFileName_VariosExt_CheckThem(string file, bool expected)
        {
            _ = new LogAnalyzer();
            bool result = LogAnalyzer.IsInvalidLogFileName(file);

            Assert.AreEqual(expected, result);
        }

        #endregion
    }
}
