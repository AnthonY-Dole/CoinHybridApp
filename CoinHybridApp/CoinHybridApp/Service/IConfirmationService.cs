using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoinHybridApp.Service
{
    public interface IConfirmationService
    {
        Task<bool> AskConfirmation(string message);
    }
}
