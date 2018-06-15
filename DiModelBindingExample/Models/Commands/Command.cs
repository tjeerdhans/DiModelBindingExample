using System.Threading.Tasks;
using DiModelBindingExample.Infrastructure;

namespace DiModelBindingExample.Models.Commands
{
    /// <summary>
    /// A command request.
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class Command<TResponse>
    {
        protected readonly IRepository Repository;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        protected Command(IRepository repository)
        {
            Repository = repository;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <returns></returns>
        public abstract Task<TResponse> Execute();
    }
}