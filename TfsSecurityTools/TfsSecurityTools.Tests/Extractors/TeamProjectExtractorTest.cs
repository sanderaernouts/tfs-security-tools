﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TfsSecurityTools.Extractors;
using TfsSecurityTools.Models;
using System.Collections.Generic;
using TfsTestingHarness;
using System.Collections;

namespace TfsSecurityTools.Tests.Extractors
{
    /*
    [TestClass]
    public class TeamProjectExtractorTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowArgumentNullExceptionWhenProjectCollectionUrlIsNull()
        {
            string url = null;
            TeamProjectExtractor.Extract(url);        
        }

        [TestMethod]
        [ExpectedException(typeof(UriFormatException))]
        public void ShouldThrowUriFormatExceptionWhenProjectCollectionUrlIsNotAValidUri()
        {
            string url = "some_invalid_uri";
            TeamProjectExtractor.Extract(url);
        }

        [TestMethod]
        public void ShouldReturnListOfAllProjectsInACollection()
        {
            string url = "https://some.test.tfs/tfs/collection";
            List<TeamProjectDescriptor> expectedProjects = new List<TeamProjectDescriptor>()
            {
                new TeamProjectDescriptor() {Name="FakeProject1", Collection=url, Url=String.Format("{0}/{1}", url, "FakeProject1")},
                new TeamProjectDescriptor() {Name="FakeProject2", Collection=url, Url=String.Format("{0}/{1}", url, "FakeProject2")},
                new TeamProjectDescriptor() {Name="FakeProject3", Collection=url, Url=String.Format("{0}/{1}", url, "FakeProject3")}
            };

            using(var harness = new TeamFoundationServerHarness(url, "FakeProject1", "FakeProject2", "FakeProject3"))
            {
                List<TeamProjectDescriptor> actualProjects = TeamProjectExtractor.Extract(url);
                bool result = Compare(expectedProjects, actualProjects);
                Assert.IsTrue(result);
            }
            
            
        }

        private bool Compare(List<TeamProjectDescriptor> expected, List<TeamProjectDescriptor> actual)
            {
                if(expected.Count != actual.Count)
                    return false;

                foreach(var item in expected)
                {
                    if(!actual.Contains(item))
                        return false;
                }
                return true;
            }
    }
     */
}
