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
    /// Details of the ship&#39;s fuel tanks including how much fuel was consumed during the last transit or action.
    /// </summary>
    [DataContract(Name = "ShipFuel")]
    public partial class ShipFuel : IEquatable<ShipFuel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipFuel" /> class.
        /// </summary>
        [JsonConstructor]
        protected ShipFuel() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipFuel" /> class.
        /// </summary>
        /// <param name="current">The current amount of fuel in the ship&#39;s tanks. (required).</param>
        /// <param name="capacity">The maximum amount of fuel the ship&#39;s tanks can hold. (required).</param>
        /// <param name="consumed">consumed.</param>
        public ShipFuel(int current = default, int capacity = default, ShipFuelConsumed? consumed = default)
        {
            this.Current = current;
            this.Capacity = capacity;
            this.Consumed = consumed;
        }

        /// <summary>
        /// The current amount of fuel in the ship&#39;s tanks.
        /// </summary>
        /// <value>The current amount of fuel in the ship&#39;s tanks.</value>
        [DataMember(Name = "current", IsRequired = true, EmitDefaultValue = true)]
        public int Current { get; set; }

        /// <summary>
        /// The maximum amount of fuel the ship&#39;s tanks can hold.
        /// </summary>
        /// <value>The maximum amount of fuel the ship&#39;s tanks can hold.</value>
        [DataMember(Name = "capacity", IsRequired = true, EmitDefaultValue = true)]
        public int Capacity { get; set; }

        /// <summary>
        /// Gets or Sets Consumed
        /// </summary>
        [DataMember(Name = "consumed", EmitDefaultValue = false)]
        public ShipFuelConsumed Consumed { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ShipFuel {\n");
            sb.Append("  Current: ").Append(Current).Append('\n');
            sb.Append("  Capacity: ").Append(Capacity).Append('\n');
            sb.Append("  Consumed: ").Append(Consumed).Append('\n');
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
            return this.Equals(input as ShipFuel);
        }

        /// <summary>
        /// Returns true if ShipFuel instances are equal
        /// </summary>
        /// <param name="input">Instance of ShipFuel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ShipFuel input)
        {
            if (input == null)
            {
                return false;
            }

            return 
                (
                    this.Current == input.Current ||
                    this.Current.Equals(input.Current)
                ) && 
                (
                    this.Capacity == input.Capacity ||
                    this.Capacity.Equals(input.Capacity)
                ) && 
                (
                    this.Consumed == input.Consumed ||
                    (this.Consumed != null &&
                    this.Consumed.Equals(input.Consumed))
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
                hashCode = (hashCode * 59) + this.Current.GetHashCode();
                hashCode = (hashCode * 59) + this.Capacity.GetHashCode();
                if (this.Consumed != null)
                {
                    hashCode = (hashCode * 59) + this.Consumed.GetHashCode();
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
            // Current (int) minimum
            if (this.Current < (int)0)
            {
                yield return new ValidationResult("Invalid value for Current, must be a value greater than or equal to 0.", new [] { "Current" });
            }

            // Capacity (int) minimum
            if (this.Capacity < (int)0)
            {
                yield return new ValidationResult("Invalid value for Capacity, must be a value greater than or equal to 0.", new [] { "Capacity" });
            }

            yield break;
        }
    }
}
