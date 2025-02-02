namespace Telnyx
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum;
    using Telnyx.net.Entities.Messaging.Messaging_Profiles;

    /// <summary>
    /// Messaging Profile Update.
    /// </summary>
    public class MessagingProfileUpdate : BaseOptions
    {

        /// <summary>
        /// Gets or sets a user friendly name for the messaging profile.
        /// </summary>
        /// <value>A user friendly name for the messaging profile.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the URL where webhooks related to this messaging profile will be sent.
        /// </summary>
        /// <value>The URL where webhooks related to this messaging profile will be sent.</value>
        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }

        /// <summary>
        /// Gets or sets the failover URL where webhooks related to this messaging profile will be sent if sending to the primary URL fails.
        /// </summary>
        /// <value>The failover URL where webhooks related to this messaging profile will be sent if sending to the primary URL fails.</value>
        [JsonProperty("webhook_failover_url")]
        public string WebhookFailoverUrl { get; set; }

        /// <summary>
        /// Gets or sets specifies whether the messaging profile is enabled or not.
        /// </summary>
        /// <value>Specifies whether the messaging profile is enabled or not.</value>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets or sets specifies whether to apply character simplification to text.
        /// </summary>
        /// <value>Specifies whether to apply character simplification to text.</value>
        [JsonProperty("simplify_characters")]
        public bool? SimplifyCharacters { get; set; }

        /// <summary>
        /// Gets or sets destinations to which the messaging profile is allowed to send.
        /// </summary>
        /// <value>Destinations to which the messaging profile is allowed to send.</value>
        [JsonProperty("whitelisted_destinations")]
        public List<string> WhitelistedDestinations { get; set; }

        /// <summary>
        /// Gets or sets determines which webhook format will be used, API V1 or API V2.
        /// </summary>
        /// <value>Determines which webhook format will be used, API V1 or API V2.</value>
        [JsonProperty("webhook_api_version")]
        public WebhookAPIVersion? WebhookApiVersion { get; set; }

        /// <summary>
        /// Gets or sets NumberPoolSettings.
        /// </summary>
        [JsonProperty("number_pool_settings")]
        public NumberPoolSettings NumberPoolSettings { get; set; }

        /// <summary>
        /// The URL shortener feature allows automatic replacement of URLs that were generated using
        /// a public URL shortener service.Some examples include bit.do, bit.ly, goo.gl, ht.ly,
        /// is.gd, ow.ly, rebrand.ly, t.co, tiny.cc, and tinyurl.com.Such URLs are replaced with
        /// with links generated by Telnyx. The use of custom links can improve branding and message
        /// deliverability.
        ///
        /// To disable this feature, set the object field to `null`.
        /// </summary>
        [JsonProperty("url_shortener_settings")]
        public UrlShortenerSettings UrlShortenerSettings { get; set; }
    }
}
