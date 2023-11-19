/*
 * SpaceTraders API
 *
 * SpaceTraders is an open-universe game and learning platform that offers a set of HTTP endpoints to control a fleet of ships and explore a multiplayer universe.  The API is documented using [OpenAPI](https://github.com/SpaceTradersAPI/api-docs). You can send your first request right here in your browser to check the status of the game server.  ```json http {   \"method\": \"GET\",   \"url\": \"https://api.spacetraders.io/v2\", } ```  Unlike a traditional game, SpaceTraders does not have a first-party client or app to play the game. Instead, you can use the API to build your own client, write a script to automate your ships, or try an app built by the community.  We have a [Discord channel](https://discord.com/invite/jh6zurdWk5) where you can share your projects, ask questions, and get help from other players.   
 *
 * The version of the OpenAPI document: 2.0.0
 * Contact: joel@spacetraders.io
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace SpaceTraders.Client
{
    /// <summary>
    /// Represents a set of configuration settings
    /// </summary>
    public class Configuration : IReadableConfiguration
    {
        #region Constants

        /// <summary>
        /// Version of the package.
        /// </summary>
        /// <value>Version of the package.</value>
        public const string Version = "1.0.0";

        /// <summary>
        /// Identifier for ISO 8601 DateTime Format
        /// </summary>
        /// <remarks>See https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8 for more information.</remarks>
        // ReSharper disable once InconsistentNaming
        public const string ISO8601_DATETIME_FORMAT = "o";

        #endregion Constants

        #region Static Members

        /// <summary>
        /// Default creation of exceptions for a given method name and response object
        /// </summary>
        public static readonly ExceptionFactory DefaultExceptionFactory = (methodName, response) =>
        {
            var status = (int)response.StatusCode;
            if (status >= 400)
            {
                return new ApiException(status,
                    string.Format("Error calling {0}: {1}", methodName, response.RawContent),
                    response.RawContent, response.Headers);
            }

            if (status == 0)
            {
                return new ApiException(status,
                    string.Format("Error calling {0}: {1}", methodName, response.ErrorText), response.ErrorText);
            }

            return null;
        };

        #endregion Static Members

        #region Private Members

        /// <summary>
        /// Defines the base path of the target API server.
        /// Example: http://localhost:3000/v1/
        /// </summary>
        private string _basePath;

        private bool _useDefaultCredentials = false;

        /// <summary>
        /// Gets or sets the API key based on the authentication name.
        /// This is the key and value comprising the "secret" for accessing an API.
        /// </summary>
        /// <value>The API key.</value>
        private IDictionary<string, string> _apiKey;

        /// <summary>
        /// Gets or sets the prefix (e.g. Token) of the API key based on the authentication name.
        /// </summary>
        /// <value>The prefix of the API key.</value>
        private IDictionary<string, string> _apiKeyPrefix;

        private string _dateTimeFormat = ISO8601_DATETIME_FORMAT;
        private string _tempFolderPath = Path.GetTempPath();

        /// <summary>
        /// Gets or sets the servers defined in the OpenAPI spec.
        /// </summary>
        /// <value>The servers</value>
        private IList<IReadOnlyDictionary<string, object>> _servers;

        /// <summary>
        /// Gets or sets the operation servers defined in the OpenAPI spec.
        /// </summary>
        /// <value>The operation servers</value>
        private IReadOnlyDictionary<string, List<IReadOnlyDictionary<string, object>>> _operationServers;

        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration" /> class
        /// </summary>
        public Configuration()
        {
            Proxy = null;
            UserAgent = WebUtility.UrlEncode("OpenAPI-Generator/1.0.0/csharp");
            BasePath = "https://api.spacetraders.io/v2";
            DefaultHeaders = new ConcurrentDictionary<string, string>();
            ApiKey = new ConcurrentDictionary<string, string>();
            ApiKeyPrefix = new ConcurrentDictionary<string, string>();
            Servers = new List<IReadOnlyDictionary<string, object>>()
            {
                {
                    new Dictionary<string, object> {
                        {"url", "https://api.spacetraders.io/v2"},
                        {"description", "v2"},
                    }
                }
            };
            OperationServers = new Dictionary<string, List<IReadOnlyDictionary<string, object>>>()
            {
            };

            // Setting Timeout has side effects (forces ApiClient creation).
            Timeout = 100000;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration" /> class
        /// </summary>
        public Configuration(
            IDictionary<string, string> defaultHeaders,
            IDictionary<string, string> apiKey,
            IDictionary<string, string> apiKeyPrefix,
            string basePath = "https://api.spacetraders.io/v2") : this()
        {
            if (string.IsNullOrWhiteSpace(basePath))
                throw new ArgumentException("The provided basePath is invalid.", nameof(basePath));
            ArgumentNullException.ThrowIfNull(defaultHeaders);
            ArgumentNullException.ThrowIfNull(apiKey);
            ArgumentNullException.ThrowIfNull(apiKeyPrefix);

            BasePath = basePath;

            foreach (var keyValuePair in defaultHeaders)
            {
                DefaultHeaders.Add(keyValuePair);
            }

            foreach (var keyValuePair in apiKey)
            {
                ApiKey.Add(keyValuePair);
            }

            foreach (var keyValuePair in apiKeyPrefix)
            {
                ApiKeyPrefix.Add(keyValuePair);
            }
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the base path for API access.
        /// </summary>
        public virtual string BasePath
        {
            get { return _basePath; }
            set { _basePath = value; }
        }

        /// <summary>
        /// Determine whether or not the "default credentials" (e.g. the user account under which the current process is running) will be sent along to the server. The default is false.
        /// </summary>
        public virtual bool UseDefaultCredentials
        {
            get { return _useDefaultCredentials; }
            set { _useDefaultCredentials = value; }
        }

        /// <summary>
        /// Gets or sets the default header.
        /// </summary>
        [Obsolete("Use DefaultHeaders instead.")]
        public virtual IDictionary<string, string> DefaultHeader
        {
            get
            {
                return DefaultHeaders;
            }
            set
            {
                DefaultHeaders = value;
            }
        }

        /// <summary>
        /// Gets or sets the default headers.
        /// </summary>
        public virtual IDictionary<string, string> DefaultHeaders { get; set; }

        /// <summary>
        /// Gets or sets the HTTP timeout (milliseconds) of ApiClient. Default to 100000 milliseconds.
        /// </summary>
        public virtual int Timeout { get; set; }

        /// <summary>
        /// Gets or sets the proxy
        /// </summary>
        /// <value>Proxy.</value>
        public virtual WebProxy Proxy { get; set; }

        /// <summary>
        /// Gets or sets the HTTP user agent.
        /// </summary>
        /// <value>Http user agent.</value>
        public virtual string UserAgent { get; set; }

        /// <summary>
        /// Gets or sets the username (HTTP basic authentication).
        /// </summary>
        /// <value>The username.</value>
        public virtual string Username { get; set; }

        /// <summary>
        /// Gets or sets the password (HTTP basic authentication).
        /// </summary>
        /// <value>The password.</value>
        public virtual string Password { get; set; }

        /// <summary>
        /// Gets the API key with prefix.
        /// </summary>
        /// <param name="apiKeyIdentifier">API key identifier (authentication scheme).</param>
        /// <returns>API key with prefix.</returns>
        public string GetApiKeyWithPrefix(string apiKeyIdentifier)
        {
            ApiKey.TryGetValue(apiKeyIdentifier, out var apiKeyValue);
            if (ApiKeyPrefix.TryGetValue(apiKeyIdentifier, out var apiKeyPrefix))
            {
                return apiKeyPrefix + " " + apiKeyValue;
            }

            return apiKeyValue;
        }

        /// <summary>
        /// Gets or sets certificate collection to be sent with requests.
        /// </summary>
        /// <value>X509 Certificate collection.</value>
        public X509CertificateCollection ClientCertificates { get; set; }

        /// <summary>
        /// Gets or sets the access token for OAuth2 authentication.
        ///
        /// This helper property simplifies code generation.
        /// </summary>
        /// <value>The access token.</value>
        public virtual string? AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the temporary folder path to store the files downloaded from the server.
        /// </summary>
        /// <value>Folder path.</value>
        public virtual string TempFolderPath
        {
            get { return _tempFolderPath; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _tempFolderPath = Path.GetTempPath();
                    return;
                }

                // create the directory if it does not exist
                if (!Directory.Exists(value))
                {
                    Directory.CreateDirectory(value);
                }

                // check if the path contains directory separator at the end
                _tempFolderPath = value[^1] == Path.DirectorySeparatorChar ? value : value + Path.DirectorySeparatorChar;
            }
        }

        /// <summary>
        /// Gets or sets the date time format used when serializing in the ApiClient
        /// By default, it's set to ISO 8601 - "o", for others see:
        /// https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx
        /// and https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx
        /// No validation is done to ensure that the string you're providing is valid
        /// </summary>
        /// <value>The DateTimeFormat string</value>
        public virtual string DateTimeFormat
        {
            get { return _dateTimeFormat; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    // Never allow a blank or null string, go back to the default
                    _dateTimeFormat = ISO8601_DATETIME_FORMAT;
                    return;
                }

                // Caution, no validation when you choose date time format other than ISO 8601
                // Take a look at the above links
                _dateTimeFormat = value;
            }
        }

        /// <summary>
        /// Gets or sets the prefix (e.g. Token) of the API key based on the authentication name.
        ///
        /// Whatever you set here will be prepended to the value defined in AddApiKey.
        ///
        /// An example invocation here might be:
        /// <example>
        /// ApiKeyPrefix["Authorization"] = "Bearer";
        /// </example>
        /// … where ApiKey["Authorization"] would then be used to set the value of your bearer token.
        ///
        /// <remarks>
        /// OAuth2 workflows should set tokens via AccessToken.
        /// </remarks>
        /// </summary>
        /// <value>The prefix of the API key.</value>
        public virtual IDictionary<string, string> ApiKeyPrefix
        {
            get { return _apiKeyPrefix; }
            set
            {
                if (value == null)
                {
                    throw new InvalidOperationException("ApiKeyPrefix collection may not be null.");
                }

                _apiKeyPrefix = value;
            }
        }

        /// <summary>
        /// Gets or sets the API key based on the authentication name.
        /// </summary>
        /// <value>The API key.</value>
        public virtual IDictionary<string, string> ApiKey
        {
            get { return _apiKey; }
            set
            {
                if (value == null)
                {
                    throw new InvalidOperationException("ApiKey collection may not be null.");
                }

                _apiKey = value;
            }
        }

        /// <summary>
        /// Gets or sets the servers.
        /// </summary>
        /// <value>The servers.</value>
        public virtual IList<IReadOnlyDictionary<string, object>> Servers
        {
            get { return _servers; }
            set
            {
                if (value == null)
                {
                    throw new InvalidOperationException("Servers may not be null.");
                }

                _servers = value;
            }
        }

        /// <summary>
        /// Gets or sets the operation servers.
        /// </summary>
        /// <value>The operation servers.</value>
        public virtual IReadOnlyDictionary<string, List<IReadOnlyDictionary<string, object>>> OperationServers
        {
            get { return _operationServers; }
            set
            {
                if (value == null)
                {
                    throw new InvalidOperationException("Operation servers may not be null.");
                }

                _operationServers = value;
            }
        }

        /// <summary>
        /// Returns URL based on server settings without providing values
        /// for the variables
        /// </summary>
        /// <param name="index">Array index of the server settings.</param>
        /// <return>The server URL.</return>
        public string GetServerUrl(int index)
        {
            return GetServerUrl(Servers, index, null);
        }

        /// <summary>
        /// Returns URL based on server settings.
        /// </summary>
        /// <param name="index">Array index of the server settings.</param>
        /// <param name="inputVariables">Dictionary of the variables and the corresponding values.</param>
        /// <return>The server URL.</return>
        public string GetServerUrl(int index, Dictionary<string, string> inputVariables)
        {
            return GetServerUrl(Servers, index, inputVariables);
        }

        /// <summary>
        /// Returns URL based on operation server settings.
        /// </summary>
        /// <param name="operation">Operation associated with the request path.</param>
        /// <param name="index">Array index of the server settings.</param>
        /// <return>The operation server URL.</return>
        public string GetOperationServerUrl(string operation, int index)
        {
            return GetOperationServerUrl(operation, index, null);
        }

        /// <summary>
        /// Returns URL based on operation server settings.
        /// </summary>
        /// <param name="operation">Operation associated with the request path.</param>
        /// <param name="index">Array index of the server settings.</param>
        /// <param name="inputVariables">Dictionary of the variables and the corresponding values.</param>
        /// <return>The operation server URL.</return>
        public string GetOperationServerUrl(string operation, int index, Dictionary<string, string> inputVariables)
        {
            if (operation != null && OperationServers.TryGetValue(operation, out var operationServer))
            {
                return GetServerUrl(operationServer, index, inputVariables);
            }

            return null;
        }

        /// <summary>
        /// Returns URL based on server settings.
        /// </summary>
        /// <param name="servers">Dictionary of server settings.</param>
        /// <param name="index">Array index of the server settings.</param>
        /// <param name="inputVariables">Dictionary of the variables and the corresponding values.</param>
        /// <return>The server URL.</return>
        private static string GetServerUrl(IList<IReadOnlyDictionary<string, object>> servers, int index, Dictionary<string, string> inputVariables)
        {
            if (index < 0 || index >= servers.Count)
            {
                throw new InvalidOperationException($"Invalid index {index} when selecting the server. Must be less than {servers.Count}.");
            }

            inputVariables ??= [];

            IReadOnlyDictionary<string, object> server = servers[index];
            string url = (string)server["url"];

            if (server.ContainsKey("variables"))
            {
                // go through each variable and assign a value
                foreach (KeyValuePair<string, object> variable in (IReadOnlyDictionary<string, object>)server["variables"])
                {

                    IReadOnlyDictionary<string, object> serverVariables = (IReadOnlyDictionary<string, object>)variable.Value;

                    if (inputVariables.TryGetValue(variable.Key, out var value))
                    {
                        url = ((List<string>)serverVariables["enum_values"]).Contains(value)
                            ? url.Replace("{" + variable.Key + "}", value)
                            : throw new InvalidOperationException($"The variable `{variable.Key}` in the server URL has invalid value #{value}. Must be {(List<string>)serverVariables["enum_values"]}");
                    }
                    else
                    {
                        // use default value
                        url = url.Replace("{" + variable.Key + "}", (string)serverVariables["default_value"]);
                    }
                }
            }

            return url;
        }

        /// <summary>
        /// Gets and Sets the RemoteCertificateValidationCallback
        /// </summary>
        public RemoteCertificateValidationCallback RemoteCertificateValidationCallback { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Returns a string with essential information for debugging.
        /// </summary>
        public static string ToDebugReport()
        {
            string report = "C# SDK (SpaceTraders) Debug Report:\n";
            report += "    OS: " + System.Environment.OSVersion + "\n";
            report += "    .NET Framework Version: " + System.Environment.Version + "\n";
            report += "    Version of the API: 2.0.0\n";
            report += "    SDK Package Version: 1.0.0\n";

            return report;
        }

        /// <summary>
        /// Add Api Key Header.
        /// </summary>
        /// <param name="key">Api Key name.</param>
        /// <param name="value">Api Key value.</param>
        /// <returns></returns>
        public void AddApiKey(string key, string value)
        {
            ApiKey[key] = value;
        }

        /// <summary>
        /// Sets the API key prefix.
        /// </summary>
        /// <param name="key">Api Key name.</param>
        /// <param name="value">Api Key value.</param>
        public void AddApiKeyPrefix(string key, string value)
        {
            ApiKeyPrefix[key] = value;
        }

        #endregion Methods

        #region Static Members
        /// <summary>
        /// Merge configurations.
        /// </summary>
        /// <param name="first">First configuration.</param>
        /// <param name="second">Second configuration.</param>
        /// <return>Merged configuration.</return>
        public static IReadableConfiguration MergeConfigurations(IReadableConfiguration first, IReadableConfiguration second)
        {
            if (second == null) return first ?? GlobalConfiguration.Instance;

            Dictionary<string, string> apiKey = first.ApiKey.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Dictionary<string, string> apiKeyPrefix = first.ApiKeyPrefix.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Dictionary<string, string> defaultHeaders = first.DefaultHeaders.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var kvp in second.ApiKey) apiKey[kvp.Key] = kvp.Value;
            foreach (var kvp in second.ApiKeyPrefix) apiKeyPrefix[kvp.Key] = kvp.Value;
            foreach (var kvp in second.DefaultHeaders) defaultHeaders[kvp.Key] = kvp.Value;

            var config = new Configuration
            {
                ApiKey = apiKey,
                ApiKeyPrefix = apiKeyPrefix,
                DefaultHeaders = defaultHeaders,
                BasePath = second.BasePath ?? first.BasePath,
                Timeout = second.Timeout,
                Proxy = second.Proxy ?? first.Proxy,
                UserAgent = second.UserAgent ?? first.UserAgent,
                Username = second.Username ?? first.Username,
                Password = second.Password ?? first.Password,
                AccessToken = second.AccessToken ?? first.AccessToken,
                TempFolderPath = second.TempFolderPath ?? first.TempFolderPath,
                DateTimeFormat = second.DateTimeFormat ?? first.DateTimeFormat,
                ClientCertificates = second.ClientCertificates ?? first.ClientCertificates,
                UseDefaultCredentials = second.UseDefaultCredentials,
                RemoteCertificateValidationCallback = second.RemoteCertificateValidationCallback ?? first.RemoteCertificateValidationCallback,
            };
            return config;
        }
        #endregion Static Members
    }
}
