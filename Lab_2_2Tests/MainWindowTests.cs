using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab_2_2.Tests
{
    [TestClass()]
    public class MainWindowTests
    {
        [TestMethod()]
        public void IncorrectData()
        {
            MainWindow window = new MainWindow();
            window.Input = "1-7+d-t289t-28r+427t6";
            window.BT_Result_Click(null, null);
            string answer = "Сумма: ???";
            Assert.AreEqual(window.Sum, answer);
        }
        [TestMethod()]
        public void CorrectData()
        {
            MainWindow window = new MainWindow();

            window.Input = "2+3+4+5+6+7+8+9";
            window.BT_Result_Click(null, null);
            string answer1 = "Сумма: 44";
            Assert.AreEqual(window.Sum, answer1);

            window.Input = "2-3+4-5+6-7+8-9";
            window.BT_Result_Click(null, null);
            string answer2 = "Сумма: -4";
            Assert.AreEqual(window.Sum, answer2);

            window.Input = "2-3-4-5-6-7-8-9";
            window.BT_Result_Click(null, null);
            string answer3 = "Сумма: -40";
            Assert.AreEqual(window.Sum, answer3);
        }
        [TestMethod()]
        public void NumbersLessOrEqualOne()
        {
            MainWindow window = new MainWindow();
            window.Input = "4+7+3+0-1+3+4-0";
            window.BT_Result_Click(null, null);
            string answer = "Сумма: ???";
            Assert.AreEqual(window.Sum, answer);
        }
    }
}