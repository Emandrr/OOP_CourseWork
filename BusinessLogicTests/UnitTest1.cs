using MedicineManage.BL;
using MedicineManage.Domain;
namespace BusinessLogicTests
{
    public class Tests
    {

        [Test]
        public void TestGeminiOnError()
        {
            DiagnosisWithGemini dm = new DiagnosisWithGemini();
            var txt = dm.GetAnswer("���������");
            string tt = txt.Result;
            Assert.AreEqual(tt, "������ ������������ LLM ��� ������ �����.\n");
        }
        [Test]
        public void TestGeminiOnError2()
        {
            DiagnosisWithGemini dm = new DiagnosisWithGemini();
            var txt = dm.GetAnswer("���� ���� ���� ��� ������������");
            string tt = txt.Result;
            Assert.AreEqual(tt, "������ ������������ LLM ��� ������ �����.\n");
        }

        [Test]
        public void TestGeminiOnError3()
        {
            DiagnosisWithGemini dm = new DiagnosisWithGemini();
            var txt = dm.GetAnswer("���� ���� ���� ���");
            string tt = txt.Result;
            Assert.AreEqual(tt, "������ ������������ LLM ��� ������ �����.\n");
        }
        [Test]
        public void TestGeminiOnError4()
        {
            DiagnosisWithGemini dm = new DiagnosisWithGemini();
            var txt = dm.GetAnswer("������� ������� �������");
            string tt = txt.Result;
            Assert.AreEqual(tt, "������ ������������ LLM ��� ������ �����.\n");
        }
        [Test]
        public void TestGeminiOnError5()
        {
            DiagnosisWithGemini dm = new DiagnosisWithGemini();
            var txt = dm.GetAnswer("�������� ��� ��� ������ �������� �� ����������� �������");
            string tt = txt.Result;
            Assert.AreEqual(tt, "������ ������������ LLM ��� ������ �����.\n");
        }
        [Test]
        public void TestGeminiOnError6()
        {
            DiagnosisWithGemini dm = new DiagnosisWithGemini();
            var txt = dm.GetAnswer("�������� ��� ��� ������ �������� �� ����������� �������. ������, ����������");
            string tt = txt.Result;
            Assert.AreEqual(tt, "������ ������������ LLM ��� ������ �����.\n");
        }
        [Test]
        public void TestGeminiOnError7()
        {
            DiagnosisWithGemini dm = new DiagnosisWithGemini();
            var txt = dm.GetAnswer("");
            string tt = txt.Result;
            Assert.AreEqual(tt, "������ ������������ LLM ��� ������ �����.\n");
        }
        [Test]
        public void TestGeminiOnError8()
        {
            DiagnosisWithGemini dm = new DiagnosisWithGemini();
            var txt = dm.GetAnswer("Gemini AI 120");
            string tt = txt.Result;
            Assert.AreEqual(tt, "������ ������������ LLM ��� ������ �����.\n");
        }
    }
}