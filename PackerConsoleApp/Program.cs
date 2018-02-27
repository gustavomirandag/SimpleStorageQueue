using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure; // CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; //CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Queue; //CloudStorageQueue

namespace PackerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //StorageAccount do Azure
            var cloudStorageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            //CloudQueueClient
            CloudQueueClient cloudQueueClient = cloudStorageAccount.CreateCloudQueueClient();

            //CloudQueue vai fazer referência a uma fila específic
            CloudQueue cloudQueue = cloudQueueClient.GetQueueReference("amazingqueue");

            //Pega a mensagem na frente da fila
            CloudQueueMessage message = cloudQueue.GetMessage();
            if (message != null)
            {
                Console.WriteLine(message.AsString);
                cloudQueue.DeleteMessage(message);
            }

            //Apenas para não fechar a janela CMD
            Console.ReadLine();
        }
    }
}
