using NUnit.Framework;
using System;

namespace UnitSample.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTest
    {
        #region Пример1 - самый простой вариант
        // Не самый рациональный способ тестирования. Много проблем при изменении
        // исходного кода

        [Test]
        public void IsInvalidLogFileName_BadExt_ReturnFalse()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("badfile.foo");

            Assert.False(result);
        }

        [Test]
        public void IsInvalidLogFileName_GoodExt_ReturnTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("truefile.slf");

            Assert.True(result);
        }

        [Test]
        public void IsInvalidLogFileName_GoodExtUpperCase_ReturnTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("truefile.SLF");

            Assert.True(result);
        }

        #endregion

        #region Пример2 - параметризованные тесты

        [TestCase("badfile.foo", false)]
        [TestCase("truefile.slf", true)]
        [TestCase("truefile.SLF", true)]
        public void IsInvalidLogFileName_VariosExt_CheckThem(string file, bool expected)
        {
           LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName(file);

            Assert.AreEqual(expected, result);
        }

        #endregion

        #region Пример3 - проверка исключений

        // Фабричный метод
        private LogAnalyzer MakeAnalyzer()
        {
            return new LogAnalyzer();
        }

        [Test]
        public void IsValidLogFileName_EmptyFileName_Throws()
        {
            LogAnalyzer analyzer = MakeAnalyzer();

            // перехватываем исключение
            var ex = Assert.Catch<Exception>(() => analyzer.IsValidLogFileName(""));

            // Это выркжение должно совпадать с тем, что прописано в исключении
            StringAssert.Contains("Имя файла должно быть задано!", ex.Message);

        }

        #endregion

        #region Пример4 - игнор тестов

        [Test]
        [Ignore("Тест устарел")]
        public void IsValidLogFileName_Deprecate()
        {
            
        }

        #endregion

        #region Пример5 - контроль состояния системы

        [Test]
        public void IsValidLogFileName_WhenCalled_WasLastFileNameValid()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            analyzer.IsValidLogFileName("falsefile.foo");

            Assert.False(analyzer.WasLastFileNameValid);
        }


        [TestCase("truefile.slf", true)]
        [TestCase("truefile.SLF", true)]
        public void IsValidLogFileName_WhenCalled_WasLastFileNameValid(string file, bool expected)
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName(file);

            Assert.AreEqual(expected, analyzer.WasLastFileNameValid);
        }
        #endregion
    }
}
