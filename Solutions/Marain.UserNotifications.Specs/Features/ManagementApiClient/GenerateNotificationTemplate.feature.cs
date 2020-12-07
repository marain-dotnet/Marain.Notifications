﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.4.0.0
//      SpecFlow Generator Version:3.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Marain.UserNotifications.Specs.Features.ManagementApiClient
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Generate Notification Template via the client library")]
    [NUnit.Framework.CategoryAttribute("perFeatureContainer")]
    [NUnit.Framework.CategoryAttribute("useApis")]
    [NUnit.Framework.CategoryAttribute("useTransientTenant")]
    public partial class GenerateNotificationTemplateViaTheClientLibraryFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "perFeatureContainer",
                "useApis",
                "useTransientTenant"};
        
#line 1 "GenerateNotificationTemplate.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/ManagementApiClient", "Generate Notification Template via the client library", null, ProgrammingLanguage.CSharp, new string[] {
                        "perFeatureContainer",
                        "useApis",
                        "useTransientTenant"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Generate a Notification Template")]
        public virtual void GenerateANotificationTemplate()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generate a Notification Template", null, tagsOfScenario, argumentsOfScenario);
#line 7
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                            "notificationType",
                            "smsTemplate"});
                table10.AddRow(new string[] {
                            "marain.notifications.test.v1",
                            "{\"body\": \"A new lead was added by {{leadAddedBy}}\"}"});
#line 8
 testRunner.Given("I have created and stored a notification template", ((string)(null)), table10, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                            "userId",
                            "email",
                            "phoneNumber",
                            "communicationChannelsPerNotificationConfiguration"});
                table11.AddRow(new string[] {
                            "1",
                            "test@test.com",
                            "041532211",
                            "{\"marain.notifications.test.v1\": [\"webpush\", \"sms\"]}"});
#line 11
 testRunner.And("I have created and stored a user preference for a user", ((string)(null)), table11, "And ");
#line hidden
#line 14
 testRunner.When("I use the client to send a generate template API request", @"      {
          ""notificationType"": ""marain.notifications.test.v1"",
          ""timestamp"": ""2020-07-21T17:32:28Z"",
          ""userIds"": [
              ""1""
          ],
          ""correlationIds"": [""cid1"", ""cid2""],
          ""properties"": {
              ""leadAddedBy"": ""TestUser123"",
          }
      }", ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 28
 testRunner.Then("the client response status code should be \'OK\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 29
    testRunner.And("the client response for the notification template property \'SmsTemplate\' should n" +
                        "ot be null", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 30
    testRunner.And("the client response for the object \'SmsTemplate\' with property \'Body\' should have" +
                        " a value of \'A new lead was added by TestUser123\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Incorrectly generate a Notification Template")]
        public virtual void IncorrectlyGenerateANotificationTemplate()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Incorrectly generate a Notification Template", null, tagsOfScenario, argumentsOfScenario);
#line 32
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                            "notificationType",
                            "smsTemplate"});
                table12.AddRow(new string[] {
                            "marain.notifications.test.v1",
                            "{\"body\": \"A new lead was added by {{leadAddedBy}}\"}"});
#line 33
 testRunner.Given("I have created and stored a notification template", ((string)(null)), table12, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                            "userId",
                            "email",
                            "phoneNumber",
                            "communicationChannelsPerNotificationConfiguration"});
                table13.AddRow(new string[] {
                            "1",
                            "test@test.com",
                            "041532211",
                            "{\"marain.notifications.test.v1\": [\"webpush\"]}"});
#line 36
 testRunner.And("I have created and stored a user preference for a user", ((string)(null)), table13, "And ");
#line hidden
#line 39
 testRunner.When("I use the client to send a generate template API request", @"      {
          ""notificationType"": ""marain.notifications.test.v1"",
          ""timestamp"": ""2020-07-21T17:32:28Z"",
          ""userIds"": [
              ""1""
          ],
          ""correlationIds"": [""cid1"", ""cid2""],
          ""properties"": {
              ""leadAddedBy"": ""TestUser123"",
          }
      }", ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 53
 testRunner.Then("the client response status code should be \'OK\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
