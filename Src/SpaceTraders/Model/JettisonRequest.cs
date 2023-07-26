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
    /// JettisonRequest
    /// </summary>
    [DataContract(Name = "jettison_request")]
    public partial class JettisonRequest : IEquatable<JettisonRequest>, IValidatableObject
    {

        /// <summary>
        /// Gets or Sets Symbol
        /// </summary>
        [DataMember(Name = "symbol", IsRequired = true, EmitDefaultValue = true)]
        public TradeSymbol Symbol { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="JettisonRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected JettisonRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="JettisonRequest" /> class.
        /// </summary>
        /// <param name="symbol">symbol (required).</param>
        /// <param name="units">Amount of units to jettison of this good. (required).</param>
        public JettisonRequest(TradeSymbol symbol = default, int units = default)
        {
            this.Symbol = symbol;
            this.Units = units;
        }

        /// <summary>
        /// Amount of units to jettison of this good.
        /// </summary>
        /// <value>Amount of units to jettison of this good.</value>
        [DataMember(Name = "units", IsRequired = true, EmitDefaultValue = true)]
        public int Units { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class JettisonRequest {\n");
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
            return this.Equals(input as JettisonRequest);
        }

        /// <summary>
        /// Returns true if JettisonRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of JettisonRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(JettisonRequest input)
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
            // Units (int) minimum
            if (this.Units < (int)1)
            {
                yield return new ValidationResult("Invalid value for Units, must be a value greater than or equal to 1.", new [] { "Units" });
            }

            yield break;
        }
    }
}
