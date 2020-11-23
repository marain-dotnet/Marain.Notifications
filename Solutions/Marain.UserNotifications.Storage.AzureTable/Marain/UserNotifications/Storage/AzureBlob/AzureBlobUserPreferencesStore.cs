﻿// <copyright file="AzureBlobUserPreferencesStore.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Marain.UserNotifications.Storage.AzureBlob
{
    using System;
    using System.Threading.Tasks;
    using Corvus.Extensions.Json;
    using Marain.UserNotifications;
    using Marain.UserPreferences;
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    /// <summary>
    /// An implementation of <see cref="IUserPreferencesStore"/> over Azure Blob storage.
    /// </summary>
    public class AzureBlobUserPreferencesStore : IUserPreferencesStore
    {
        private readonly ILogger logger;
        private readonly IJsonSerializerSettingsProvider serializerSettingsProvider;
        private readonly CloudBlobContainer blobContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureBlobUserPreferencesStore"/> class.
        /// </summary>
        /// <param name="blobContainer">The blob container.</param>
        /// <param name="serializerSettingsProvider">The serialization settings provider.</param>
        /// <param name="logger">The logger.</param>
        public AzureBlobUserPreferencesStore(
            CloudBlobContainer blobContainer,
            IJsonSerializerSettingsProvider serializerSettingsProvider,
            ILogger logger)
        {
            this.logger = logger
                ?? throw new ArgumentNullException(nameof(logger));
            this.serializerSettingsProvider = serializerSettingsProvider
                ?? throw new ArgumentNullException(nameof(serializerSettingsProvider));
            this.blobContainer = blobContainer
                ?? throw new ArgumentNullException(nameof(blobContainer));
        }

        /// <inheritdoc/>
        public async Task<UserPreference?> GetAsync(string userId)
        {
            CloudBlockBlob blob = this.blobContainer.GetBlockBlobReference(userId);

            bool exists = await blob.ExistsAsync().ConfigureAwait(false);

            if (!exists)
            {
                return null;
            }

            string json = await blob.DownloadTextAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<UserPreference>(json, this.serializerSettingsProvider.Instance);
        }

        /// <inheritdoc/>
        public async Task<UserPreference> StoreAsync(UserPreference userPreference)
        {
            this.logger.LogDebug(
                "Storing notification for user ",
                userPreference.UserId);

            CloudBlockBlob blockBlob = this.blobContainer.GetBlockBlobReference(userPreference.UserId);

            string userPreferenceBlob = JsonConvert.SerializeObject(userPreference, this.serializerSettingsProvider.Instance);

            await blockBlob.UploadTextAsync(userPreferenceBlob).ConfigureAwait(false);

            return userPreference;
        }
    }
}
