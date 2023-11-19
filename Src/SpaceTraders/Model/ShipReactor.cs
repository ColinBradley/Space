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
    /// The reactor of the ship. The reactor is responsible for powering the ship&#39;s systems and weapons.
    /// </summary>
    [DataContract(Name = "ShipReactor")]
    public partial class ShipReactor : IEquatable<ShipReactor>, IValidatableObject
    {
        /// <summary>
        /// Symbol of the reactor.
        /// </summary>
        /// <value>Symbol of the reactor.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SymbolEnum
        {
            /// <summary>
            /// Enum SOLARI for value: REACTOR_SOLAR_I
            /// </summary>
            [EnumMember(Value = "REACTOR_SOLAR_I")]
            SOLARI = 1,

            /// <summary>
            /// Enum FUSIONI for value: REACTOR_FUSION_I
            /// </summary>
            [EnumMember(Value = "REACTOR_FUSION_I")]
            FUSIONI = 2,

            /// <summary>
            /// Enum FISSIONI for value: REACTOR_FISSION_I
            /// </summary>
            [EnumMember(Value = "REACTOR_FISSION_I")]
            FISSIONI = 3,

            /// <summary>
            /// Enum CHEMICALI for value: REACTOR_CHEMICAL_I
            /// </summary>
            [EnumMember(Value = "REACTOR_CHEMICAL_I")]
            CHEMICALI = 4,

            /// <summary>
            /// Enum ANTIMATTERI for value: REACTOR_ANTIMATTER_I
            /// </summary>
            [EnumMember(Value = "REACTOR_ANTIMATTER_I")]
            ANTIMATTERI = 5
        }

        /// <summary>
        /// Symbol of the reactor.
        /// </summary>
        /// <value>Symbol of the reactor.</value>
        [DataMember(Name = "symbol", IsRequired = true, EmitDefaultValue = true)]
        public SymbolEnum Symbol { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipReactor" /> class.
        /// </summary>
        [JsonConstructor]
        protected ShipReactor() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipReactor" /> class.
        /// </summary>
        /// <param name="symbol">Symbol of the reactor. (required).</param>
        /// <param name="name">Name of the reactor. (required).</param>
        /// <param name="description">Description of the reactor. (required).</param>
        /// <param name="condition">Condition is a range of 0 to 100 where 0 is completely worn out and 100 is brand new..</param>
        /// <param name="powerOutput">The amount of power provided by this reactor. The more power a reactor provides to the ship, the lower the cooldown it gets when using a module or mount that taxes the ship&#39;s power. (required).</param>
        /// <param name="requirements">requirements (required).</param>
        public ShipReactor(SymbolEnum symbol = default, string? name = default, string? description = default, int condition = default, int powerOutput = default, ShipRequirements? requirements = default)
        {
            this.Symbol = symbol;
            // to ensure "name" is required (not null)
            ArgumentNullException.ThrowIfNull(name);

            this.Name = name;
            // to ensure "description" is required (not null)
            ArgumentNullException.ThrowIfNull(description);

            this.Description = description;
            this.PowerOutput = powerOutput;
            // to ensure "requirements" is required (not null)
            ArgumentNullException.ThrowIfNull(requirements);

            this.Requirements = requirements;
            this.Condition = condition;
        }

        /// <summary>
        /// Name of the reactor.
        /// </summary>
        /// <value>Name of the reactor.</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Description of the reactor.
        /// </summary>
        /// <value>Description of the reactor.</value>
        [DataMember(Name = "description", IsRequired = true, EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// Condition is a range of 0 to 100 where 0 is completely worn out and 100 is brand new.
        /// </summary>
        /// <value>Condition is a range of 0 to 100 where 0 is completely worn out and 100 is brand new.</value>
        [DataMember(Name = "condition", EmitDefaultValue = false)]
        public int Condition { get; set; }

        /// <summary>
        /// The amount of power provided by this reactor. The more power a reactor provides to the ship, the lower the cooldown it gets when using a module or mount that taxes the ship&#39;s power.
        /// </summary>
        /// <value>The amount of power provided by this reactor. The more power a reactor provides to the ship, the lower the cooldown it gets when using a module or mount that taxes the ship&#39;s power.</value>
        [DataMember(Name = "powerOutput", IsRequired = true, EmitDefaultValue = true)]
        public int PowerOutput { get; set; }

        /// <summary>
        /// Gets or Sets Requirements
        /// </summary>
        [DataMember(Name = "requirements", IsRequired = true, EmitDefaultValue = true)]
        public ShipRequirements Requirements { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ShipReactor {\n");
            sb.Append("  Symbol: ").Append(Symbol).Append('\n');
            sb.Append("  Name: ").Append(Name).Append('\n');
            sb.Append("  Description: ").Append(Description).Append('\n');
            sb.Append("  Condition: ").Append(Condition).Append('\n');
            sb.Append("  PowerOutput: ").Append(PowerOutput).Append('\n');
            sb.Append("  Requirements: ").Append(Requirements).Append('\n');
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
            return this.Equals(input as ShipReactor);
        }

        /// <summary>
        /// Returns true if ShipReactor instances are equal
        /// </summary>
        /// <param name="input">Instance of ShipReactor to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ShipReactor input)
        {
            if (input == null)
            {
                return false;
            }

            return 
                (
                    this.Symbol == input.Symbol ||
                    this.Symbol.Equals(input.Symbol)
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
                    this.Condition == input.Condition ||
                    this.Condition.Equals(input.Condition)
                ) && 
                (
                    this.PowerOutput == input.PowerOutput ||
                    this.PowerOutput.Equals(input.PowerOutput)
                ) && 
                (
                    this.Requirements == input.Requirements ||
                    (this.Requirements != null &&
                    this.Requirements.Equals(input.Requirements))
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
                hashCode = (hashCode * 59) + this.Symbol.GetHashCode();
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }

                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }

                hashCode = (hashCode * 59) + this.Condition.GetHashCode();
                hashCode = (hashCode * 59) + this.PowerOutput.GetHashCode();
                if (this.Requirements != null)
                {
                    hashCode = (hashCode * 59) + this.Requirements.GetHashCode();
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
            // Condition (int) maximum
            if (this.Condition > (int)100)
            {
                yield return new ValidationResult("Invalid value for Condition, must be a value less than or equal to 100.", new [] { "Condition" });
            }

            // Condition (int) minimum
            if (this.Condition < (int)0)
            {
                yield return new ValidationResult("Invalid value for Condition, must be a value greater than or equal to 0.", new [] { "Condition" });
            }

            // PowerOutput (int) minimum
            if (this.PowerOutput < (int)1)
            {
                yield return new ValidationResult("Invalid value for PowerOutput, must be a value greater than or equal to 1.", new [] { "PowerOutput" });
            }

            yield break;
        }
    }
}
