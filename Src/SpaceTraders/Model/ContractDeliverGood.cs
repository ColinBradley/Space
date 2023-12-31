/*
 * SpaceTraders API
 *
 * SpaceTraders is an open-universe game and learning platform that offers a set of HTTP endpoints to control a fleet of ships and explore a multiplayer universe.  The API is documented using [OpenAPI](https://github.com/SpaceTradersAPI/api-docs). You can send your first request right here in your browser to check the status of the game server.  ```json http {   \"method\": \"GET\",   \"url\": \"https://api.spacetraders.io/v2\", } ```  Unlike a traditional game, SpaceTraders does not have a first-party client or app to play the game. Instead, you can use the API to build your own client, write a script to automate your ships, or try an app built by the community.  We have a [Discord channel](https://discord.com/invite/jh6zurdWk5) where you can share your projects, ask questions, and get help from other players.   
 *
 * The version of the OpenAPI document: 2.0.0
 * Contact: joel@spacetraders.io
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SpaceTraders.Model
{
    /// <summary>
    /// The details of a delivery contract. Includes the type of good, units needed, and the destination.
    /// </summary>
    [DataContract(Name = "ContractDeliverGood")]
    public partial class ContractDeliverGood : IEquatable<ContractDeliverGood>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDeliverGood" /> class.
        /// </summary>
        [JsonConstructor]
        protected ContractDeliverGood() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDeliverGood" /> class.
        /// </summary>
        /// <param name="tradeSymbol">The symbol of the trade good to deliver. (required).</param>
        /// <param name="destinationSymbol">The destination where goods need to be delivered. (required).</param>
        /// <param name="unitsRequired">The number of units that need to be delivered on this contract. (required).</param>
        /// <param name="unitsFulfilled">The number of units fulfilled on this contract. (required).</param>
        public ContractDeliverGood(TradeSymbol tradeSymbol = default, string? destinationSymbol = default, int unitsRequired = default, int unitsFulfilled = default)
        {
            // to ensure "tradeSymbol" is required (not null)
            if (tradeSymbol == null)
            {
                throw new ArgumentNullException("tradeSymbol is a required property for ContractDeliverGood and cannot be null");
            }

            this.TradeSymbol = tradeSymbol;
            // to ensure "destinationSymbol" is required (not null)
            ArgumentNullException.ThrowIfNull(destinationSymbol);

            this.DestinationSymbol = destinationSymbol;
            this.UnitsRequired = unitsRequired;
            this.UnitsFulfilled = unitsFulfilled;
        }

        /// <summary>
        /// The symbol of the trade good to deliver.
        /// </summary>
        /// <value>The symbol of the trade good to deliver.</value>
        [DataMember(Name = "tradeSymbol", IsRequired = true, EmitDefaultValue = true)]
        public TradeSymbol TradeSymbol { get; set; }

        /// <summary>
        /// The destination where goods need to be delivered.
        /// </summary>
        /// <value>The destination where goods need to be delivered.</value>
        [DataMember(Name = "destinationSymbol", IsRequired = true, EmitDefaultValue = true)]
        public string DestinationSymbol { get; set; }

        /// <summary>
        /// The number of units that need to be delivered on this contract.
        /// </summary>
        /// <value>The number of units that need to be delivered on this contract.</value>
        [DataMember(Name = "unitsRequired", IsRequired = true, EmitDefaultValue = true)]
        public int UnitsRequired { get; set; }

        /// <summary>
        /// The number of units fulfilled on this contract.
        /// </summary>
        /// <value>The number of units fulfilled on this contract.</value>
        [DataMember(Name = "unitsFulfilled", IsRequired = true, EmitDefaultValue = true)]
        public int UnitsFulfilled { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ContractDeliverGood {\n");
            sb.Append("  TradeSymbol: ").Append(TradeSymbol).Append('\n');
            sb.Append("  DestinationSymbol: ").Append(DestinationSymbol).Append('\n');
            sb.Append("  UnitsRequired: ").Append(UnitsRequired).Append('\n');
            sb.Append("  UnitsFulfilled: ").Append(UnitsFulfilled).Append('\n');
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
            return this.Equals(input as ContractDeliverGood);
        }

        /// <summary>
        /// Returns true if ContractDeliverGood instances are equal
        /// </summary>
        /// <param name="input">Instance of ContractDeliverGood to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ContractDeliverGood input)
        {
            if (input == null)
            {
                return false;
            }

            return
                (
                    this.TradeSymbol == input.TradeSymbol ||
                    (this.TradeSymbol != null &&
                    this.TradeSymbol.Equals(input.TradeSymbol))
                ) &&
                (
                    this.DestinationSymbol == input.DestinationSymbol ||
                    (this.DestinationSymbol != null &&
                    this.DestinationSymbol.Equals(input.DestinationSymbol))
                ) &&
                (
                    this.UnitsRequired == input.UnitsRequired ||
                    this.UnitsRequired.Equals(input.UnitsRequired)
                ) &&
                (
                    this.UnitsFulfilled == input.UnitsFulfilled ||
                    this.UnitsFulfilled.Equals(input.UnitsFulfilled)
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
                if (this.TradeSymbol != null)
                {
                    hashCode = (hashCode * 59) + this.TradeSymbol.GetHashCode();
                }

                if (this.DestinationSymbol != null)
                {
                    hashCode = (hashCode * 59) + this.DestinationSymbol.GetHashCode();
                }

                hashCode = (hashCode * 59) + this.UnitsRequired.GetHashCode();
                hashCode = (hashCode * 59) + this.UnitsFulfilled.GetHashCode();
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
            // DestinationSymbol (string) minLength
            if (this.DestinationSymbol != null && this.DestinationSymbol.Length < 1)
            {
                yield return new ValidationResult("Invalid value for DestinationSymbol, length must be greater than 1.", new[] { "DestinationSymbol" });
            }

            yield break;
        }
    }
}
