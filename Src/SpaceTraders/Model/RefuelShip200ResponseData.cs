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
    /// RefuelShip200ResponseData
    /// </summary>
    [DataContract(Name = "refuel_ship_200_response_data")]
    public partial class RefuelShip200ResponseData : IEquatable<RefuelShip200ResponseData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RefuelShip200ResponseData" /> class.
        /// </summary>
        [JsonConstructor]
        protected RefuelShip200ResponseData() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RefuelShip200ResponseData" /> class.
        /// </summary>
        /// <param name="agent">agent (required).</param>
        /// <param name="fuel">fuel (required).</param>
        /// <param name="transaction">transaction (required).</param>
        public RefuelShip200ResponseData(Agent? agent = default, ShipFuel? fuel = default, MarketTransaction? transaction = default)
        {
            // to ensure "agent" is required (not null)
            if (agent == null)
            {
                throw new ArgumentNullException("agent is a required property for RefuelShip200ResponseData and cannot be null");
            }

            this.Agent = agent;
            // to ensure "fuel" is required (not null)
            if (fuel == null)
            {
                throw new ArgumentNullException("fuel is a required property for RefuelShip200ResponseData and cannot be null");
            }

            this.Fuel = fuel;
            // to ensure "transaction" is required (not null)
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction is a required property for RefuelShip200ResponseData and cannot be null");
            }

            this.Transaction = transaction;
        }

        /// <summary>
        /// Gets or Sets Agent
        /// </summary>
        [DataMember(Name = "agent", IsRequired = true, EmitDefaultValue = true)]
        public Agent Agent { get; set; }

        /// <summary>
        /// Gets or Sets Fuel
        /// </summary>
        [DataMember(Name = "fuel", IsRequired = true, EmitDefaultValue = true)]
        public ShipFuel Fuel { get; set; }

        /// <summary>
        /// Gets or Sets Transaction
        /// </summary>
        [DataMember(Name = "transaction", IsRequired = true, EmitDefaultValue = true)]
        public MarketTransaction Transaction { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class RefuelShip200ResponseData {\n");
            sb.Append("  Agent: ").Append(Agent).Append('\n');
            sb.Append("  Fuel: ").Append(Fuel).Append('\n');
            sb.Append("  Transaction: ").Append(Transaction).Append('\n');
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
            return this.Equals(input as RefuelShip200ResponseData);
        }

        /// <summary>
        /// Returns true if RefuelShip200ResponseData instances are equal
        /// </summary>
        /// <param name="input">Instance of RefuelShip200ResponseData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RefuelShip200ResponseData input)
        {
            if (input == null)
            {
                return false;
            }

            return 
                (
                    this.Agent == input.Agent ||
                    (this.Agent != null &&
                    this.Agent.Equals(input.Agent))
                ) && 
                (
                    this.Fuel == input.Fuel ||
                    (this.Fuel != null &&
                    this.Fuel.Equals(input.Fuel))
                ) && 
                (
                    this.Transaction == input.Transaction ||
                    (this.Transaction != null &&
                    this.Transaction.Equals(input.Transaction))
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
                if (this.Agent != null)
                {
                    hashCode = (hashCode * 59) + this.Agent.GetHashCode();
                }

                if (this.Fuel != null)
                {
                    hashCode = (hashCode * 59) + this.Fuel.GetHashCode();
                }

                if (this.Transaction != null)
                {
                    hashCode = (hashCode * 59) + this.Transaction.GetHashCode();
                }

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
            yield break;
        }
    }
}
