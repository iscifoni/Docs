﻿using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace TestingControllersSample.Tests.IntegrationTests
{
    public class SessionControllerTests : IClassFixture<TestFixture<TestingControllersSample.Startup>>
    {
        private readonly HttpClient _client;

        public SessionControllerTests(TestFixture<TestingControllersSample.Startup> fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task IndexReturnsCorrectSessionPage()
        {
            // Arrange & Act
            var response = await _client.GetAsync("/Session/Index/1");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var testSession = Startup.GetTestSession();
            Assert.True(responseString.Contains(testSession.Name));
        }
    }
}