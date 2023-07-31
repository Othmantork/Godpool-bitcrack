namespace BitcrackRandomiser
{
    internal class Requests
    {
        // API URL endpoint
        public static string ApiURL = "https://api.btcpuzzle.info/";

        /// <summary>
        /// Get random HEX value from API
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static async Task<string> GetHex(Settings settings)
        {
            try
            {
                // CustomRange
                string StartsWith = settings.CustomRange;
                string TargetPuzzle = settings.TargetPuzzle;
                string ScanType = settings.ScanType;
                using var client = new HttpClient { BaseAddress = new Uri(ApiURL) };
                client.DefaultRequestHeaders.Add("UserToken", settings.UserToken);
                client.DefaultRequestHeaders.Add("WalletAddress", settings.WalletAddress);
                client.DefaultRequestHeaders.Add("PrivatePool", settings.PrivatePool);

                // Request
                var Request = await client.GetAsync(string.Format("hex/getv3?startswith={0}&puzzlecode={1}&scantype={2}", StartsWith, TargetPuzzle, ScanType));
                string Result = await Request.Content.ReadAsStringAsync();
                if (Result.Length >= 6 && Result.Length <= 160 && Request.IsSuccessStatusCode)
                {
                    return Result;
                }
                return "";
            }
            catch { return ""; }
        }

        /// <summary>
        /// HEX will be flagged as scanned
        /// </summary>
        /// <param name="HEX">Scanned HEX</param>
        /// <param name="WalletAddress">Worker wallet address</param>
        /// <param name="ProofKey">Proof key for marking</param>
        /// <param name="GPUName">Current GPU name</param>
        /// <param name="TargetPuzzle">Target Puzzle</param>
        /// <returns></returns>
        public static async Task<bool> SetHex(string HEX, string WalletAddress, string ProofKey, string GPUName, string PrivatePool = "none", string TargetPuzzle = "66")
        {
            try
            {
                bool isSuccess = false;
                using var client = new HttpClient { BaseAddress = new Uri(ApiURL) };
                client.DefaultRequestHeaders.Add("HEX", HEX);
                client.DefaultRequestHeaders.Add("WalletAddress", WalletAddress);
                client.DefaultRequestHeaders.Add("PrivatePool", PrivatePool);
                client.DefaultRequestHeaders.Add("ProofKey", ProofKey);
                client.DefaultRequestHeaders.Add("GPU", GPUName);
                string Result = await client.PostAsync(string.Format("hex/flag?puzzlecode={0}", TargetPuzzle), null).Result.Content.ReadAsStringAsync();
                Boolean.TryParse(Result, out isSuccess);
                return isSuccess;
            }
            catch { return false; }
        }

        /// <summary>
        /// Get remote settings
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetRemoteSettings(string URL)
        {
            try
            {
                using var client = new HttpClient();
                var Request = await client.GetAsync(URL);
                string Result = await Request.Content.ReadAsStringAsync();
                return Result;
            }
            catch { return ""; }
        }

        /// <summary>
        /// Share progress to your API
        /// </summary>
        /// <param name="apiShare"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static async Task<bool> SendApiShare(ApiShare apiShare, Settings settings)
        {
            try
            {
                if (settings.IsApiShare)
                {
                    bool isSuccess = false;
                    using var client = new HttpClient { BaseAddress = new Uri(settings.ApiShare) };
                    client.DefaultRequestHeaders.Add("Status", apiShare.Status.ToString());
                    client.DefaultRequestHeaders.Add("HEX", apiShare.HEX);
                    client.DefaultRequestHeaders.Add("PrivateKey", apiShare.PrivateKey);
                    client.DefaultRequestHeaders.Add("TargetPuzzle", settings.TargetPuzzle);
                    client.DefaultRequestHeaders.Add("WorkerAddress", settings.ParsedWalletAddress);
                    client.DefaultRequestHeaders.Add("WorkerName", settings.ParsedWorkerName);
                    client.DefaultRequestHeaders.Add("ScanType", settings.ScanType.ToString());
                    string Result = await client.PostAsync("", null).Result.Content.ReadAsStringAsync();
                    Boolean.TryParse(Result, out isSuccess);
                    return isSuccess;
                }

                return false;
            }
            catch { return false; }
        }
    }

    /// <summary>
    /// Alternative for telegram. Share progress with your API
    /// </summary>
    public class ApiShare
    {
        // Current status
        public ApiShareStatus Status { get; set; }

        // Scanned HEX
        public string HEX { get; set; } = "";

        // Found private key
        public string PrivateKey { get; set; } = "";
    }

    /// <summary>
    /// Enum types for apishare
    /// </summary>
    public enum ApiShareStatus
    {
        workerStarted,
        workerExited,
        rangeScanned,
        reachedOfKeySpace,
        keyFound
    }
}
