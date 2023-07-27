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
    /// Yields from the extract operation.
    /// </summary>
    [DataContract(Name = "ExtractionYield")]
    public partial class ExtractionYield : IEquatable<ExtractionYield>, IValidatableObject
    {

        /// <summary>
        /// Gets or Sets Symbol
        /// </summary>
        [DataMember(Name = "symbol", IsRequired = true, EmitDefaultValue = true)]
        public TradeSymbol Symbol { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractionYield" /> class.
        /// </summary>
        [JsonConstructor]
        protected ExtractionYield() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractionYield" /> class.
        /// </summary>
        /// <param name="symbol">symbol (required).</param>
        /// <param name="units">The number of units extracted that were placed into the ship&#39;s cargo hold. (required).</param>
        public ExtractionYield(TradeSymbol symbol = default, int units = default)
        {
            this.Symbol = symbol;
            this.Units = units;
        }

        /// <summary>
        /// The number of units extracted that were placed into the ship&#39;s cargo hold.
        /// </summary>
        /// <value>The number of units extracted that were placed into the ship&#39;s cargo hold.</value>
        [DataMember(Name = "units", IsRequired = true, EmitDefaultValue = true)]
        public int Units { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ExtractionYield {\n");
            sb.Append("  Symbol: ").Append(Symbol).Append('\n');
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
            return this.Equals(input as ExtractionYield);
        }

        /// <summary>
        /// Returns true if ExtractionYield instances are equal
        /// </summary>
        /// <param name="input">Instance of ExtractionYield to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ExtractionYield input)
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
            return HashCode.Combine(this.Symbol, this.Units);
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