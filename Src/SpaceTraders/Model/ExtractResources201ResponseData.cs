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
    /// ExtractResources201ResponseData
    /// </summary>
    [DataContract(Name = "extract_resources_201_response_data")]
    public partial class ExtractResources201ResponseData : IEquatable<ExtractResources201ResponseData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractResources201ResponseData" /> class.
        /// </summary>
        [JsonConstructor]
        protected ExtractResources201ResponseData() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractResources201ResponseData" /> class.
        /// </summary>
        /// <param name="cooldown">cooldown (required).</param>
        /// <param name="extraction">extraction (required).</param>
        /// <param name="cargo">cargo (required).</param>
        public ExtractResources201ResponseData(Cooldown? cooldown = default, Extraction? extraction = default, ShipCargo? cargo = default)
        {
            // to ensure "cooldown" is required (not null)
            ArgumentNullException.ThrowIfNull(cooldown);

            this.Cooldown = cooldown;
            // to ensure "extraction" is required (not null)
            ArgumentNullException.ThrowIfNull(extraction);

            this.Extraction = extraction;
            // to ensure "cargo" is required (not null)
            ArgumentNullException.ThrowIfNull(cargo);

            this.Cargo = cargo;
        }

        /// <summary>
        /// Gets or Sets Cooldown
        /// </summary>
        [DataMember(Name = "cooldown", IsRequired = true, EmitDefaultValue = true)]
        public Cooldown Cooldown { get; set; }

        /// <summary>
        /// Gets or Sets Extraction
        /// </summary>
        [DataMember(Name = "extraction", IsRequired = true, EmitDefaultValue = true)]
        public Extraction Extraction { get; set; }

        /// <summary>
        /// Gets or Sets Cargo
        /// </summary>
        [DataMember(Name = "cargo", IsRequired = true, EmitDefaultValue = true)]
        public ShipCargo Cargo { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ExtractResources201ResponseData {\n");
            sb.Append("  Cooldown: ").Append(Cooldown).Append('\n');
            sb.Append("  Extraction: ").Append(Extraction).Append('\n');
            sb.Append("  Cargo: ").Append(Cargo).Append('\n');
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
            return this.Equals(input as ExtractResources201ResponseData);
        }

        /// <summary>
        /// Returns true if ExtractResources201ResponseData instances are equal
        /// </summary>
        /// <param name="input">Instance of ExtractResources201ResponseData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ExtractResources201ResponseData input)
        {
            if (input == null)
            {
                return false;
            }

            return 
                (
                    this.Cooldown == input.Cooldown ||
                    (this.Cooldown != null &&
                    this.Cooldown.Equals(input.Cooldown))
                ) && 
                (
                    this.Extraction == input.Extraction ||
                    (this.Extraction != null &&
                    this.Extraction.Equals(input.Extraction))
                ) && 
                (
                    this.Cargo == input.Cargo ||
                    (this.Cargo != null &&
                    this.Cargo.Equals(input.Cargo))
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
                if (this.Cooldown != null)
                {
                    hashCode = (hashCode * 59) + this.Cooldown.GetHashCode();
                }

                if (this.Extraction != null)
                {
                    hashCode = (hashCode * 59) + this.Extraction.GetHashCode();
                }

                if (this.Cargo != null)
                {
                    hashCode = (hashCode * 59) + this.Cargo.GetHashCode();
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
