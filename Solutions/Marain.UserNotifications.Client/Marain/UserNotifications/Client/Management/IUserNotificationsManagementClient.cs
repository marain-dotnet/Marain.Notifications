﻿// <copyright file="IUserNotificationsManagementClient.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Marain.UserNotifications.Client.Management
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Marain.UserNotifications.Client.Management.Requests;
    using Marain.UserNotifications.Client.Management.Resources;
    using Marain.UserNotifications.Client.Management.Resources.CommunicationTemplates;

    /// <summary>
    /// Interface for the management client.
    /// </summary>
    public interface IUserNotificationsManagementClient
    {
        /// <summary>Create a new notification for one or more users.</summary>
        /// <param name="tenantId">The tenant within which the request should operate.</param>
        /// <param name="body">The new notifications.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A task representing the operation status.</returns>
        Task<ApiResponse> CreateNotificationsAsync(
            string tenantId,
            CreateNotificationsRequest body,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a new notification for one or more users and also handle delivery via configured communication type and delivery channel.
        /// </summary>
        /// <param name="tenantId">The tenant within which the request should operate.</param>
        /// <param name="body">The new notifications.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A task representing the operation status.</returns>
        Task<ApiResponse> CreateNotificationForDeliveryChannelsAsync(
             string tenantId,
             CreateNotificationForDeliveryChannelsRequest body,
             CancellationToken cancellationToken = default);

        /// <summary>Updates delivery statuses for a batch of user notifications.</summary>
        /// <param name="tenantId">The tenant within which the request should operate.</param>
        /// <param name="body">The update batch.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A task representing the operation status.</returns>
        Task<ApiResponse> BatchDeliveryStatusUpdateAsync(
            string tenantId,
            IEnumerable<BatchDeliveryStatusUpdateRequestItem> body,
            CancellationToken cancellationToken = default);

        /// <summary>Updates read statuses for a batch of user notifications.</summary>
        /// <param name="tenantId">The tenant within which the request should operate.</param>
        /// <param name="body">The update batch.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A task representing the operation status.</returns>
        Task<ApiResponse> BatchReadStatusUpdateAsync(
            string tenantId,
            IEnumerable<BatchReadStatusUpdateRequestItem> body,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the notification template for a Web Push notification.
        /// </summary>
        /// <param name="tenantId">The tenant within which the request should operate.</param>
        /// <param name="notificationType">The notification type of the stored template.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A Notification template.</returns>
        Task<ApiResponse<WebPushTemplateResource>> GetWebPushNotificationTemplate(
            string tenantId,
            string notificationType,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the notification template for a Web Push notification by link.
        /// </summary>
        /// <param name="link">The self link for the WebPushTemplateResource.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A Notification template.</returns>
        Task<ApiResponse<WebPushTemplateResource>> GetWebPushNotificationTemplateByLinkAsync(
            string link,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the notification template for an Email notification.
        /// </summary>
        /// <param name="tenantId">The tenant within which the request should operate.</param>
        /// <param name="notificationType">The notification type of the stored template.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A Notification template.</returns>
        Task<ApiResponse<EmailTemplateResource>> GetEmailNotificationTemplate(
            string tenantId,
            string notificationType,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the notification template for an Email notification by link.
        /// </summary>
        /// <param name="link">The self link for the WebPushTemplateResource.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A Notification template.</returns>
        public Task<ApiResponse<EmailTemplateResource>> GetEmailNotificationTemplateByLinkAsync(
           string link,
           CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the notification template for an Sms notification.
        /// </summary>
        /// <param name="tenantId">The tenant within which the request should operate.</param>
        /// <param name="notificationType">The notification type of the stored template.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A Notification template.</returns>
        Task<ApiResponse<SmsTemplateResource>> GetSmsNotificationTemplate(
            string tenantId,
            string notificationType,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the notification template for an Sms notification by link.
        /// </summary>
        /// <param name="link">The self link for the WebPushTemplateResource.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A Notification template.</returns>
        public Task<ApiResponse<SmsTemplateResource>> GetSmsNotificationTemplateByLinkAsync(
            string link,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Set a notification template for a certain notification type.
        /// </summary>
        /// <param name="tenantId">The tenant within which the request should operate.</param>
        /// <param name="communicationTemplate">The template of the notification.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A Notification template.</returns>
        Task<ApiResponse> SetNotificationTemplate(
            string tenantId,
            ICommunicationTemplate communicationTemplate,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the generated notification template for a certain notification.
        /// </summary>
        /// <param name="tenantId">The tenant within which the request should operate.</param>
        /// <param name="createNotificationsRequest">The notification request object that will be applied to different communication templates.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A Notification template.</returns>
        Task<ApiResponse<NotificationTemplate>> GenerateNotificationTemplate(
            string tenantId,
            CreateNotificationsRequest createNotificationsRequest,
            CancellationToken cancellationToken = default);
    }
}
