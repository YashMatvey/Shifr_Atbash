using Shifr_Atbash;
namespace NunitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            string Slovo = "������";
            string expected = "������";
            CifrAtbash n = new CifrAtbash();
            Slovo = n.ChifrA(Slovo);
            Assert.AreEqual(Slovo, expected);
        }
        [Test]
        public void Test2()
        {
            string Slovo = "������";
            string expected = "������";
            CifrAtbash n = new CifrAtbash();
            Slovo = n.ChifrA(Slovo);
            Assert.AreEqual(Slovo, expected);
        }
        [Test]
        public void Test3()
        {
            string Slovo = "Hallo world!";
            string expected = "Szool dliow!";
            CifrAtbash n = new CifrAtbash();
            Slovo = n.ChifrA(Slovo);
            Assert.AreEqual(Slovo, expected);
        }
        [Test]
        public void Test4()
        {
            string Slovo = "Szool dliow!"; 
            string expected = "Hallo world!";
            CifrAtbash n = new CifrAtbash();
            Slovo = n.ChifrA(Slovo);
            Assert.AreEqual(Slovo, expected);
        }
        [Test]
        public void Test5()
        {
            string Slovo = "������ ������";
            string expected = "������ ������";
            CifrAtbash n = new CifrAtbash();
            Slovo = n.ChifrA(Slovo);
            Assert.AreEqual(Slovo, expected);
        }
        [Test]
        public void Test6()
        {
            string Slovo = "������ ������";
            string expected = "������ ������";
            CifrAtbash n = new CifrAtbash();
            Slovo = n.ChifrA(Slovo);
            Assert.AreEqual(Slovo, expected);
        }
    }
}