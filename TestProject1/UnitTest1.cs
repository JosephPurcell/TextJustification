namespace TestProject1
{
    using TextJustification;
    [TestClass]
    public class UnitTest1
    {
        public void TestEval(IList<string> text, IList<string> expectedText, int maxWidth)
        {
            if (text.Count != expectedText.Count)
            {
                Assert.Fail();
            }

            for (int i = 0; i < expectedText.Count; i++)
            {
                if (expectedText[i] != text[i])
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            string[] words = ["This", "is", "an", "example", "of", "text", "justification."];
            int maxWidth = 16;
            Solution solution = new Solution();
            IList<string> text = solution.FullJustify(words, maxWidth);
            IList<string> expectedText =
                ["This    is    an",
                    "example  of text",
                    "justification.  "];

            TestEval(text, expectedText, maxWidth);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string[] words = ["What", "must", "be", "acknowledgment", "shall", "be"];
            int maxWidth = 16;
            Solution solution = new Solution();
            IList<string> text = solution.FullJustify(words, maxWidth);
            IList<string> expectedText =
                ["What   must   be",
                    "acknowledgment  ",
                    "shall be        "];

            TestEval(text, expectedText, maxWidth);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string[] words = ["Science", "is", "what", "we", "understand", "well", "enough", "to", "explain", "to", "a", "computer.", "Art", "is", "everything", "else", "we", "do"];
            int maxWidth = 20;
            Solution solution = new Solution();
            IList<string> text = solution.FullJustify(words, maxWidth);
            IList<string> expectedText =
                ["Science  is  what we",
                    "understand      well",
                    "enough to explain to",
                    "a  computer.  Art is",
                    "everything  else  we",
                    "do                  "];

            TestEval(text, expectedText, maxWidth);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string[] words = ["ask", "not", "what", "your", "country", "can", "do", "for", "you", "ask", "what", "you", "can", "do", "for", "your", "country"];
            int maxWidth = 16;
            Solution solution = new Solution();
            IList<string> text = solution.FullJustify(words, maxWidth);
            IList<string> expectedText =
                ["ask   not   what",
                    "your country can",
                    "do  for  you ask",
                    "what  you can do",
                    "for your country"];

            TestEval(text, expectedText, maxWidth);
        }

        [TestMethod]
        public void TestMethod5()
        {
            string[] words = ["Here", "is", "an", "example", "of", "text", "justification."];
            int maxWidth = 14;
            Solution solution = new Solution();
            IList<string> text = solution.FullJustify(words, maxWidth);
            IList<string> expectedText =
                ["Here   is   an",
                    "example     of",
                    "text          ",
                    "justification."];

            TestEval(text, expectedText, maxWidth);
        }

        [TestMethod]
        public void TestMethod6()
        {
            string[] words = ["What", "must", "be", "shall", "be."];
            int maxWidth = 5;
            Solution solution = new Solution();
            IList<string> text = solution.FullJustify(words, maxWidth);
            IList<string> expectedText =
                ["What ", "must ", "be   ", "shall", "be.  "];

            TestEval(text, expectedText, maxWidth);
        }
    }
}