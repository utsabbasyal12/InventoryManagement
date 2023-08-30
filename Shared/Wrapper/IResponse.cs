using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Wrapper
{
    public interface IResponse
    {
        string? Messages { get; set; }
        bool Succeeded { get; set; }
    }
    public interface IResponse<out T> : IResponse
    {
        T Data { get; }
    }
}
