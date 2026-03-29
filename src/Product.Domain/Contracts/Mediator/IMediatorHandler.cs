using FluentResults;
using Product.Domain.Contracts.Command;
using Product.Domain.Contracts.Notification;
using Product.Domain.Contracts.Query;
using Product.Domain.Contracts.Responses;

namespace Product.Domain.Contracts.Mediator;

public interface IMediatorHandler
{
    Task<TD> SendEventStructResponse<T, TD>(T @event) where T : IGenericResponse where TD : struct;

    Task<TD> SendEventObjectResponse<T, TD>(T @event) where T : IGenericResponse where TD : class;

    Task PublishEvent<T>(T @event) where T : IGenericNotification;

    Task<Result> SendCommand(IGenericCommand @event);

    Task<Result<T>> SendCommandStructResponse<T>(IGenericCommand @event) where T : struct;

    Task<Result<T>> SendCommandClassResponse<T>(IGenericCommand @event) where T : class;

    Task<T> SendQuery<T>(IGenericQuery @event) where T : class;

    Task<T> SendQueryStruct<T>(IGenericQuery @event) where T : struct;
}