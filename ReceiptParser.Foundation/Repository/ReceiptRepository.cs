using ReceiptParser.Module.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReceiptParser.Module.Repository
{
    public abstract class ReceiptRepository
    {
        public abstract List<ReceiptModel> GetReceipts();
    }
}
