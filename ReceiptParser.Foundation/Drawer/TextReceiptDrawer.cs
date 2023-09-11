using ReceiptParser.Module.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ReceiptParser.Module.Drawer
{
    public class TextReceiptDrawer : ReceiptDrawer
    {
        private readonly string textFilePath;

        public TextReceiptDrawer(string textFilePath)
        {
            this.textFilePath = textFilePath;
        }

        public override void DrawAll(IEnumerable<IGrouping<int, ReceiptModel>> receiptGroups, int vertexIndex)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var receiptGroup in receiptGroups)
            {
                builder.AppendLine(string.Join(" ", receiptGroup.OrderBy(a => a.GetVertex(vertexIndex).x).Select(a => a.description)));
            }
            File.WriteAllText(textFilePath, builder.ToString());
        }
    }
}
