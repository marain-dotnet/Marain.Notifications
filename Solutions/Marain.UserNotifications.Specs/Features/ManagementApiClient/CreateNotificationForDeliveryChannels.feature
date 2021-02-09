﻿@perFeatureContainer
@useApis
@useTransientTenant
Feature: Create Notification For Third Party Delivery Channels via the client library

Scenario Outline: Create web push notifications
	When I use the client to send a management API request to create a new notification via third party delivery channels
		| NotificationType   | UserIds   | Timestamp   | PropertiesJson   | CorrelationIds   | DeliveryChannelConfiguredPerCommunicationType   |
		| <NotificationType> | <UserIds> | <Timestamp> | <PropertiesJson> | <CorrelationIds> | <DeliveryChannelConfiguredPerCommunicationType> |
	Then no exception should be thrown
	And the client response status code should be 'Accepted'
	And the client response should contain a 'Location' header

	Examples:
		| Notes          | NotificationType            | UserIds                                                                          | Timestamp         | PropertiesJson      | CorrelationIds | DeliveryChannelConfiguredPerCommunicationType |
		| Single user    | marain.test.notification.v1 | ["304ABC0E-08AF-4EF5-A9AC-281B67D633F4"]                                         | 2012-03-19T07:22Z | { "prop1": "val1" } | ["id1", "id2"] | { "webPush": "airship" }                      |
		| Multiple users | marain.test.notification.v1 | ["304ABC0E-08AF-4EF5-A9AC-281B67D633F4", "5547F9E1-A3B1-4D39-BFA9-73129EF475A9"] | 2012-03-19T07:22Z | { "prop1": "val1" } | ["id1", "id2"] | { "webPush": "airship" }                      |