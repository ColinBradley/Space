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
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace SpaceTraders.Model
{
    /// <summary>
    /// The ship&#39;s crew service and maintain the ship&#39;s systems and equipment.
    /// </summary>
    [DataContract(Name = "ShipCrew")]
    public partial class ShipCrew : IEquatable<ShipCrew>, IValidatableObject
    {
        /// <summary>
        /// The rotation of crew shifts. A stricter shift improves the ship&#39;s performance. A more relaxed shift improves the crew&#39;s morale.
        /// </summary>
        /// <value>The rotation of crew shifts. A stricter shift improves the ship&#39;s performance. A more relaxed shift improves the crew&#39;s morale.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RotationEnum
        {
            /// <summary>
            /// Enum STRICT for value: STRICT
            /// </summary>
            [EnumMember(Value = "STRICT")]
            STRICT = 1,

            /// <summary>
            /// Enum RELAXED for value: RELAXED
            /// </summary>
            [EnumMember(Value = "RELAXED")]
            RELAXED = 2
        }

        /// <summary>
        /// The rotation of crew shifts. A stricter shift improves the ship&#39;s performance. A more relaxed shift improves the crew&#39;s morale.
        /// </summary>
        /// <value>The rotation of crew shifts. A stricter shift improves the ship&#39;s performance. A more relaxed shift improves the crew&#39;s morale.</value>
        [DataMember(Name = "rotation", IsRequired = true, EmitDefaultValue = true)]
        public RotationEnum Rotation { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipCrew" /> class.
        /// </summary>
        [JsonConstructor]
        protected ShipCrew() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipCrew" /> class.
        /// </summary>
        /// <param name="current">The current number of crew members on the ship. (required).</param>
        /// <param name="required">The minimum number of crew members required to maintain the ship. (required).</param>
        /// <param name="capacity">The maximum number of crew members the ship can support. (required).</param>
        /// <param name="rotation">The rotation of crew shifts. A stricter shift improves the ship&#39;s performance. A more relaxed shift improves the crew&#39;s morale. (required) (default to RotationEnum.STRICT).</param>
        /// <param name="morale">A rough measure of the crew&#39;s morale. A higher morale means the crew is happier and more productive. A lower morale means the ship is more prone to accidents. (required).</param>
        /// <param name="wages">The amount of credits per crew member paid per hour. Wages are paid when a ship docks at a civilized waypoint. (required).</param>
        public ShipCrew(int current = default, int required = default, int capacity = default, RotationEnum rotation = RotationEnum.STRICT, int morale = default, int wages = default)
        {
            this.Current = current;
            this.Required = required;
            this.Capacity = capacity;
            this.Rotation = rotation;
            this.Morale = morale;
            this.Wages = wages;
        }

        /// <summary>
        /// The current number of crew members on the ship.
        /// </summary>
        /// <value>The current number of crew members on the ship.</value>
        [DataMember(Name = "current", IsRequired = true, EmitDefaultValue = true)]
        public int Current { get; set; }

        /// <summary>
        /// The minimum number of crew members required to maintain the ship.
        /// </summary>
        /// <value>The minimum number of crew members required to maintain the ship.</value>
        [DataMember(Name = "required", IsRequired = true, EmitDefaultValue = true)]
        public int Required { get; set; }

        /// <summary>
        /// The maximum number of crew members the ship can support.
        /// </summary>
        /// <value>The maximum number of crew members the ship can support.</value>
        [DataMember(Name = "capacity", IsRequired = true, EmitDefaultValue = true)]
        public int Capacity { get; set; }

        /// <summary>
        /// A rough measure of the crew&#39;s morale. A higher morale means the crew is happier and more productive. A lower morale means the ship is more prone to accidents.
        /// </summary>
        /// <value>A rough measure of the crew&#39;s morale. A higher morale means the crew is happier and more productive. A lower morale means the ship is more prone to accidents.</value>
        [DataMember(Name = "morale", IsRequired = true, EmitDefaultValue = true)]
        public int Morale { get; set; }

        /// <summary>
        /// The amount of credits per crew member paid per hour. Wages are paid when a ship docks at a civilized waypoint.
        /// </summary>
        /// <value>The amount of credits per crew member paid per hour. Wages are paid when a ship docks at a civilized waypoint.</value>
        [DataMember(Name = "wages", IsRequired = true, EmitDefaultValue = true)]
        public int Wages { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ShipCrew {\n");
            sb.Append("  Current: ").Append(Current).Append('\n');
            sb.Append("  Required: ").Append(Required).Append('\n');
            sb.Append("  Capacity: ").Append(Capacity).Append('\n');
            sb.Append("  Rotation: ").Append(Rotation).Append('\n');
            sb.Append("  Morale: ").Append(Morale).Append('\n');
            sb.Append("  Wages: ").Append(Wages).Append('\n');
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
            return this.Equals(input as ShipCrew);
        }

        /// <summary>
        /// Returns true if ShipCrew instances are equal
        /// </summary>
        /// <param name="input">Instance of ShipCrew to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ShipCrew input)
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
                    this.Required == input.Required ||
                    this.Required.Equals(input.Required)
                ) && 
                (
                    this.Capacity == input.Capacity ||
                    this.Capacity.Equals(input.Capacity)
                ) && 
                (
                    this.Rotation == input.Rotation ||
                    this.Rotation.Equals(input.Rotation)
                ) && 
                (
                    this.Morale == input.Morale ||
                    this.Morale.Equals(input.Morale)
                ) && 
                (
                    this.Wages == input.Wages ||
                    this.Wages.Equals(input.Wages)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Current, this.Required, this.Capacity, this.Rotation, this.Morale, this.Wages);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            // Morale (int) maximum
            if (this.Morale > (int)100)
            {
                yield return new ValidationResult("Invalid value for Morale, must be a value less than or equal to 100.", new [] { "Morale" });
            }

            // Morale (int) minimum
            if (this.Morale < (int)0)
            {
                yield return new ValidationResult("Invalid value for Morale, must be a value greater than or equal to 0.", new [] { "Morale" });
            }

            // Wages (int) minimum
            if (this.Wages < (int)0)
            {
                yield return new ValidationResult("Invalid value for Wages, must be a value greater than or equal to 0.", new [] { "Wages" });
            }

            yield break;
        }
    }
}
