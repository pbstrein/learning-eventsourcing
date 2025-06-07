namespace Shopping.Cart.Slices.AddItem;

using Shopping.Cart.Common;
using Shopping.Cart.Domain;
using System;

public record AddItemCommand(
    Guid AggregateId,
    string Description,
    string Image,
    double Price,
    Guid ItemId,
    Guid ProductId
) : ICommand
{
}