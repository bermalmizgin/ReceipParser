using ReceiptParser.Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReceiptParser.Module.Drawer
{
    public class ConsoleReceiptDrawer : ReceiptDrawer
    {

        public override void DrawAll(IEnumerable<IGrouping<int, ReceiptModel>> receiptGroups, int vertexIndex)
        {
            foreach (var receiptGroup in receiptGroups)
            {
                Console.WriteLine(string.Join(" ", receiptGroup.OrderBy(a => a.GetVertex(vertexIndex).x).Select(a => a.description)));

            }
        }
    }
}
