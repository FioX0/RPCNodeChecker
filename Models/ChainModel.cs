using Newtonsoft.Json;

namespace RPCNodeChecker.Models
{
    public class ConfigModel
    {

        [JsonProperty("ActivationCodeUrl")]
        public string ActivationCodeUrl { get; set; }

        [JsonProperty("AppleMarketUrl")]
        public string AppleMarketUrl { get; set; }

        [JsonProperty("AppProtocolVersion")]
        public string AppProtocolVersion { get; set; }

        [JsonProperty("ConfigVersion")]
        public int ConfigVersion { get; set; }

        [JsonProperty("DataProviderUrl")]
        public string[] DataProviderUrl { get; set; }

        [JsonProperty("DiscordUrl")]
        public string DiscordUrl { get; set; }

        [JsonProperty("DownloadBaseURL")]
        public string DownloadBaseURL { get; set; }

        [JsonProperty("GenesisBlockPath")]
        public string GenesisBlockPath { get; set; }

        [JsonProperty("GoogleMarketUrl")]
        public string GoogleMarketUrl { get; set; }

        [JsonProperty("IAPServiceHostUrl")]
        public string IAPServiceHostUrl { get; set; }

        [JsonProperty("KeystoreBackupDocumentationUrl")]
        public string KeystoreBackupDocumentationUrl { get; set; }

        [JsonProperty("LaunchPlayer")]
        public bool LaunchPlayer { get; set; }

        [JsonProperty("LogSizeBytes")]
        public int LogSizeBytes { get; set; }

        [JsonProperty("MarketServiceUrl")]
        public string[] MarketServiceUrl { get; set; }

        [JsonProperty("Network")]
        public string Network { get; set; }

        [JsonProperty("OnboardingPortalUrl")]
        public string[] OnboardingPortalUrl { get; set; }

        [JsonProperty("PatrolRewardServiceUrl")]
        public string[] PatrolRewardServiceUrl { get; set; }

        [JsonProperty("PlayerUpdateRetryCount")]
        public int PlayerUpdateRetryCount { get; set; }

        [JsonProperty("RemoteNodeList")]
        public string[] RemoteNodeList { get; set; }

        [JsonProperty("SeasonPassServiceUrl")]
        public string SeasonPassServiceUrl { get; set; }

        [JsonProperty("SwapAddress")]
        public string SwapAddress { get; set; }

        [JsonProperty("SwapAvailabilityCheckServiceUrl")]
        public string SwapAvailabilityCheckServiceUrl { get; set; }

        [JsonProperty("TrayOnClose")]
        public bool TrayOnClose { get; set; }

        [JsonProperty("MeadPledgePortalUrl")]
        public string MeadPledgePortalUrl { get; set; }

        [JsonProperty("Planet")]
        public string Planet { get; set; }

        [JsonProperty("PlanetRegistryUrl")]
        public string PlanetRegistryUrl { get; set; }

        [JsonProperty("Maintenance")]
        public bool Maintenance { get; set; }

        [JsonProperty("ArenaServiceUrl")]
        public string[] ArenaServiceUrl { get; set; }
    }
}
