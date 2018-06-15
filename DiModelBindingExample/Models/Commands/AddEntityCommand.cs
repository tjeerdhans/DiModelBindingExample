using System.Threading.Tasks;
using DiModelBindingExample.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DiModelBindingExample.Models.Commands
{
    public class AddEntityCommand : Command<bool>
    {
        [BindRequired]
        public SomeEntity Value { get; set; }

        public AddEntityCommand(IRepository repository) : base(repository)
        {
        }

        public override Task<bool> Execute()
        {
            return Task.FromResult(true);
        }
    }
}
