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

namespace SpartaTodo.Tests
{
    internal class TodoItemsControllerShould
    {
        [Test]
        public void Index_WithSuccessfulServiceResponse_ReturnsTodoVMList()
        {
            var mockService = Mock.Of<IToDoService>();
            var mockHttpContext = Mock.Of<HttpContext>();
            var mockUserManager = Mock.Of<UserManager<Spartan>>();
            var phil = new Spartan()
            {
                UserName = "phil@spartaglobal.com",
                Email = "phil@spartaglobal.com",
                EmailConfirmed = true
            };
            Mock
                .Get(mockService)
                .Setup(s => s.GetTodoItemsAsync(It.IsAny<Spartan>() , "Trainee" ,It.IsAny<string>()).Result)
                .Returns(GetTodoListServiceResponse());

            Mock
                .Get(mockHttpContext)
                .Setup(hc => hc.User)
                .Returns(It.IsAny<ClaimsPrincipal>());

            Mock
                .Get(mockUserManager)
                .Setup(us => us.GetUserAsync(mockHttpContext.User).Result)
                .Returns(phil);

            var sut = new ToDoItemsController(mockService, mockUserManager);

            var result = sut.Index(null).Result;
            Assert.That(result, Is.InstanceOf<ViewResult>());

            var viewResult = result as ViewResult;
            var data = viewResult!.Model;
            Assert.That(data, Is.InstanceOf<IEnumerable<ToDoVM>>());
        }

        [Test]
        public void Index_WhenNotSuccessfulServiceResponse_ReturnsProblem()
        {
            var mockService = Mock.Of<IToDoService>();
            var response = GetFailedServiceResponse<IEnumerable<ToDoVM>>("Fake problem message");

            Mock
                .Get(mockService)
                .Setup(s => s.GetTodoItemsAsync(It.IsAny<Spartan>(), "Trainee", It.IsAny<string>()).Result)
                .Returns(response);
            var sut = new ToDoItemsController(mockService, It.IsAny<UserManager<Spartan>>());

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
    }
}
