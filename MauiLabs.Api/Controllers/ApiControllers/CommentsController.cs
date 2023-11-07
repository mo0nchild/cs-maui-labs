﻿using AutoMapper;
using MauiLabs.Api.Controllers.ApiModels.Bookmarks.Requests;
using MauiLabs.Api.Controllers.ApiModels.Comments.Requests;
using MauiLabs.Api.Controllers.ApiModels.Comments.Responses;
using MauiLabs.Api.Services.Commands.BookmarkCommands.AddBookmark;
using MauiLabs.Api.Services.Commands.CommentCommands.AddComment;
using MauiLabs.Api.Services.Commands.CommentCommands.DeleteComment;
using MauiLabs.Api.Services.Commands.CommentCommands.EditComment;
using MauiLabs.Api.Services.Requests.CommentRequests.GetComment;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace MauiLabs.Api.Controllers.ApiControllers
{
    [Route("cookingrecipes/comments"), ApiController]
    public partial class CommentsController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        protected internal readonly IMediator mediator = mediator;
        protected internal readonly IMapper mapper = mapper;
        public int ProfileId { get => int.Parse(this.User.FindFirstValue(ClaimTypes.PrimarySid)!); }

        /// <summary>
        /// [User] Добавление комментария к записи о рецепте
        /// </summary>
        /// <param name="request">Данные комментария</param>
        /// <returns>Статус добавления комментария</returns>
        /// <role>Admin</role>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "User")]
        [Route("add"), HttpPost]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(OkObjectResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddCommentHandler([FromBody] AddCommentRequestModel request)
        {
            try { await this.mediator.Send(this.mapper.Map<AddCommentCommand>(request)); }
            catch (Exception errorInfo)
            {
                return this.Problem(errorInfo.Message, statusCode: (int)StatusCodes.Status400BadRequest);
            }
            return this.Ok("Комментарий успешно добавлен");
        }
        /// <summary>
        /// [Admin] Удаление комментария к записи о рецепте
        /// </summary>
        /// <param name="request">Идентификатор комментария</param>
        /// <returns>Статус удаления комментария</returns>
        /// <role>Admin</role>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
        [Route("delete"), HttpDelete]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(OkObjectResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCommentHandler([FromBody] DeleteCommentRequestModel request)
        {
            try { await this.mediator.Send(this.mapper.Map<DeleteCommentCommand>(request)); }
            catch (Exception errorInfo)
            {
                return this.Problem(errorInfo.Message, statusCode: (int)StatusCodes.Status400BadRequest);
            }
            return this.Ok("Комментарий успешно удален");
        }
        /// <summary>
        /// [User] Удаление комментария пользователя к записи о рецепте 
        /// </summary>
        /// <param name="request">Идентификатор комментария</param>
        /// <returns>Статус удаления комментария</returns>
        /// <role>User</role>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "User")]
        [Route("deletebytoken"), HttpDelete]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(OkObjectResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCommentByTokenHandler([FromBody] DeleteCommentByTokenRequestModel request)
        {
            try { await this.mediator.Send(new DeleteCommentCommand() { ProfileId = this.ProfileId, RecipeId = request.RecipeId }); }
            catch (Exception errorInfo)
            {
                return this.Problem(errorInfo.Message, statusCode: (int)StatusCodes.Status400BadRequest);
            }
            return this.Ok("Комментарий успешно удален");
        }
        /// <summary>
        /// [Admin] Изменение комментария к записи о рецепте
        /// </summary>
        /// <param name="request">Данные для изменения комментария</param>
        /// <returns>Статус изменения комментария</returns>
        /// <role>Admin</role>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
        [Route("edit"), HttpPut]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(OkObjectResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> EditCommentHandler([FromBody] EditCommentRequestModel request)
        {
            try { await this.mediator.Send(this.mapper.Map<EditCommentCommand>(request)); }
            catch (Exception errorInfo)
            {
                return this.Problem(errorInfo.Message, statusCode: (int)StatusCodes.Status400BadRequest);
            }
            return this.Ok("Комментарий успешно изменен");
        }
        /// <summary>
        /// [User] Изменение комментария пользователя к записи о рецепте 
        /// </summary>
        /// <param name="request">Данные для изменения комментария</param>
        /// <returns>Статус изменения комментария</returns>
        /// <role>User</role>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "User")]
        [Route("editbytoken"), HttpPut]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(OkObjectResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> EditCommentByTokenHandler([FromBody] EditCommentByTokenRequestModel request)
        {
            var mappedResult = this.mapper.Map<EditCommentCommand>(request);
            mappedResult.ProfileId = this.ProfileId;

            try { await this.mediator.Send(mappedResult); }
            catch (Exception errorInfo)
            {
                return this.Problem(errorInfo.Message, statusCode: (int)StatusCodes.Status400BadRequest);
            }
            return this.Ok("Комментарий успешно удален");
        }
        /// <summary>
        /// Получение информации о комментарии
        /// </summary>
        /// <param name="request">Данные для получения информации о комментарии</param>
        /// <returns>Информация о комментарии</returns>
        /// <role>User</role>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "User")]
        [Route("get"), HttpGet]
        [ProducesResponseType(typeof(GetCommentResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCommentHandler([FromQuery] GetCommentRequestModel request)
        {
            var mappedRequest = this.mapper.Map<GetCommentRequest>(request);
            try { return this.Ok(this.mapper.Map<GetCommentResponseModel>(await this.mediator.Send(mappedRequest))); }
            catch (Exception errorInfo) 
            {
                return this.Problem(errorInfo.Message, statusCode: (int)StatusCodes.Status400BadRequest);
            }
        }
        /// <summary>
        /// Получение информации о комментарии при помощи токена
        /// </summary>
        /// <param name="request">Данные для получения информации о комментарии</param>
        /// <returns>Информация о комментарии</returns>
        /// <role>User</role>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "User")]
        [Route("getbytoken"), HttpGet]
        [ProducesResponseType(typeof(GetCommentResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCommentByTokenHandler([FromQuery] GetCommentByTokenRequestModel request)
        {
            var mappedRequest = this.mapper.Map<GetCommentRequest>(request);
            mappedRequest.ProfileId = this.ProfileId;

            try { return this.Ok(this.mapper.Map<GetCommentResponseModel>(await this.mediator.Send(mappedRequest))); }
            catch (Exception errorInfo)
            {
                return this.Problem(errorInfo.Message, statusCode: (int)StatusCodes.Status400BadRequest);
            }
        }
        /// <summary>
        /// Получение списка комментарий пользователя
        /// </summary>
        /// <param name="request">Данные для получения списка комментарий пользователя</param>
        /// <returns>Список комментарий</returns>
        /// <role>User</role>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "User")]
        [Route("getlist/byprofile"), HttpGet]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(OkObjectResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProfileCommentsHandler([FromQuery] GetCommentByTokenRequestModel request)
        {
            var mappedRequest = this.mapper.Map<GetCommentRequest>(request);
            mappedRequest.ProfileId = this.ProfileId;

            try { return this.Ok(await this.mediator.Send(mappedRequest)); }
            catch (Exception errorInfo)
            {
                return this.Problem(errorInfo.Message, statusCode: (int)StatusCodes.Status400BadRequest);
            }
        }
    }
}
