using ReceiptParser.Module.Drawer;
using ReceiptParser.Module.Manager;
using ReceiptParser.Module.Repository;
using System;

namespace ReceiptParser.Consoles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonPath = AppDomain.CurrentDomain.BaseDirectory + "response.json";

            JsonReceiptRepository repository = new JsonReceiptRepository(jsonPath);
            ReceiptManager manager = new ReceiptManager(repository);

            int skip = 1;
            int toleranceY = 10;
            int vertexIndex = 0;


            var receiptsGroups = manager.GetReceiptsGroups(skip, vertexIndex, toleranceY);


            // Drawer
            ReceiptDrawer consoleDrawer = new ConsoleReceiptDrawer();

            string textFilePath = AppDomain.CurrentDomain.BaseDirectory + "receipt.txt";
            ReceiptDrawer textDrawer = new TextReceiptDrawer(textFilePath);

            ReceiptDrawerManager drawManager = new ReceiptDrawerManager(consoleDrawer, textDrawer);
            drawManager.DrawAll(receiptsGroups, vertexIndex);
      

            
            }
        }

}
