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
using System.ComponentModel.DataAnnotations;

namespace SpaceTraders.Model
{
    /// <summary>
    /// Ship cargo details.
    /// </summary>
    [DataContract(Name = "ShipCargo")]
    public partial class ShipCargo : IEquatable<ShipCargo>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipCargo" /> class.
        /// </summary>
        [JsonConstructor]
        protected ShipCargo() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipCargo" /> class.
        /// </summary>
        /// <param name="capacity">The max number of items that can be stored in the cargo hold. (required).</param>
        /// <param name="units">The number of items currently stored in the cargo hold. (required).</param>
        /// <param name="inventory">The items currently in the cargo hold. (required).</param>
        public ShipCargo(int capacity = default, int units = default, List<ShipCargoItem>? inventory = default)
        {
            this.Capacity = capacity;
            this.Units = units;
            // to ensure "inventory" is required (not null)
            if (inventory == null)
            {
                throw new ArgumentNullException("inventory is a required property for ShipCargo and cannot be null");
            }

            this.Inventory = inventory;
        }

        /// <summary>
        /// The max number of items that can be stored in the cargo hold.
        /// </summary>
        /// <value>The max number of items that can be stored in the cargo hold.</value>
        [DataMember(Name = "capacity", IsRequired = true, EmitDefaultValue = true)]
        public int Capacity { get; set; }

        /// <summary>
        /// The number of items currently stored in the cargo hold.
        /// </summary>
        /// <value>The number of items currently stored in the cargo hold.</value>
        [DataMember(Name = "units", IsRequired = true, EmitDefaultValue = true)]
        public int Units { get; set; }

        /// <summary>
        /// The items currently in the cargo hold.
        /// </summary>
        /// <value>The items currently in the cargo hold.</value>
        [DataMember(Name = "inventory", IsRequired = true, EmitDefaultValue = true)]
        public List<ShipCargoItem> Inventory { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ShipCargo {\n");
            sb.Append("  Capacity: ").Append(Capacity).Append('\n');
            sb.Append("  Units: ").Append(Units).Append('\n');
            sb.Append("  Inventory: ").Append(Inventory).Append('\n');
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
            return this.Equals(input as ShipCargo);
        }

        /// <summary>
        /// Returns true if ShipCargo instances are equal
        /// </summary>
        /// <param name="input">Instance of ShipCargo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ShipCargo input)
        {
            if (input == null)
            {
                return false;
            }

            return 
                (
                    this.Capacity == input.Capacity ||
                    this.Capacity.Equals(input.Capacity)
                ) && 
                (
                    this.Units == input.Units ||
                    this.Units.Equals(input.Units)
                ) && 
                (
                    this.Inventory == input.Inventory ||
                    this.Inventory != null &&
                    input.Inventory != null &&
                    this.Inventory.SequenceEqual(input.Inventory)
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
                hashCode = (hashCode * 59) + this.Capacity.GetHashCode();
                hashCode = (hashCode * 59) + this.Units.GetHashCode();
                if (this.Inventory != null)
                {
                    hashCode = (hashCode * 59) + this.Inventory.GetHashCode();
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
            // Capacity (int) minimum
            if (this.Capacity < (int)0)
            {
                yield return new ValidationResult("Invalid value for Capacity, must be a value greater than or equal to 0.", new [] { "Capacity" });
            }

            // Units (int) minimum
            if (this.Units < (int)0)
            {
                yield return new ValidationResult("Invalid value for Units, must be a value greater than or equal to 0.", new [] { "Units" });
            }

            yield break;
        }
    }
}
