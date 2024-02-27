using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ZumRailsAPI.Controllers;
using ZumRailsAPI.Interfaces;
using ZumRailsAPI.Models;

namespace ZumRailsTests;

public class PostsControllerUnitTests
{
    
        [Fact]
        public async Task GetMembersAsync_ReturnsSuccess()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<PostsController>>();
            var zumRailsServiceMock = new Mock<IZumRailsService>();
            var controller = new PostsController(loggerMock.Object, zumRailsServiceMock.Object);

            var tags = "science";
            var expectedPosts = new List<Post>
        {
            new Post
            {
                Id = 1,
                Author = "Rylee Paul",
                AuthorId = 9,
                Likes = 960,
                Popularity = 0.13,
                Reads = 50361,
                Tags = new List<string> { "tech", "health" }
            }
        };

            zumRailsServiceMock.Setup(x => x.GetPosts(tags, string.Empty, string.Empty)).ReturnsAsync(expectedPosts);

            // Act
            var result = await controller.GetMembersAsync(tags, string.Empty, string.Empty) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal(expectedPosts, result.Value);
        }

        [Fact]
        public async Task GetMembersAsync_ReturnsBadRequest()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<PostsController>>();
            var zumRailsServiceMock = new Mock<IZumRailsService>();
            var controller = new PostsController(loggerMock.Object, zumRailsServiceMock.Object);

            var tags = "science";
            var sortBy = "bid";
            var direction = "adsc";

            zumRailsServiceMock.Setup(x => x.GetPosts(tags, sortBy, direction)).ThrowsAsync(new Exception("An error occurred"));

            // Act
            var result = await controller.GetMembersAsync(tags, sortBy, direction) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.Equal("An error occurred", result.Value);
        }
    }