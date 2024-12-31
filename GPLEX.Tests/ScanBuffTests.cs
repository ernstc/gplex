using System.Text;
using QUT.GplexBuffers;

namespace GPLEX.Tests
{
    [TestClass]
    public class ScanBuffTests
    {
        [TestMethod]
        public void TestBuildBufferWithAsciiEncoding()
        {
            string input = "Hello, World";
            byte[] bytes = Encoding.ASCII.GetBytes(input);
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                ScanBuff buffer = ScanBuff.GetBuffer(stream);

                StringBuilder result = new StringBuilder();
                int ch;
                while ((ch = buffer.Read()) != ScanBuff.EndOfFile)
                {
                    result.Append((char)ch);
                }

                Assert.AreEqual(input, result.ToString());
            }
        }

#if !NET462_OR_GREATER
        [TestMethod]
        public void TestBuildBufferWithLatin1Encoding()
        {
            string input = "Héllo, Wörld";
            Encoding ansiEncoding = Encoding.Latin1;
            byte[] bytes = ansiEncoding.GetBytes(input);
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                ScanBuff buffer = ScanBuff.GetBuffer(stream);

                StringBuilder result = new StringBuilder();
                int ch;
                while ((ch = buffer.Read()) != ScanBuff.EndOfFile)
                {
                    result.Append((char)ch);
                }

                Assert.AreEqual(input, result.ToString());
            }
        }
#endif

        [TestMethod]
        public void TestStringBufferWithMultiByteCharacters()
        {
            string input = "Hello, 世界"; // "Hello, World" in Chinese
            ScanBuff buffer = ScanBuff.GetBuffer(input);

            StringBuilder result = new StringBuilder();
            int ch;
            while ((ch = buffer.Read()) != ScanBuff.EndOfFile)
            {
                result.Append((char)ch);
            }

            Assert.AreEqual(input + "\n", result.ToString());
        }

        [TestMethod]
        public void TestLineBufferWithMultiByteCharacters()
        {
            IList<string> lines = new List<string> { "Hello,", "世界" }; // "Hello," and "World" in Chinese
            ScanBuff buffer = ScanBuff.GetBuffer(lines);

            StringBuilder result = new StringBuilder();
            int ch;
            while ((ch = buffer.Read()) != ScanBuff.EndOfFile)
            {
                result.Append((char)ch);
            }

            Assert.AreEqual("Hello,\n世界\n", result.ToString());
        }

        [TestMethod]
        public void TestBuildBufferWithUtf8Encoding()
        {
            string input = "Hello, 世界"; // "Hello, World" in Chinese
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                ScanBuff buffer = ScanBuff.GetBuffer(stream);

                StringBuilder result = new StringBuilder();
                int ch;
                while ((ch = buffer.Read()) != ScanBuff.EndOfFile)
                {
                    result.Append((char)ch);
                }

                Assert.AreEqual(input, result.ToString());
            }
        }

        [TestMethod]
        public void TestBuildBufferWithUtf16Encoding()
        {
            string input = "Hello, 世界"; // "Hello, World" in Chinese
            byte[] bytes = Encoding.Unicode.GetBytes(input);
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                ScanBuff buffer = ScanBuff.GetBuffer(stream);

                StringBuilder result = new StringBuilder();
                int ch;
                while ((ch = buffer.Read()) != ScanBuff.EndOfFile)
                {
                    result.Append((char)ch);
                }

                Assert.AreEqual(input, result.ToString());
            }
        }

        [TestMethod]
        public void TestBuildBufferWithUtf32Encoding()
        {
            string input = "Hello, 世界"; // "Hello, World" in Chinese
            byte[] bytes = Encoding.UTF32.GetBytes(input);
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                ScanBuff buffer = ScanBuff.GetBuffer(stream);

                StringBuilder result = new StringBuilder();
                int ch;
                while ((ch = buffer.Read()) != ScanBuff.EndOfFile)
                {
                    result.Append((char)ch);
                }

                Assert.AreEqual(input, result.ToString());
            }
        }
    }
}
