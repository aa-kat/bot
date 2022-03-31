using System;
using System.IO;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;


namespace TwitchChatBot
{
    
        public class Bot
        {
        TwitchClient client = new TwitchClient();
        ConnectionCredentials credentials = new ConnectionCredentials("kat_bot_kat", "oauth:e47yy90xhk52t0c616nbywaz88hk7j");
        int cheese = 0;
        int you = 0;

        public Bot()
        {

            client.Initialize(credentials, "vadihs");

            client.OnLog += Client_OnLog;
            client.OnJoinedChannel += Client_OnJoinedChannel;
            client.OnChatCommandReceived += Client_OnChatCommandReceived;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.Connect();
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            Random rnd = new Random();
            var result = rnd.Next(0, 4);
            if (e.ChatMessage.Message.ToLower().Contains("чел ты")) {
                client.SendMessage(e.ChatMessage.Channel, $"Нет, чел ты, {e.ChatMessage.DisplayName}!!!");
            }
            if (e.ChatMessage.Message.ToLower().Contains("нет ты")) {
                client.SendMessage(e.ChatMessage.Channel, "ТЫ!!!");
            }
            if (result > 0) 
                {
                if (e.ChatMessage.Message.ToLower().Contains("номи")) {
                    client.SendMessage(e.ChatMessage.Channel, $"Номи: гроза кухни лучшая карта в HS BattleGrounds!!! Понял, {e.ChatMessage.DisplayName}?"); }
            }
            else {
                if (e.ChatMessage.Message.ToLower().Contains("номи")) {
                    client.SendMessage(e.ChatMessage.Channel, $"Номи: гроза кухни худшая карта в HS BattleGrounds!!! Понял, {e.ChatMessage.DisplayName}?") ;
                }
            }
            if (e.ChatMessage.Message.Contains("StinkyCheese")) {
                client.SendMessage(e.ChatMessage.Channel, "Вкусный сыр, мням-мням, стример любит сыр StinkyCheese");
            }
        }
        private void Client_OnNewяSubscriber(object sender, OnNewSubscriberArgs e)
        {
            if (e.Subscriber.SubscriptionPlan == SubscriptionPlan.Prime)
                client.SendMessage(e.Channel, $"КуПриветЗдарова {e.Subscriber.DisplayName}, новый подписчик с праймом!");
            else
                client.SendMessage(e.Channel, $"КуПриветЗдарова {e.Subscriber.DisplayName}, новый подписчик!");
        }

        private void Client_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {
            switch (e.Command.CommandText.ToLower()) {
                case "кубик":
                    Random rnd = new Random(); // Инициализируем генератор случайных чисел
                    var result = rnd.Next(1, 7); // Получаем случайное целое число в интервале [ 1; 7 )
                    client.SendMessage(e.Command.ChatMessage.Channel, $"Кости говорят: {result}"); // Отправляем ответ
                    break;
                case "лето":
                    var now = DateTime.Now; // Получаем текущее время
                    var endOfSummer = new DateTime(now.Year, 9, 1); // Дата окончания лета
                    var startOfSummer = new DateTime(now.Year, 6, 1); // Дата начала лета
                    var nextYear = new DateTime(now.Year + 1, 1, 1);
                    if (now < endOfSummer && now > startOfSummer) // Проверяем, является ли текущая дата летом
                    {
                        var day = (endOfSummer - now).Days; // Получаем количество дней до конца лета
                        client.SendMessage(e.Command.ChatMessage.Channel, $"До конца лета осталось: {day} дней"); // Отправляем ответ
                    }
                    else {
                        if (now > nextYear) {
                            startOfSummer = new DateTime(now.Year + 1, 6, 1);
                            var day = (startOfSummer - now).Days;
                            client.SendMessage(e.Command.ChatMessage.Channel, $"Cейчас не лето :( но до лета осталось {day} дней"); // Отправляем альтернативный ответ
                        }
                        else {
                            startOfSummer = new DateTime(now.Year, 6, 1);
                            var day = (startOfSummer - now).Days;
                            client.SendMessage(e.Command.ChatMessage.Channel, $"Cейчас не лето :( но до лета осталось {day} дней"); // Отправляем альтернативный ответ
                        }
                    }
                    break;
                case "весна":
                    var now2 = DateTime.Now; // Получаем текущее время
                    var endOfSummer2 = new DateTime(now2.Year, 3, 1); // Дата окончания лета
                    var startOfSummer2 = new DateTime(now2.Year, 5, 30); // Дата начала лета
                    var nextYear2 = new DateTime(now2.Year + 1, 3, 1);
                    if (now2 < endOfSummer2 && now2 > startOfSummer2) // Проверяем, является ли текущая дата летом
                    {
                        var day = (endOfSummer2 - now2).Days; // Получаем количество дней до конца лета
                        client.SendMessage(e.Command.ChatMessage.Channel, $"До конца весны осталось: {day} дней"); // Отправляем ответ
                    }
                    else {
                        if (now2 > nextYear2) {
                            startOfSummer = new DateTime(now2.Year + 1, 3, 1);
                            var day = (startOfSummer - now2).Days;
                            client.SendMessage(e.Command.ChatMessage.Channel, $"Cейчас не весна :( но осталось {day} дней"); // Отправляем альтернативный ответ
                        }
                        else {
                            startOfSummer = new DateTime(now2.Year, 3, 1);
                            var day = (startOfSummer - now2).Days;
                            client.SendMessage(e.Command.ChatMessage.Channel, $"Cейчас не весна :( но осталось {day} дней"); // Отправляем альтернативный ответ
                        }
                    }
                    break;
                case "нг":
                    var NOW = DateTime.Now;
                    var endOfYear = new DateTime(NOW.Year, 12, 31, 23, 59, 59);
                    var d = (endOfYear - NOW).Days; //дни
                    var h = (endOfYear - NOW).Hours; //часы
                    var m = (endOfYear - NOW).Minutes; //минуты
                    var s = (endOfYear - NOW).Seconds; //секунды
                    client.SendMessage(e.Command.ChatMessage.Channel, $"До Нового Года осталось: {d} дня, {h} часа, {m} минут, {s} секунд");
                    break;
                case "сыр":

                    if (cheese < 1) {

                        //Console.WriteLine("Cheese1");
                        client.SendMessage(e.Command.ChatMessage.Channel, $"StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese"); // Отправляем сыр
                        cheese = cheese + 1;
                    }
                    else {

                        //Console.WriteLine("Cheese2");
                        client.SendMessage(e.Command.ChatMessage.Channel, $"StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese StinkyCheese"); // Отправляем сыр
                        cheese = cheese - 1;
                    }

                    break;
                case "ютаб":

                    if (you < 1) {
                        you = you + 1;
                        client.SendMessage(e.Command.ChatMessage.Channel, $"ЮТАБ СОСАТЬ BloodTrail ЮТАБ СОСАТЬ BloodTrail ЮТАБ СОСАТЬ BloodTrail ЮТАБ СОСАТЬ BloodTrail ЮТАБ СОСАТЬ BloodTrail ЮТАБ СОСАТЬ BloodTrail ЮТАБ СОСАТЬ BloodTrail ЮТАБ СОСАТЬ BloodTrail ЮТАБ СОСАТЬ BloodTrail ЮТАБ СОСАТЬ BloodTrail ");
                    }
                    else {
                        you = you - 1;
                        client.SendMessage(e.Command.ChatMessage.Channel, $"ЮТАБ СОСАТЬ BloodTrail ЮТАБ СОСАТЬ BloodTrail ЮТАБ СОСАТЬ BloodTrail ЮТАБ СОСАТЬ BloodTrail ЮТАБ СОСАТЬ BloodTrail ЮТАБ СОСАТЬ BloodTrail ЮТАБ СОСАТЬ BloodTrail ЮТАБ СОСАТЬ BloodTrail ЮТАБ СОСАТЬ BloodTrail ЮТАБ СОСАТЬ BloodTrail ЮТАБ СОСАТЬ BloodTrail ");
                    }
                    break;
                case "лучший":
                    client.SendMessage(e.Command.ChatMessage.Channel, $" Vadihs , {e.Command.ChatMessage.DisplayName} хотел(а) сказать, что ты лучший стример <3");

                    break;
                case "вк":
                    client.SendMessage(e.Command.ChatMessage.Channel, $"https://clck.ru/aijLm");

                    break;
                case "беседа":
                    client.SendMessage(e.Command.ChatMessage.Channel, $"https://clck.ru/arwft");

                    break;
                case "дс":
                    client.SendMessage(e.Command.ChatMessage.Channel, $"https://clck.ru/arweA");

                    break;
                case "тг":
                    client.SendMessage(e.Command.ChatMessage.Channel, $"https://t.me/vadihs");

                    break;
                case "bot_help":
                    client.SendMessage(e.Command.ChatMessage.Channel, $"https://clck.ru/aijMb");

                    break;
                case "date":
                    var now1 = DateTime.Now;
                    client.SendMessage(e.Command.ChatMessage.Channel, $"Сегодня {now1}");

                    break;
                case "команды":
                    client.SendMessage(e.Command.ChatMessage.Channel, $"тг, лето, кубик, сыр, ютаб, лучший, вк, беседа, дc, bot_help");
                    break;
            }
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine($"Connected to {e.AutoJoinChannel}");
        }

        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            client.SendMessage(e.Channel, "Привет! Я пришел наводить суету).");
        }

        private void Client_OnLog(object sender, OnLogArgs e)
        {
            //Console.WriteLine(e.Data);
            Console.WriteLine($"{e.DateTime.ToString()}: {e.BotUsername} - {e.Data}");
        }
    }
}