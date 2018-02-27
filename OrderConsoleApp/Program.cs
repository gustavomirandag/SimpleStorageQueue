using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure; // CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; //CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Queue; //CloudStorageQueue

namespace OrderConsoleApp
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

            //Obtem a string que será adicionada a fila
            Console.WriteLine("Digite o que quer adicionar na fila");
            string strMessage = Console.ReadLine();
        }
    }
}
