using FluentResults;
using MediatR;
using Product.Domain.Contracts.Command;
using Product.Domain.Contracts.Mediator;
using Product.Domain.Contracts.Notification;
using Product.Domain.Contracts.Query;
using Product.Domain.Contracts.Responses;

namespace Product.CrossCutting.handlers;

public class MediatorHandler(IMediator mediator) : IMediatorHandler
{

    #region Events

    public async Task<TD> SendEventStructResponse<T, TD>(T @event) where T : IGenericResponse where TD : struct
    {
        var result = await mediator.Send(@event);
        return (TD)result!;
    }

    public async Task<TD> SendEventObjectResponse<T, TD>(T @event) where T : IGenericResponse where TD : class
    {
        var result = await mediator.Send(@event);
        return (TD)result!;
    }

    public async Task PublishEvent<T>(T @event) where T : IGenericNotification
    {
        await mediator.Publish(@event);
    }

    #endregion

    #region Commands

    public async Task<Result> SendCommand(IGenericCommand @event)
    {
        var result = await mediator.Send(@event);

        return (Result)result;
    }

    public async Task<Result<T>> SendCommandStructResponse<T>(IGenericCommand @event) where T : struct
    {
        var result = await mediator.Send(@event);

        return (Result<T>)result;
    }

    public async Task<Result<T>> SendCommandClassResponse<T>(IGenericCommand @event) where T : class
    {
        var result = await mediator.Send(@event);

        return (Result<T>)result;
    }

    #endregion

    #region Queries

    public async Task<T> SendQuery<T>(IGenericQuery @event) where T : class
    {
        var result = await mediator.Send(@event);

        return (T)result;
    }

    public async Task<T> SendQueryStruct<T>(IGenericQuery @event) where T : struct
    {
        var result = await mediator.Send(@event);

        return (T)result;
    }

    #endregion 
}