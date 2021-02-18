using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BitrixApi.DTO;
using Newtonsoft.Json;

namespace BitrixApi.REST
{
    public class BitrixRestApi : IBitrixRestApi
    {
        static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private static readonly HttpClient client = new HttpClient();
        private string token;
        private const string baseURL = "https://vodovoz.bitrix24.ru";
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1,1);
        
        /// <param name="token">BitrixAPI токен из конфига</param>
        public BitrixRestApi(string token)
        {
            this.token = token ?? throw new ArgumentNullException(nameof(token));
        }
        
        //crm.deal.get
        public async Task<Deal> GetDealAsync( uint id )
        {
            AddJsonHeader();
            
            string requestUri = $"{baseURL}/rest/2364/{token}/crm.deal.get.json?id={id}";
            var msg = client.GetStringAsync(requestUri);
            await semaphoreSlim.WaitAsync();
            DealRequest request = null;
            try{
                logger.Info("Ждем Deal");
                Thread.Sleep(1000);
                request = JsonConvert.DeserializeObject<DealRequest>(await msg);
                logger.Info("Подождали Deal");
            }
            finally{
                semaphoreSlim.Dispose();
            }
           
            return request.Result;
        }
        
        //crm.contact.get
        public async Task<Contact> GetContact( uint id )
        {
            AddJsonHeader();
            string requestUri = $"{baseURL}/rest/2364/{token}/crm.contact.get.json?id={id}";
            var msg = client.GetStringAsync(requestUri);
            
            ContactRequest request = null;
            try{
                logger.Info("Ждем Contact");
                Thread.Sleep(1000);
                request = JsonConvert.DeserializeObject<ContactRequest>(await msg);
                logger.Info("Подождали Contact");
            }
            finally{
                semaphoreSlim.Dispose();
            }
            
            return request.Result; 
        }
        
        //crm.company.get
        public async Task<Company> GetCompany( uint id )
        {
            AddJsonHeader();
            string requestUri = $"{baseURL}/rest/2364/{token}/crm.company.get.json?id={id}";
            var msg = client.GetStringAsync(requestUri);
            
            CompanyRequest request = null;
            try{
                logger.Info("Ждем Company");

                Thread.Sleep(1000);
                request = JsonConvert.DeserializeObject<CompanyRequest>(await msg);
                logger.Info("Подождали Company");

            }
            finally{
                semaphoreSlim.Dispose();
            }
            
            return request.Result; 
        }

        //crm.product.get
        public async Task<Product> GetProduct( uint id )
        {
            AddJsonHeader();
            string requestUri = $"{baseURL}/rest/2364/{token}/crm.product.get.json?id={id}";
            var msg = client.GetStringAsync(requestUri);
            
            ProductRequest request = null;
            try{
                logger.Info("Ждем Product");

                Thread.Sleep(1000);
                request = JsonConvert.DeserializeObject<ProductRequest>(await msg);
                logger.Info("Ждем Product");

            }
            finally{
                semaphoreSlim.Dispose();
            }
            
            return request.Result; 
        }

        public async Task<IList<ProductFromDeal>> GetProductsForDeal(uint dealId)
        {
            AddJsonHeader();
            string requestUri = $"{baseURL}/rest/2364/{token}/crm.deal.productrows.get.json?id={dealId}";
            var msg = client.GetStringAsync(requestUri);
            
            ProductFromDealRequest request = null;
            try{
                logger.Info("Ждем ProductFromDeal");

                Thread.Sleep(1000);
                request = JsonConvert.DeserializeObject<ProductFromDealRequest>(await msg);
                logger.Info("Ждем ProductFromDeal");

            }
            finally{
                semaphoreSlim.Dispose();
            }
            
            return request.Result; 
        }


        #region CustomFields

        //crm.deal.userfield.list
        public async Task<IList<CustomFieldFromList>> GetAllCustomFieldsFromDeal()
        {
            AddJsonHeader();
            string requestUri = $"{baseURL}/rest/2364/{token}/crm.deal.userfield.list.json";
            
            var msg = client.GetStringAsync(requestUri);
            
            CustomFieldsDealList request = null;
            try{
                Thread.Sleep(1000);
                request = JsonConvert.DeserializeObject<CustomFieldsDealList>(await msg);
            }
            finally{
                semaphoreSlim.Dispose();
            }
            
            return request.Result; 
        }
        
        //crm.deal.userfield.get
        public async Task<CustomField> GetCustomFieldDeal(int id)
        {
            AddJsonHeader();
            string requestUri = $"{baseURL}/rest/2364/{token}/crm.deal.userfield.get.json?id={id}";
            var msg = client.GetStringAsync(requestUri);
            
            CustomFileldDealItem request = null;
            try{
                Thread.Sleep(1000);
                request = JsonConvert.DeserializeObject<CustomFileldDealItem>(await msg);
            }
            finally{
                semaphoreSlim.Dispose();
            }
            
            return request.Result; 
        }

        public async Task<Dictionary<string, CustomField>> GetMapCustomFieldsShitNamesToRus()
        {
            var map = new Dictionary<string, CustomField>();
            var customFieldsList = await GetAllCustomFieldsFromDeal();
            foreach (var customField in customFieldsList.Take(5)) //TODO gavr убрать take 5
            {
                map[customField.ShitName] = await GetCustomFieldDeal(customField.ID);
                Thread.Sleep(1000);
            }
            return map;
        }
        
        public string SerializeCustomFieldsShitToRusNamesToFile(Dictionary<string, CustomField> ShitToRusNames)
        {
            var builder = new StringBuilder();
            foreach (var shitToRusName in ShitToRusNames)
            {
                builder.Append(shitToRusName.Key);
                builder.Append(":");
                builder.Append(shitToRusName.Value.Russian.Name);
                builder.Append('\n');
            }
            builder.Append('\n');
            return builder.ToString();
        }

        public async Task CreateShitToRusCustomFieldsFile(string filename)
        {
            if (!File.Exists(filename))
            {
                var shitNamesToRus = await GetMapCustomFieldsShitNamesToRus();
                var text = SerializeCustomFieldsShitToRusNamesToFile(shitNamesToRus);
                //Добавляем дату в имя файла на случай если файл будет пересоздаваться раз в N дней
                var filenameWithDate = filename + DateTime.Now.ToString("d") + ".txt";
                File.WriteAllText(filenameWithDate, text);
            }
        }

        #endregion CustomFields
        
        private static void AddJsonHeader()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
    }
}