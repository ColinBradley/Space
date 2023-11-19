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
    /// InstallMount201ResponseData
    /// </summary>
    [DataContract(Name = "Install_Mount_201_Response_data")]
    public partial class InstallMount201ResponseData : IEquatable<InstallMount201ResponseData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InstallMount201ResponseData" /> class.
        /// </summary>
        [JsonConstructor]
        protected InstallMount201ResponseData() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="InstallMount201ResponseData" /> class.
        /// </summary>
        /// <param name="agent">agent (required).</param>
        /// <param name="mounts">List of installed mounts after the installation of the new mount. (required).</param>
        /// <param name="cargo">cargo (required).</param>
        /// <param name="transaction">transaction (required).</param>
        public InstallMount201ResponseData(Agent? agent = default, List<ShipMount>? mounts = default, ShipCargo? cargo = default, ShipModificationTransaction? transaction = default)
        {
            // to ensure "agent" is required (not null)
            ArgumentNullException.ThrowIfNull(agent);

            this.Agent = agent;
            // to ensure "mounts" is required (not null)
            ArgumentNullException.ThrowIfNull(mounts);

            this.Mounts = mounts;
            // to ensure "cargo" is required (not null)
            ArgumentNullException.ThrowIfNull(cargo);

            this.Cargo = cargo;
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
        /// List of installed mounts after the installation of the new mount.
        /// </summary>
        /// <value>List of installed mounts after the installation of the new mount.</value>
        [DataMember(Name = "mounts", IsRequired = true, EmitDefaultValue = true)]
        public List<ShipMount> Mounts { get; set; }

        /// <summary>
        /// Gets or Sets Cargo
        /// </summary>
        [DataMember(Name = "cargo", IsRequired = true, EmitDefaultValue = true)]
        public ShipCargo Cargo { get; set; }

        /// <summary>
        /// Gets or Sets Transaction
        /// </summary>
        [DataMember(Name = "transaction", IsRequired = true, EmitDefaultValue = true)]
        public ShipModificationTransaction Transaction { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class InstallMount201ResponseData {\n");
            sb.Append("  Agent: ").Append(Agent).Append('\n');
            sb.Append("  Mounts: ").Append(Mounts).Append('\n');
            sb.Append("  Cargo: ").Append(Cargo).Append('\n');
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
            return this.Equals(input as InstallMount201ResponseData);
        }

        /// <summary>
        /// Returns true if InstallMount201ResponseData instances are equal
        /// </summary>
        /// <param name="input">Instance of InstallMount201ResponseData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InstallMount201ResponseData input)
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
                    this.Mounts == input.Mounts ||
                    this.Mounts != null &&
                    input.Mounts != null &&
                    this.Mounts.SequenceEqual(input.Mounts)
                ) && 
                (
                    this.Cargo == input.Cargo ||
                    (this.Cargo != null &&
                    this.Cargo.Equals(input.Cargo))
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

                if (this.Mounts != null)
                {
                    hashCode = (hashCode * 59) + this.Mounts.GetHashCode();
                }

                if (this.Cargo != null)
                {
                    hashCode = (hashCode * 59) + this.Cargo.GetHashCode();
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
