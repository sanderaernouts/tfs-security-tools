using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TfsSecurityTools.Extractors;
using TfsSecurityTools.Models;

namespace TfsSecurityTools.Tests.Extractors
{
    [TestClass]
    public class ApplicationGroupExtractorTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowArgumentNullExceptionWhenUrlIsNull()
        {
            string url = null;
            ApplicationGroupExtractor.Extract(url);
        }

        [TestMethod]
        [ExpectedException(typeof(UriFormatException))]
        public void ShouldThrowUriFormatExceptionWhenProjectCollectionUrlIsNotAValidUri()
        {
            string url = "some_invalid_uri";
            ApplicationGroupExtractor.Extract(url);
        }
    }
}
