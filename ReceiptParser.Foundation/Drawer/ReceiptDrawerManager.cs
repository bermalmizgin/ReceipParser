using ReceiptParser.Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReceiptParser.Module.Drawer
{
    public class ReceiptDrawerManager
    {
        private readonly ReceiptDrawer[] drawers;

        public ReceiptDrawerManager(params ReceiptDrawer[] drawers)
        {
            this.drawers = drawers;
        }

        public void DrawAll(IEnumerable<IGrouping<int, ReceiptModel>> receiptsGroups, int vertexIndex) {
            foreach (var drawer in drawers)
            {
                drawer.DrawAll(receiptsGroups, vertexIndex);
            }
        }
    }
}
