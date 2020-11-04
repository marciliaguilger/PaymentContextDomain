using PaymentContext.Shared.Commands;

namespace PaymentContext.Shared.Handlers
{
    //só posso manipular objetos do tipo ICommand
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}