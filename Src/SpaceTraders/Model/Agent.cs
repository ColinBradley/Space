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
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SpaceTraders.Model
{
    /// <summary>
    /// Agent details.
    /// </summary>
    [DataContract(Name = "Agent")]
    public partial class Agent : IEquatable<Agent>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Agent" /> class.
        /// </summary>
        [JsonConstructor]
        protected Agent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Agent" /> class.
        /// </summary>
        /// <param name="accountId">Account ID that is tied to this agent. Only included on your own agent..</param>
        /// <param name="symbol">Symbol of the agent. (required).</param>
        /// <param name="headquarters">The headquarters of the agent. (required).</param>
        /// <param name="credits">The number of credits the agent has available. Credits can be negative if funds have been overdrawn. (required).</param>
        /// <param name="startingFaction">The faction the agent started with. (required).</param>
        /// <param name="shipCount">How many ships are owned by the agent..</param>
        public Agent(string? accountId = default, string? symbol = default, string? headquarters = default, long credits = default, string? startingFaction = default, int shipCount = default)
        {
            // to ensure "symbol" is required (not null)
            ArgumentNullException.ThrowIfNull(symbol);

            this.Symbol = symbol;
            // to ensure "headquarters" is required (not null)
            ArgumentNullException.ThrowIfNull(headquarters);

            this.Headquarters = headquarters;
            this.Credits = credits;
            // to ensure "startingFaction" is required (not null)
            ArgumentNullException.ThrowIfNull(startingFaction);

            this.StartingFaction = startingFaction;
            this.AccountId = accountId;
            this.ShipCount = shipCount;
        }

        /// <summary>
        /// Account ID that is tied to this agent. Only included on your own agent.
        /// </summary>
        /// <value>Account ID that is tied to this agent. Only included on your own agent.</value>
        [DataMember(Name = "accountId", EmitDefaultValue = false)]
        public string AccountId { get; set; }

        /// <summary>
        /// Symbol of the agent.
        /// </summary>
        /// <value>Symbol of the agent.</value>
        [DataMember(Name = "symbol", IsRequired = true, EmitDefaultValue = true)]
        public string Symbol { get; set; }

        /// <summary>
        /// The headquarters of the agent.
        /// </summary>
        /// <value>The headquarters of the agent.</value>
        [DataMember(Name = "headquarters", IsRequired = true, EmitDefaultValue = true)]
        public string Headquarters { get; set; }

        /// <summary>
        /// The number of credits the agent has available. Credits can be negative if funds have been overdrawn.
        /// </summary>
        /// <value>The number of credits the agent has available. Credits can be negative if funds have been overdrawn.</value>
        [DataMember(Name = "credits", IsRequired = true, EmitDefaultValue = true)]
        public long Credits { get; set; }

        /// <summary>
        /// The faction the agent started with.
        /// </summary>
        /// <value>The faction the agent started with.</value>
        [DataMember(Name = "startingFaction", IsRequired = true, EmitDefaultValue = true)]
        public string StartingFaction { get; set; }

        /// <summary>
        /// How many ships are owned by the agent.
        /// </summary>
        /// <value>How many ships are owned by the agent.</value>
        [DataMember(Name = "shipCount", EmitDefaultValue = false)]
        public int ShipCount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Agent {\n");
            sb.Append("  AccountId: ").Append(AccountId).Append('\n');
            sb.Append("  Symbol: ").Append(Symbol).Append('\n');
            sb.Append("  Headquarters: ").Append(Headquarters).Append('\n');
            sb.Append("  Credits: ").Append(Credits).Append('\n');
            sb.Append("  StartingFaction: ").Append(StartingFaction).Append('\n');
            sb.Append("  ShipCount: ").Append(ShipCount).Append('\n');
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
            return this.Equals(input as Agent);
        }

        /// <summary>
        /// Returns true if Agent instances are equal
        /// </summary>
        /// <param name="input">Instance of Agent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Agent input)
        {
            if (input == null)
            {
                return false;
            }

            return 
                (
                    this.AccountId == input.AccountId ||
                    (this.AccountId != null &&
                    this.AccountId.Equals(input.AccountId))
                ) && 
                (
                    this.Symbol == input.Symbol ||
                    (this.Symbol != null &&
                    this.Symbol.Equals(input.Symbol))
                ) && 
                (
                    this.Headquarters == input.Headquarters ||
                    (this.Headquarters != null &&
                    this.Headquarters.Equals(input.Headquarters))
                ) && 
                (
                    this.Credits == input.Credits ||
                    this.Credits.Equals(input.Credits)
                ) && 
                (
                    this.StartingFaction == input.StartingFaction ||
                    (this.StartingFaction != null &&
                    this.StartingFaction.Equals(input.StartingFaction))
                ) && 
                (
                    this.ShipCount == input.ShipCount ||
                    this.ShipCount.Equals(input.ShipCount)
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
                if (this.AccountId != null)
                {
                    hashCode = (hashCode * 59) + this.AccountId.GetHashCode();
                }

                if (this.Symbol != null)
                {
                    hashCode = (hashCode * 59) + this.Symbol.GetHashCode();
                }

                if (this.Headquarters != null)
                {
                    hashCode = (hashCode * 59) + this.Headquarters.GetHashCode();
                }

                hashCode = (hashCode * 59) + this.Credits.GetHashCode();
                if (this.StartingFaction != null)
                {
                    hashCode = (hashCode * 59) + this.StartingFaction.GetHashCode();
                }

                hashCode = (hashCode * 59) + this.ShipCount.GetHashCode();
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
            // AccountId (string) minLength
            if (this.AccountId != null && this.AccountId.Length < 1)
            {
                yield return new ValidationResult("Invalid value for AccountId, length must be greater than 1.", new [] { "AccountId" });
            }

            // Symbol (string) maxLength
            if (this.Symbol != null && this.Symbol.Length > 14)
            {
                yield return new ValidationResult("Invalid value for Symbol, length must be less than 14.", new [] { "Symbol" });
            }

            // Symbol (string) minLength
            if (this.Symbol != null && this.Symbol.Length < 3)
            {
                yield return new ValidationResult("Invalid value for Symbol, length must be greater than 3.", new [] { "Symbol" });
            }

            // Headquarters (string) minLength
            if (this.Headquarters != null && this.Headquarters.Length < 1)
            {
                yield return new ValidationResult("Invalid value for Headquarters, length must be greater than 1.", new [] { "Headquarters" });
            }

            // StartingFaction (string) minLength
            if (this.StartingFaction != null && this.StartingFaction.Length < 1)
            {
                yield return new ValidationResult("Invalid value for StartingFaction, length must be greater than 1.", new [] { "StartingFaction" });
            }

            yield break;
        }
    }
}
