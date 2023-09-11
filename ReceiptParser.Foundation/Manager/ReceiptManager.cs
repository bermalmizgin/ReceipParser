using Newtonsoft.Json;
using ReceiptParser.Module.Models;
using ReceiptParser.Module.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace ReceiptParser.Module.Manager
{
    public class ReceiptManager
    {
        private readonly ReceiptRepository repository;

        public ReceiptManager(ReceiptRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<ReceiptModel> GetReceipts(int skip, int vertexIndex, int toleranceY)
        {
            var receipts = repository.GetReceipts().Skip(skip).ToList().OrderBy(a => a.GetVertex(vertexIndex).y);

            FillGroupY(receipts, vertexIndex, toleranceY);

            return receipts;
        }

        public IEnumerable<IGrouping<int, ReceiptModel>> GetReceiptsGroups(int skip, int vertexIndex, int toleranceY)
        {
            var list = GetReceipts(skip, vertexIndex, toleranceY);

            return list.GroupBy(a => a.GetVertex(vertexIndex).groupY);
        }

        private void FillGroupY(IEnumerable<ReceiptModel> receipts, int vertexIndex, int toleranceY)
        {
            // Initialize
            var vertex = receipts.FirstOrDefault().GetVertex(vertexIndex);
            int referenceY = vertex.y;


            foreach (var receipt in receipts)
            {
                vertex = receipt.GetVertex(vertexIndex);  

                int maxY = referenceY + toleranceY;

                if (maxY >= vertex.y) // Y değeri aralığın içinde
                {
                    vertex.groupY = referenceY;
                }
                else
                {
                    referenceY = vertex.y;
                    vertex.groupY = referenceY;
                }
            }
        }
    }
}
