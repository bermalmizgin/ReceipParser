using ReceiptParser.Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReceiptParser.Module.Drawer
{
    public abstract class ReceiptDrawer
    {
        public abstract void DrawAll(IEnumerable<IGrouping<int, ReceiptModel>> receiptGroups, int vertexIndex);
    }
}
