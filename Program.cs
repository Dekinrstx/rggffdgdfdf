using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MihaZupan;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;


namespace TelegramBot
{
    public static class Program
    {
       
        private static readonly HttpClient client = new HttpClient();
        private static readonly string[] proxies = new string[] {
    "77.83.1.2:5843:uk3030211:v1jcGcxvIR",
"77.83.1.3:5843:uk3030211:v1jcGcxvIR",
"77.83.1.5:5843:uk3030211:v1jcGcxvIR",
"77.83.1.8:5843:uk3030211:v1jcGcxvIR",
"77.83.1.10:5843:uk3030211:v1jcGcxvIR",
"77.83.1.12:5843:uk3030211:v1jcGcxvIR",
"77.83.1.14:5843:uk3030211:v1jcGcxvIR",
"77.83.1.17:5843:uk3030211:v1jcGcxvIR",
"77.83.1.19:5843:uk3030211:v1jcGcxvIR",
"77.83.1.21:5843:uk3030211:v1jcGcxvIR",
"77.83.1.22:5843:uk3030211:v1jcGcxvIR",
"77.83.1.34:5843:uk3030211:v1jcGcxvIR",
"77.83.1.35:5843:uk3030211:v1jcGcxvIR",
"77.83.1.37:5843:uk3030211:v1jcGcxvIR",
"77.83.1.39:5843:uk3030211:v1jcGcxvIR",
"77.83.1.41:5843:uk3030211:v1jcGcxvIR",
"77.83.1.43:5843:uk3030211:v1jcGcxvIR",
"77.83.1.44:5843:uk3030211:v1jcGcxvIR",
"77.83.1.46:5843:uk3030211:v1jcGcxvIR",
"77.83.1.49:5843:uk3030211:v1jcGcxvIR",
"77.83.1.52:5843:uk3030211:v1jcGcxvIR",
"77.83.1.54:5843:uk3030211:v1jcGcxvIR",
"77.83.1.56:5843:uk3030211:v1jcGcxvIR",
"77.83.1.57:5843:uk3030211:v1jcGcxvIR",
"77.83.1.60:5843:uk3030211:v1jcGcxvIR",
"77.83.1.66:5843:uk3030211:v1jcGcxvIR",
"77.83.1.68:5843:uk3030211:v1jcGcxvIR",
"77.83.1.69:5843:uk3030211:v1jcGcxvIR",
"77.83.1.71:5843:uk3030211:v1jcGcxvIR",
"77.83.1.74:5843:uk3030211:v1jcGcxvIR",
"77.83.1.76:5843:uk3030211:v1jcGcxvIR",
"77.83.1.80:5843:uk3030211:v1jcGcxvIR",
"77.83.1.82:5843:uk3030211:v1jcGcxvIR",
"77.83.1.93:5843:uk3030211:v1jcGcxvIR",
"77.83.1.94:5843:uk3030211:v1jcGcxvIR",
"77.83.1.97:5843:uk3030211:v1jcGcxvIR",
"77.83.1.100:5843:uk3030211:v1jcGcxvIR",
"77.83.1.103:5843:uk3030211:v1jcGcxvIR",
"77.83.1.106:5843:uk3030211:v1jcGcxvIR",
"77.83.1.108:5843:uk3030211:v1jcGcxvIR",
"77.83.1.110:5843:uk3030211:v1jcGcxvIR",
"77.83.1.120:5843:uk3030211:v1jcGcxvIR",
"77.83.1.125:5843:uk3030211:v1jcGcxvIR",
"77.83.1.129:5843:uk3030211:v1jcGcxvIR",
"77.83.1.134:5843:uk3030211:v1jcGcxvIR",
"77.83.1.136:5843:uk3030211:v1jcGcxvIR",
"77.83.1.138:5843:uk3030211:v1jcGcxvIR",
"77.83.1.140:5843:uk3030211:v1jcGcxvIR",
"77.83.1.145:5843:uk3030211:v1jcGcxvIR",
"77.83.1.147:5843:uk3030211:v1jcGcxvIR",
"77.83.1.149:5843:uk3030211:v1jcGcxvIR",
"77.83.1.151:5843:uk3030211:v1jcGcxvIR",
"77.83.1.152:5843:uk3030211:v1jcGcxvIR",
"77.83.1.156:5843:uk3030211:v1jcGcxvIR",
"77.83.1.159:5843:uk3030211:v1jcGcxvIR",
"77.83.1.165:5843:uk3030211:v1jcGcxvIR",
"77.83.1.166:5843:uk3030211:v1jcGcxvIR",
"77.83.1.169:5843:uk3030211:v1jcGcxvIR",
"77.83.1.171:5843:uk3030211:v1jcGcxvIR",
"77.83.1.176:5843:uk3030211:v1jcGcxvIR",
"77.83.1.178:5843:uk3030211:v1jcGcxvIR",
"77.83.1.181:5843:uk3030211:v1jcGcxvIR",
"77.83.1.184:5843:uk3030211:v1jcGcxvIR",
"77.83.1.187:5843:uk3030211:v1jcGcxvIR",
"77.83.1.188:5843:uk3030211:v1jcGcxvIR",
"77.83.1.190:5843:uk3030211:v1jcGcxvIR",
"77.83.1.196:5843:uk3030211:v1jcGcxvIR",
"77.83.1.198:5843:uk3030211:v1jcGcxvIR",
"77.83.1.200:5843:uk3030211:v1jcGcxvIR",
"77.83.1.202:5843:uk3030211:v1jcGcxvIR",
"77.83.1.204:5843:uk3030211:v1jcGcxvIR",
"77.83.1.207:5843:uk3030211:v1jcGcxvIR",
"77.83.1.209:5843:uk3030211:v1jcGcxvIR",
"77.83.1.211:5843:uk3030211:v1jcGcxvIR",
"77.83.1.213:5843:uk3030211:v1jcGcxvIR",
"77.83.1.215:5843:uk3030211:v1jcGcxvIR",
"77.83.1.216:5843:uk3030211:v1jcGcxvIR",
"77.83.1.217:5843:uk3030211:v1jcGcxvIR",
"77.83.1.219:5843:uk3030211:v1jcGcxvIR",
"77.83.1.221:5843:uk3030211:v1jcGcxvIR",
"77.83.1.222:5843:uk3030211:v1jcGcxvIR",
"77.83.1.224:5843:uk3030211:v1jcGcxvIR",
"77.83.1.225:5843:uk3030211:v1jcGcxvIR",
"77.83.1.227:5843:uk3030211:v1jcGcxvIR",
"77.83.1.228:5843:uk3030211:v1jcGcxvIR",
"77.83.1.230:5843:uk3030211:v1jcGcxvIR",
"77.83.1.232:5843:uk3030211:v1jcGcxvIR",
"77.83.1.234:5843:uk3030211:v1jcGcxvIR",
"77.83.1.235:5843:uk3030211:v1jcGcxvIR",
"77.83.1.237:5843:uk3030211:v1jcGcxvIR",
"77.83.1.239:5843:uk3030211:v1jcGcxvIR",
"77.83.1.241:5843:uk3030211:v1jcGcxvIR",
"77.83.1.242:5843:uk3030211:v1jcGcxvIR",
"77.83.1.244:5843:uk3030211:v1jcGcxvIR",
"77.83.1.245:5843:uk3030211:v1jcGcxvIR",
"77.83.1.246:5843:uk3030211:v1jcGcxvIR",
"77.83.1.248:5843:uk3030211:v1jcGcxvIR",
"77.83.1.249:5843:uk3030211:v1jcGcxvIR",
"77.83.1.251:5843:uk3030211:v1jcGcxvIR",
"77.83.1.253:5843:uk3030211:v1jcGcxvIR",

};
        private static int proxyIndex = 0;
        private static readonly string token = "6200286187:AAHAxCKHw4w1TyGJWiLNhxUbPW_JZCiEEkc";
        private static readonly TelegramBotClient bot = new TelegramBotClient(token);

        public static async Task Main()
        {
            bot.OnMessage += Bot_OnMessage;
            bot.StartReceiving();

            Console.WriteLine("хуй пизда залупа");
            Console.ReadKey();

            bot.StopReceiving();
        }

        private static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var message = e.Message;

            if (message.Type == MessageType.Text)
            {
                switch (message.Text)
                {
                    case "/start":
                        await ShowMainMenu(message);
                        break;
                    case "FAQ":
                        await ShowFaq(message);
                        break;
                    case "О боте":
                        await ShowAbout(message);
                        break;
                    case "Проверка криптокошельков":
                        await CheckWallets(message);
                        break;
                }
            }
            else if (message.Type == MessageType.Document)
            {
                await ProcessWalletsFile(message);
            }
        }

        private static async Task ShowMainMenu(Message message)
        {
            var keyboard = new ReplyKeyboardMarkup(new[]
            {
        new KeyboardButton("FAQ"),
        new KeyboardButton("О боте"),
        new KeyboardButton("Проверка криптокошельков")
    }, resizeKeyboard: true);

            await bot.SendTextMessageAsync(message.Chat.Id, "Выберите действие:", replyMarkup: keyboard);
        }

        private static async Task ShowFaq(Message message)
        {
            await bot.SendTextMessageAsync(message.Chat.Id, "Контакты поддержки: @user");
        }

        private static async Task ShowAbout(Message message)
        {
            await bot.SendTextMessageAsync(message.Chat.Id, "Этот бот позволяет проверять балансы криптокошельков с помощью API Zerion.");
        }

        private static async Task CheckWallets(Message message)
        {

            await bot.SendTextMessageAsync(message.Chat.Id, "Пожалуйста, отправьте файл с криптокошельками (максимум 20 МБ).");
        }

        private static async Task ProcessWalletsFile(Message message)
        {
            var file = await bot.GetFileAsync(message.Document.FileId);
            using var stream = new MemoryStream();
            await bot.DownloadFileAsync(file.FilePath, stream);
            stream.Position = 0;

            using var reader = new StreamReader(stream);
            var content = await reader.ReadToEndAsync();
            var wallets = content.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var wallet in wallets)
            {
                var result = await CheckWalletBalance(wallet);
                await bot.SendTextMessageAsync(message.Chat.Id, result, ParseMode.Markdown);
            }
        }
        private static Queue<(string fileId, long chatId)> fileQueue = new Queue<(string fileId, long chatId)>();

      

        private static async Task<string> CheckWalletBalance(string wallet)
        {
            try
            {
                
                string proxyString = proxies[proxyIndex];
                string[] proxyParts = proxyString.Split(':');
                var proxy = new HttpToSocks5Proxy(proxyParts[0], int.Parse(proxyParts[1]), proxyParts[2], proxyParts[3]);
                proxy.Credentials = new NetworkCredential(proxyParts[2], proxyParts[3]);
                var handler = new HttpClientHandler();
                handler.Proxy = proxy;
                var client = new HttpClient(handler);
                proxyIndex = (proxyIndex + 1) % proxies.Length;
                
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "emtfZGV2XzkxMDc3NjM4YTFiYjRkYmRhYmNhZGM4ZDExN2EwNjM0Og==");
                var portfolioUrl = $"https://api.zerion.io/v1/wallets/{wallet}/portfolio?currency=usd";
                Console.WriteLine($"запрос {portfolioUrl}");

                try
                {
                    var portfolioResponse = await client.GetAsync(portfolioUrl);
                    portfolioResponse.EnsureSuccessStatusCode();
                    var portfolioJson = await portfolioResponse.Content.ReadAsStringAsync();
                    var portfolioData = JsonConvert.DeserializeObject<ZerionResponse>(portfolioJson);
                    var totalBalance = portfolioData.Data.Attributes.Total.Positions;
                    var result = $"*Wallet:* {wallet}\n*Total balance:* {totalBalance:0.00} USD\n\n*Coins:*";

                    foreach (var coin in portfolioData.Data.Attributes.PositionsDistributionByChain)
                    {
                        if (coin.Value > 0)
                        {
                            result += $"\n- {coin.Key}: {coin.Value:0.00} USD";
                        }
                    }
                    
                    var nftUrl = $"https://api.zerion.io/v1/wallets/{wallet}/nft-positions/?currency=usd&page[size]=100";
                    Console.WriteLine($" {nftUrl}");
                    var nftResponse = await client.GetAsync(nftUrl);
                    nftResponse.EnsureSuccessStatusCode();
                    var nftJson = await nftResponse.Content.ReadAsStringAsync();
                    var nftData = JsonConvert.DeserializeObject<ZerionNftResponse>(nftJson);
                    result += "\n\n*NFTs:*";

                    foreach (var nft in nftData.Data)
                    {
                        result += $"\n- {nft.Attributes.Name}: {nft.Attributes.Value:0.00} USD";
                    }

                    return result;
                }
                catch (HttpRequestException e)
                {
                    
                    return $"Ошибка при отправке запроса: {e.Message}";
                }
            }
            catch (Exception e)
            {
                
                return $"Произошла ошибка: {e.Message}";
            }
        }

        public class ZerionResponse
        {
            [JsonProperty("links")]
            public Links Links { get; set; }

            [JsonProperty("data")]
            public Data Data { get; set; }
        }

        public class Links
        {
            [JsonProperty("self")]
            public string Self { get; set; }
        }

        public class Data
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("attributes")]
            public Attributes Attributes { get; set; }
        }

        public class Attributes
        {
            [JsonProperty("positions_distribution_by_type")]
            public Dictionary<string, double> PositionsDistributionByType { get; set; }

            [JsonProperty("positions_distribution_by_chain")]
            public Dictionary<string, double> PositionsDistributionByChain { get; set; }

            [JsonProperty("total")]
            public Total Total { get; set; }

            [JsonProperty("changes")]
            public Changes Changes { get; set; }
        }

        public class Total
        {
            [JsonProperty("positions")]
            public double Positions { get; set; }
        }

        public class Changes
        {
            [JsonProperty("absolute_1d")]
            public double? Absolute1d { get; set; }

            [JsonProperty("percent_1d")]
            public double? Percent1d { get; set; }
        }
        public class ZerionNftResponse
        {
            [JsonProperty("data")]
            public NftData[] Data { get; set; }
        }

        public class NftData
        {
            [JsonProperty("attributes")]
            public NftAttributes Attributes { get; set; }
        }

        public class NftAttributes
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("value")]
            public double Value { get; set; }
        }
    }
}
