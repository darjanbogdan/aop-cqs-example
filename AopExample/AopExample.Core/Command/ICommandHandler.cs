using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopExample.Core.Command
{
    public interface ICommandHandler<TCommand>
    {
        Task ExecuteAsync(TCommand command);
    }
}