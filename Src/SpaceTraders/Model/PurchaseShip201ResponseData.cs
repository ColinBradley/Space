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
    /// PurchaseShip201ResponseData
    /// </summary>
    [DataContract(Name = "purchase_ship_201_response_data")]
    public partial class PurchaseShip201ResponseData : IEquatable<PurchaseShip201ResponseData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseShip201ResponseData" /> class.
        /// </summary>
        [JsonConstructor]
        protected PurchaseShip201ResponseData() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseShip201ResponseData" /> class.
        /// </summary>
        /// <param name="agent">agent (required).</param>
        /// <param name="ship">ship (required).</param>
        /// <param name="transaction">transaction (required).</param>
        public PurchaseShip201ResponseData(Agent? agent = default, Ship? ship = default, ShipyardTransaction? transaction = default)
        {
            // to ensure "agent" is required (not null)
            ArgumentNullException.ThrowIfNull(agent);

            this.Agent = agent;
            // to ensure "ship" is required (not null)
            ArgumentNullException.ThrowIfNull(ship);

            this.Ship = ship;
            // to ensure "transaction" is required (not null)
            ArgumentNullException.ThrowIfNull(transaction);

            this.Transaction = transaction;
        }

        /// <summary>
        /// Gets or Sets Agent
        /// </summary>
        [DataMember(Name = "agent", IsRequired = true, EmitDefaultValue = true)]
        public Agent Agent { get; set; }

        /// <summary>
        /// Gets or Sets Ship
        /// </summary>
        [DataMember(Name = "ship", IsRequired = true, EmitDefaultValue = true)]
        public Ship Ship { get; set; }

        /// <summary>
        /// Gets or Sets Transaction
        /// </summary>
        [DataMember(Name = "transaction", IsRequired = true, EmitDefaultValue = true)]
        public ShipyardTransaction Transaction { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PurchaseShip201ResponseData {\n");
            sb.Append("  Agent: ").Append(Agent).Append('\n');
            sb.Append("  Ship: ").Append(Ship).Append('\n');
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
            return this.Equals(input as PurchaseShip201ResponseData);
        }

        /// <summary>
        /// Returns true if PurchaseShip201ResponseData instances are equal
        /// </summary>
        /// <param name="input">Instance of PurchaseShip201ResponseData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PurchaseShip201ResponseData input)
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
                    this.Ship == input.Ship ||
                    (this.Ship != null &&
                    this.Ship.Equals(input.Ship))
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

                if (this.Ship != null)
                {
                    hashCode = (hashCode * 59) + this.Ship.GetHashCode();
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
