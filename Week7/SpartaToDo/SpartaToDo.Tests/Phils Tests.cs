using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NuGet.Protocol;
using SpartaToDo.App.Controllers;
using SpartaToDo.App.Models;
using SpartaToDo.App.Service;
using System.Security.Claims;
using System.Security.Principal;

namespace SpartaToDo.Tests
{
    internal class Phils_Tests
    {
        [Test]
        public void Index_WhenSuccessfulServiceResponse_ReturnsTodoItems()
        {
            var mockService = Mock.Of<IToDoService>();
            Mock
            .Get(mockService)
            .Setup(s => s.GetTodoItemsAsync(
            It.IsAny<Spartan>(),
            It.IsAny<string>(),
            It.IsAny<string>()).Result)
            .Returns(GetTodoListServiceResponse());

            var sut = GetBasicSut(mockService);

            var result = sut.Index(null).Result;
            Assert.That(result, Is.InstanceOf<ViewResult>());

            var viewResult = result as ViewResult;
            var data = viewResult.Model;
            Assert.That(data, Is.InstanceOf<IEnumerable<ToDoVM>>());
        }

        [Test]
        public void Index_WhenNotSuccessfulServiceResponse_ReturnsProblem()
        {
            var mockService = Mock.Of<IToDoService>();
            var response = GetFailedServiceResponse<IEnumerable<ToDoVM>>("Fake problem message");
            Mock
            .Get(mockService)
            .Setup(s => s.GetTodoItemsAsync(
            It.IsAny<Spartan>(),
            It.IsAny<string>(),
            It.IsAny<string>()).Result)
            .Returns(response);
            var sut = GetBasicSut(mockService);

            var result = sut.Index(null).Result;
            Assert.That(result, Is.InstanceOf<ObjectResult>());

            var objectResult = result as ObjectResult;
            var jsonString = result.ToJson();

            Assert.That(jsonString, Does.Contain("Fake problem"));
        }

        private ServiceResponce<T> GetFailedServiceResponse<T>(string message = "")
        {
            var response = new ServiceResponce<T>();
            response.Success = false;
            response.Message = message;
            return response;
        }

        private ServiceResponce<IEnumerable<ToDoVM>> GetTodoListServiceResponse()
        {
            var response = new ServiceResponce<IEnumerable<ToDoVM>>();
            response.Data = new List<ToDoVM>
            {
                Mock.Of<ToDoVM>(),
                Mock.Of<ToDoVM>()
            };
            return response;
        }

        private ToDoItemsController GetBasicSut(IToDoService mockService)
        {
            var mockUserManager = GetMockUserManager();
            var sut = new ToDoItemsController(mockService, mockUserManager);
            sut.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockHttpContext(GetMockClaimsPrincipal())
            };
            return sut;
        }

        private UserManager<Spartan> GetMockUserManager()
        {
            return new Mock<UserManager<Spartan>>(
            Mock.Of<IUserStore<Spartan>>(),
            null, null, null, null, null, null, null, null
            ).Object;
        }
        private ClaimsPrincipal GetMockClaimsPrincipal(string role = "Trainee", bool isInRole = false)
        {
            var identity = new GenericIdentity("FakeUserName", "");

            var mockPrincipal = Mock.Of<ClaimsPrincipal>();
            Mock
                .Get(mockPrincipal)
                .Setup(x => x.Identity)
                .Returns(identity);
            Mock
                .Get(mockPrincipal)
                .Setup(x => x.IsInRole(role))
                .Returns(isInRole);

            return mockPrincipal;
        }
        private HttpContext GetMockHttpContext(ClaimsPrincipal mockPrincipal)
        {
            var mockHttpContext = Mock.Of<HttpContext>();
            Mock
            .Get(mockHttpContext)
            .Setup(m => m.User)
            .Returns(mockPrincipal);
            return mockHttpContext;
        }
    }
}
