﻿using Monitor.Application.Interfaces;
using Monitor.Application.MonitoringChecks.Models;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Options;
using Monitor.Infrastructure.Settings;

namespace Monitor.Infrastructure.Telegram
{
    public class TelegramService : ITelegramNotificationService
    {
        private IOptions<TelegramNotificationSettings> _settings;

        public TelegramService(IOptions<TelegramNotificationSettings> settings)
        {
            _settings = settings ?? throw new ArgumentNullException("telegram settings is empty");
        }

        public async Task Notify(Check checkResults)
        {
            var text = GetText(checkResults);
            var urlString = String.Format(_settings.Value.SendMessageEndpoint , _settings.Value.BotKey, _settings.Value.ChatId, text);

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(urlString);

                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
        }

        public async Task SendMessageFromSeoWorker(string text)
        {
            var urlString = String.Format(_settings.Value.SendMessageEndpoint, _settings.Value.SeoWorkerBotName, _settings.Value.SeoWorkerChatId, text);

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(urlString);

                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
        }

        public async Task SendMessageToMdpChat(string text)
        {
            var urlString = String.Format(_settings.Value.SendMessageEndpoint, _settings.Value.SeoWorkerBotName, _settings.Value.MdpChatId, text);

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(urlString);

                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
        }

        private string GetText(Check check)
        {
            return GetEmojiCode(check) + " Проверка: " + check.Settings.Service + ", ID: " + check.Settings.Type 
                + "\n Статус: " + check.State.Status.ToFriendlyString() 
                + "\n Время срабатывания: " + check.State.StatusChangeTime.ToString()
                + "\n Описание: " + check.State.Description;
        }

        private string GetEmojiCode(Check check) => (check.State.Status == StatusesEnum.CRITICAL) ? "\U0000274c" : "\U00002705";

    }
}
