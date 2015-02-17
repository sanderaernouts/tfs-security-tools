using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TfsSecurityTools.Extractors;
using System.Collections.Generic;
using TfsSecurityTools.Models;
using TfsTestingHarness;
using TfsTestingHarness.Options;

namespace TfsSecurityTools.Tests.Extractors
{
    [TestClass]
    public class TeamProjectCollectionExtractorTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowArgumentNullExceptionWhenUrlIsNull()
        {
            string url = null;
            TeamProjectCollectionExtractor.Extract(url);
        }

        [TestMethod]
        [ExpectedException(typeof(UriFormatException))]
        public void ShouldThrowUriFormatExceptionWhenProjectCollectionUrlIsNotAValidUri()
        {
            string url = "some_invalid_uri";
            TeamProjectCollectionExtractor.Extract(url);
        }

        [TestMethod]
        public void ShouldReturnListOfAllCollectionOnAServer()
        {
            string url = "https://some.test.tfs/tfs/collection";
            List<TeamProjectCollectionModel> expectedProjects = new List<TeamProjectCollectionModel>()
            {
                new TeamProjectCollectionModel() {Name="Collection1", Url=String.Format("{0}/{1}", url, "Collection1")},
                new TeamProjectCollectionModel() {Name="Collection2", Url=String.Format("{0}/{1}", url, "Collection2")},
                new TeamProjectCollectionModel() {Name="Collection3", Url=String.Format("{0}/{1}", url, "Collection3")}
            };

            TeamFoundationServerOptions options = new TeamFoundationServerOptions()
            {
                Url = "https://some.tfs.server/tfs",
                Collections = new List<TeamProjectCollectionOptions>(){
                    new TeamProjectCollectionOptions("Collection1"),
                    new TeamProjectCollectionOptions("Collection2"),
                    new TeamProjectCollectionOptions("Collection3")
                }
            };

            using (var harness = new TeamFoundationServerHarness(options))
            {
                IList<TeamProjectCollectionModel> actualProjects = TeamProjectCollectionExtractor.Extract(options.Url);
                //Assert.IsTrue(result);
            }


        }
    }
}
