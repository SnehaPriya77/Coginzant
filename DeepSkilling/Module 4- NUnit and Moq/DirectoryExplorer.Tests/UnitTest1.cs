using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using MagicFilesLib;

namespace DirectoryExplorer.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        private Mock<IDirectoryExplorer> mockDirectoryExplorer;

        private readonly string _file1 = "file.txt";
        private readonly string _file2 = "file2.txt";

        [OneTimeSetUp]
        public void Init()
        {
            mockDirectoryExplorer = new Mock<IDirectoryExplorer>();

            mockDirectoryExplorer
                .Setup(x => x.GetFiles(It.IsAny<string>()))
                .Returns(new List<string>
                {
                    _file1,
                    _file2
                });
        }

        [TestCase]
        public void GetFiles_ShouldReturnMockedFiles()
        {
            ICollection<string> files = mockDirectoryExplorer.Object.GetFiles("C:\\Temp");

            Assert.That(files, Is.Not.Null);
            Assert.That(files.Count, Is.EqualTo(2));
            Assert.That(files.Contains(_file1), Is.True);
        }
    }
}