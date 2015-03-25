using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TfsSecurityTools.Extractors;
using TfsSecurityTools.Models;
using System.Collections.Generic;

namespace TfsSecurityTools.Tests.Extractors
{
    [TestClass]
    public class ApplicationGroupExtractorTest
    {
        private IEnumerable<ApplicationGroupDescriptor> Extract(string url)
        {
            string[] name = new string[0];
            return ApplicationGroupExtractor.Extract(url, name);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowArgumentNullExceptionWhenUrlIsNull()
        {
            string url = null;
            Extract(url);
        }

        [TestMethod]
        [ExpectedException(typeof(UriFormatException))]
        public void ShouldThrowUriFormatExceptionWhenProjectCollectionUrlIsNotAValidUri()
        {
            string url = "some_invalid_uri";
            Extract(url);
        }
    }
}
