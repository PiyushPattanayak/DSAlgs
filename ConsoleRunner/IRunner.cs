using System;
using System.Threading.Tasks;

namespace ConsoleRunner
{
    public interface IRunner
    {
        bool IsExitRequested { get; set; }
        void Run();
    }
}
