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
    /// The type of cargo item and the number of units.
    /// </summary>
    [DataContract(Name = "ShipCargoItem")]
    public partial class ShipCargoItem : IEquatable<ShipCargoItem>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipCargoItem" /> class.
        /// </summary>
        [JsonConstructor]
        protected ShipCargoItem() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipCargoItem" /> class.
        /// </summary>
        /// <param name="symbol">The unique identifier of the cargo item type. (required).</param>
        /// <param name="name">The name of the cargo item type. (required).</param>
        /// <param name="description">The description of the cargo item type. (required).</param>
        /// <param name="units">The number of units of the cargo item. (required).</param>
        public ShipCargoItem(TradeSymbol symbol = default, string? name = default, string? description = default, int units = default)
        {
            this.Symbol = symbol;
            // to ensure "name" is required (not null)
            ArgumentNullException.ThrowIfNull(name);

            this.Name = name;
            // to ensure "description" is required (not null)
            ArgumentNullException.ThrowIfNull(description);

            this.Description = description;
            this.Units = units;
        }

        /// <summary>
        /// The unique identifier of the cargo item type.
        /// </summary>
        /// <value>The unique identifier of the cargo item type.</value>
        [DataMember(Name = "symbol", IsRequired = true, EmitDefaultValue = true)]
        public TradeSymbol Symbol { get; set; }

        /// <summary>
        /// The name of the cargo item type.
        /// </summary>
        /// <value>The name of the cargo item type.</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// The description of the cargo item type.
        /// </summary>
        /// <value>The description of the cargo item type.</value>
        [DataMember(Name = "description", IsRequired = true, EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// The number of units of the cargo item.
        /// </summary>
        /// <value>The number of units of the cargo item.</value>
        [DataMember(Name = "units", IsRequired = true, EmitDefaultValue = true)]
        public int Units { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ShipCargoItem {\n");
            sb.Append("  Symbol: ").Append(Symbol).Append('\n');
            sb.Append("  Name: ").Append(Name).Append('\n');
            sb.Append("  Description: ").Append(Description).Append('\n');
            sb.Append("  Units: ").Append(Units).Append('\n');
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
            return this.Equals(input as ShipCargoItem);
        }

        /// <summary>
        /// Returns true if ShipCargoItem instances are equal
        /// </summary>
        /// <param name="input">Instance of ShipCargoItem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ShipCargoItem input)
        {
            if (input == null)
            {
                return false;
            }

            return
                (
                    this.Symbol == input.Symbol ||
                    (this.Symbol != null &&
                    this.Symbol.Equals(input.Symbol))
                ) &&
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) &&
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) &&
                (
                    this.Units == input.Units ||
                    this.Units.Equals(input.Units)
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
                if (this.Symbol != null)
                {
                    hashCode = (hashCode * 59) + this.Symbol.GetHashCode();
                }

                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }

                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }

                hashCode = (hashCode * 59) + this.Units.GetHashCode();
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
            // Units (int) minimum
            if (this.Units < (int)1)
            {
                yield return new ValidationResult("Invalid value for Units, must be a value greater than or equal to 1.", new[] { "Units" });
            }

            yield break;
        }
    }
}
