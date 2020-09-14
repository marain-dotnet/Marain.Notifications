﻿// <copyright file="DataSetupSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Marain.UserNotifications.Specs.Steps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Corvus.Extensions.Json;
    using Corvus.Json;
    using Corvus.Testing.SpecFlow;
    using Marain.UserNotifications.Specs.Bindings;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using TechTalk.SpecFlow;

    [Binding]
    public class DataSetupSteps
    {
        public const string CreatedNotificationsKey = "CreatedNotificationsKey";

        private readonly IServiceProvider serviceProvider;
        private readonly FeatureContext featureContext;
        private readonly ScenarioContext scenarioContext;

        public DataSetupSteps(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            this.featureContext = featureContext;
            this.scenarioContext = scenarioContext;
            this.serviceProvider = ContainerBindings.GetServiceProvider(featureContext);
        }

        public static UserNotification BuildNotificationFrom(TableRow tableRow, JsonSerializerSettings serializerSettings)
        {
            string[] correlationIds = JArray.Parse(tableRow["CorrelationIds"]).Select(token => token.Value<string>()).ToArray();
            IPropertyBag properties = JsonConvert.DeserializeObject<IPropertyBag>(tableRow["PropertiesJson"], serializerSettings);

            string? notificationId = tableRow.ContainsKey("Id") ? tableRow["Id"] : null;

            return new UserNotification(
                notificationId,
                tableRow["NotificationType"],
                tableRow["UserId"],
                DateTime.Parse(tableRow["Timestamp"]),
                properties,
                new UserNotificationMetadata(correlationIds, null));
        }

        [Given("I have created and stored a notification in the current transient tenant for the user with Id '(.*)'")]
        public Task GivenIHaveCreatedAndStoredANotificationInTheCurrentTransientTenantForTheUserWithId(string userId)
        {
            return this.GivenIHaveCreatedAndStoredNotificationsInTheCurrentTransientTenantWithTimestampsAtSecondIntervalsForTheUserWithId(1, 0, userId);
        }

        [Given("I have created and stored (.*) notifications in the current transient tenant with timestamps at (.*) second intervals for the user with Id '(.*)'")]
        public async Task GivenIHaveCreatedAndStoredNotificationsInTheCurrentTransientTenantWithTimestampsAtSecondIntervalsForTheUserWithId(int notificationCount, int interval, string userId)
        {
            ITenantedUserNotificationStoreFactory storeFactory = this.serviceProvider.GetRequiredService<ITenantedUserNotificationStoreFactory>();
            IUserNotificationStore store = await storeFactory.GetUserNotificationStoreForTenantAsync(this.featureContext.GetTransientTenant()).ConfigureAwait(false);
            IPropertyBagFactory propertyBagFactory = this.serviceProvider.GetRequiredService<IPropertyBagFactory>();

            var offset = TimeSpan.FromSeconds(interval);
            DateTimeOffset timestamp = DateTimeOffset.UtcNow - offset;

            var tasks = new List<Task<UserNotification>>();
            var propertiesDictionary = new Dictionary<string, object>
            {
                { "prop1", "val1" },
                { "prop2", 2 },
                { "prop3", DateTime.Now },
            };

            IPropertyBag properties = propertyBagFactory.Create(propertiesDictionary);

            for (int i = 0; i < notificationCount; i++)
            {
                string[] correlationIds = Enumerable.Range(0, 3).Select(_ => Guid.NewGuid().ToString()).ToArray();
                var metadata = new UserNotificationMetadata(correlationIds, null);
                tasks.Add(store.StoreAsync(new UserNotification(null, "marain.usernotifications.test", userId, timestamp, properties, metadata)));
                timestamp -= offset;
            }

            UserNotification[] newlyCreatedNotifications = await Task.WhenAll(tasks).ConfigureAwait(false);

            // Store the notifications in session state
            if (!this.scenarioContext.TryGetValue(CreatedNotificationsKey, out List<UserNotification> createdNotifications))
            {
                createdNotifications = new List<UserNotification>();
                this.scenarioContext.Set(createdNotifications, CreatedNotificationsKey);
            }

            createdNotifications.AddRange(newlyCreatedNotifications);
        }

        [Given("I have created and stored a notification in the current transient tenant and called the result '(.*)'")]
        public async Task GivenIHaveCreatedAndStoredANotificationInTheCurrentTransientTenantAndCalledTheResult(string resultName, Table table)
        {
            ITenantedUserNotificationStoreFactory storeFactory = this.serviceProvider.GetRequiredService<ITenantedUserNotificationStoreFactory>();
            IJsonSerializerSettingsProvider serializerSettingsProvider = this.serviceProvider.GetRequiredService<IJsonSerializerSettingsProvider>();
            UserNotification notification = BuildNotificationFrom(table.Rows[0], serializerSettingsProvider.Instance);
            IUserNotificationStore store = await storeFactory.GetUserNotificationStoreForTenantAsync(this.featureContext.GetTransientTenant()).ConfigureAwait(false);

            UserNotification result = await store.StoreAsync(notification).ConfigureAwait(false);

            this.scenarioContext.Set(result, resultName);
        }
    }
}
