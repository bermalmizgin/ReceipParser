using Newtonsoft.Json;
using ReceiptParser.Module.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ReceiptParser.Module.Repository
{
    public class JsonReceiptRepository : ReceiptRepository
    {
        private readonly string jsonFile;

        public JsonReceiptRepository(string jsonFile)
        {
            this.jsonFile = jsonFile;
        }

        public override List<ReceiptModel> GetReceipts()
        {
            var response = File.ReadAllText(jsonFile);

            var receipts = JsonConvert.DeserializeObject<List<ReceiptModel>>(response);
            return receipts;
        }
    }
}
