using MediatR;

namespace SirenaTravel.TestTask.Application.Core.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
