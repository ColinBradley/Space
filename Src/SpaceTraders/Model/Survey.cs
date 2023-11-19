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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace SpaceTraders.Model
{
    /// <summary>
    /// A resource survey of a waypoint, detailing a specific extraction location and the types of resources that can be found there.
    /// </summary>
    [DataContract(Name = "Survey")]
    public partial class Survey : IEquatable<Survey>, IValidatableObject
    {
        /// <summary>
        /// The size of the deposit. This value indicates how much can be extracted from the survey before it is exhausted.
        /// </summary>
        /// <value>The size of the deposit. This value indicates how much can be extracted from the survey before it is exhausted.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SizeEnum
        {
            /// <summary>
            /// Enum SMALL for value: SMALL
            /// </summary>
            [EnumMember(Value = "SMALL")]
            SMALL = 1,

            /// <summary>
            /// Enum MODERATE for value: MODERATE
            /// </summary>
            [EnumMember(Value = "MODERATE")]
            MODERATE = 2,

            /// <summary>
            /// Enum LARGE for value: LARGE
            /// </summary>
            [EnumMember(Value = "LARGE")]
            LARGE = 3
        }

        /// <summary>
        /// The size of the deposit. This value indicates how much can be extracted from the survey before it is exhausted.
        /// </summary>
        /// <value>The size of the deposit. This value indicates how much can be extracted from the survey before it is exhausted.</value>
        [DataMember(Name = "size", IsRequired = true, EmitDefaultValue = true)]
        public SizeEnum Size { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Survey" /> class.
        /// </summary>
        [JsonConstructor]
        protected Survey() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Survey" /> class.
        /// </summary>
        /// <param name="signature">A unique signature for the location of this survey. This signature is verified when attempting an extraction using this survey. (required).</param>
        /// <param name="symbol">The symbol of the waypoint that this survey is for. (required).</param>
        /// <param name="deposits">A list of deposits that can be found at this location. (required).</param>
        /// <param name="expiration">The date and time when the survey expires. After this date and time, the survey will no longer be available for extraction. (required).</param>
        /// <param name="size">The size of the deposit. This value indicates how much can be extracted from the survey before it is exhausted. (required).</param>
        public Survey(string? signature = default, string? symbol = default, List<SurveyDeposit>? deposits = default, DateTime expiration = default, SizeEnum size = default)
        {
            // to ensure "signature" is required (not null)
            ArgumentNullException.ThrowIfNull(signature);

            this.Signature = signature;
            // to ensure "symbol" is required (not null)
            ArgumentNullException.ThrowIfNull(symbol);

            this.Symbol = symbol;
            // to ensure "deposits" is required (not null)
            ArgumentNullException.ThrowIfNull(deposits);

            this.Deposits = deposits;
            this.Expiration = expiration;
            this.Size = size;
        }

        /// <summary>
        /// A unique signature for the location of this survey. This signature is verified when attempting an extraction using this survey.
        /// </summary>
        /// <value>A unique signature for the location of this survey. This signature is verified when attempting an extraction using this survey.</value>
        [DataMember(Name = "signature", IsRequired = true, EmitDefaultValue = true)]
        public string Signature { get; set; }

        /// <summary>
        /// The symbol of the waypoint that this survey is for.
        /// </summary>
        /// <value>The symbol of the waypoint that this survey is for.</value>
        [DataMember(Name = "symbol", IsRequired = true, EmitDefaultValue = true)]
        public string Symbol { get; set; }

        /// <summary>
        /// A list of deposits that can be found at this location.
        /// </summary>
        /// <value>A list of deposits that can be found at this location.</value>
        [DataMember(Name = "deposits", IsRequired = true, EmitDefaultValue = true)]
        public List<SurveyDeposit> Deposits { get; set; }

        /// <summary>
        /// The date and time when the survey expires. After this date and time, the survey will no longer be available for extraction.
        /// </summary>
        /// <value>The date and time when the survey expires. After this date and time, the survey will no longer be available for extraction.</value>
        [DataMember(Name = "expiration", IsRequired = true, EmitDefaultValue = true)]
        public DateTime Expiration { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Survey {\n");
            sb.Append("  Signature: ").Append(Signature).Append('\n');
            sb.Append("  Symbol: ").Append(Symbol).Append('\n');
            sb.Append("  Deposits: ").Append(Deposits).Append('\n');
            sb.Append("  Expiration: ").Append(Expiration).Append('\n');
            sb.Append("  Size: ").Append(Size).Append('\n');
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Survey);
        }

        /// <summary>
        /// Returns true if Survey instances are equal
        /// </summary>
        /// <param name="input">Instance of Survey to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Survey input)
        {
            if (input == null)
            {
                return false;
            }

            return 
                (
                    this.Signature == input.Signature ||
                    (this.Signature != null &&
                    this.Signature.Equals(input.Signature))
                ) && 
                (
                    this.Symbol == input.Symbol ||
                    (this.Symbol != null &&
                    this.Symbol.Equals(input.Symbol))
                ) && 
                (
                    this.Deposits == input.Deposits ||
                    this.Deposits != null &&
                    input.Deposits != null &&
                    this.Deposits.SequenceEqual(input.Deposits)
                ) && 
                (
                    this.Expiration == input.Expiration ||
                    this.Expiration.Equals(input.Expiration)
                ) && 
                (
                    this.Size == input.Size ||
                    this.Size.Equals(input.Size)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Signature != null)
                {
                    hashCode = (hashCode * 59) + this.Signature.GetHashCode();
                }

                if (this.Symbol != null)
                {
                    hashCode = (hashCode * 59) + this.Symbol.GetHashCode();
                }

                if (this.Deposits != null)
                {
                    hashCode = (hashCode * 59) + this.Deposits.GetHashCode();
                }

                hashCode = (hashCode * 59) + this.Expiration.GetHashCode();

                hashCode = (hashCode * 59) + this.Size.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            // Signature (string) minLength
            if (this.Signature != null && this.Signature.Length < 1)
            {
                yield return new ValidationResult("Invalid value for Signature, length must be greater than 1.", new [] { "Signature" });
            }

            // Symbol (string) minLength
            if (this.Symbol != null && this.Symbol.Length < 1)
            {
                yield return new ValidationResult("Invalid value for Symbol, length must be greater than 1.", new [] { "Symbol" });
            }

            yield break;
        }
    }
}
