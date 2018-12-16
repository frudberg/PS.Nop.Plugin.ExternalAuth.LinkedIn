﻿using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Authentication.External;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Nop.Plugin.ExternalAuth.LinkedIn
{
    public class LinkedInAuthenticationMethod : BasePlugin, IExternalAuthenticationMethod
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;

        #endregion

        #region Ctor

        public LinkedInAuthenticationMethod(ILocalizationService localizationService,
            ISettingService settingService,
            IWebHelper webHelper)
        {
            this._localizationService = localizationService;
            this._settingService = settingService;
            this._webHelper = webHelper;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/PSLinkedInAuthentication/Configure";
        }

        /// <summary>
        /// Gets a name of a view component for displaying plugin in public store
        /// </summary>
        /// <returns>View component name</returns>
        public string GetPublicViewComponentName()
        {
            return LinkedInExternalAuthConstants.ViewComponentName;
        }

        /// <summary>
        /// Install the plugin
        /// </summary>
        public override void Install()
        {
            //settings
            _settingService.SaveSetting(new LinkedInExternalAuthSettings());

            //locales
            _localizationService.AddOrUpdatePluginLocaleResource("PS.Plugins.ExternalAuth.LinkedIn.ClientKeyIdentifier", "App ID/API Key");
            _localizationService.AddOrUpdatePluginLocaleResource("PS.Plugins.ExternalAuth.LinkedIn.ClientKeyIdentifier.Hint", "Enter your app ID/API key here. You can find it on your FaceBook application page.");
            _localizationService.AddOrUpdatePluginLocaleResource("PS.Plugins.ExternalAuth.LinkedIn.ClientSecret", "App Secret");
            _localizationService.AddOrUpdatePluginLocaleResource("PS.Plugins.ExternalAuth.LinkedIn.ClientSecret.Hint", "Enter your app secret here. You can find it on your FaceBook application page.");
            _localizationService.AddOrUpdatePluginLocaleResource("PS.Plugins.ExternalAuth.LinkedIn.Instructions", "<p>To configure authentication with LinkedIn, please follow these steps:<br/><br/><ol><li>Start by navigating to your <a href=\"https://developer.linkedin.com\" target =\"_blank\" > linked in for developers</a>.</li><li>Start the process of creating a new app by pressing the button <b>\"Create app\".</b></li><li>Provide \"App name\", \"Company name\", \"App description\" and upload logo and provide whatever other information that is asked for. Don't forget to accept the legal terms at the end.</li><li> You are now navigated to the \"App settings\" screen. On the top of the page, in the top menu choose <b>\"Auth\"</b></li><li>Go down to the section for OAuth 2.0 settings and edit the redirect URLs, enter \"YourStoreUrl / signin - linkedin\" in that field (start with http or https). Press <b>\"Update\"</b></li><li>Under \"Application credentials\" you can see the application’s Client ID and Client Secret, copy these and paste into the corresponding fields below.</li></ol><br/><br/></p>");

            base.Install();
        }

        /// <summary>
        /// Uninstall the plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<LinkedInExternalAuthSettings>();

            //locales
            _localizationService.DeletePluginLocaleResource("PS.Plugins.ExternalAuth.LinkedIn.ClientKeyIdentifier");
            _localizationService.DeletePluginLocaleResource("PS.Plugins.ExternalAuth.LinkedIn.ClientKeyIdentifier.Hint");
            _localizationService.DeletePluginLocaleResource("PS.Plugins.ExternalAuth.LinkedIn.ClientSecret");
            _localizationService.DeletePluginLocaleResource("PS.Plugins.ExternalAuth.LinkedIn.ClientSecret.Hint");
            _localizationService.DeletePluginLocaleResource("PS.Plugins.ExternalAuth.LinkedIn.Instructions");

            base.Uninstall();
        }

        #endregion
    }
}
