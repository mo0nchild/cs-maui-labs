﻿using MauiLabs.Api.Commons.Mapping;
using MauiLabs.Api.Services.Requests.CookingRecipeRequests.Models;

namespace MauiLabs.Api.Controllers.ApiModels.Commons
{
    /// <summary>
    /// Полные данные о кулинарном рецепте
    /// </summary>
    public partial class CookingRecipeInfoModel : IMappingTarget<CookingRecipeInfo>
    {
        /// <summary>
        /// Идентификатор рецепта
        /// </summary>
        public required int Id { get; set; } = default!;
        
        /// <summary>
        /// Название рецепта
        /// </summary>
        public required string Name { get; set; } = default!;
        
        /// <summary>
        /// Описание рецепта
        /// </summary>
        public string? Description { get; set; } = default!;
        
        /// <summary>
        /// Изображение рецепта
        /// </summary>
        public byte[]? Image { get; set; } = default!;

        /// <summary>
        /// Дата и время публикации записи
        /// </summary>
        public required DateTime PublicationTime { get; set; } = default!;
        
        /// <summary>
        /// Среднее значение рейтинга рецепта
        /// </summary>
        public required double Rating { get; set; } = default!;
        
        /// <summary>
        /// Значение, которое определяет - подтвержден рецепт администратором
        /// </summary>
        public required bool Confirmed { get; set; } = default!;

        /// <summary>
        /// Список необходимых ингредиентов
        /// </summary>
        public required List<IngredientInfoModel> Ingredients { get; set; } = new();
        
        /// <summary>
        /// Информация о пользователе, который опубликовал рецепт
        /// </summary>
        public required PublisherInfoModel Publisher { get; set; } = default!;

        /// <summary>
        /// Индентификатор опубликававшего пользователя
        /// </summary>
        public required int PublisherId { get; set; } = default!;
    }
}
