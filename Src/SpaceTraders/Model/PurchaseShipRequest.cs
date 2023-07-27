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
    /// PurchaseShipRequest
    /// </summary>
    [DataContract(Name = "purchase_ship_request")]
    public partial class PurchaseShipRequest : IEquatable<PurchaseShipRequest>, IValidatableObject
    {

        /// <summary>
        /// Gets or Sets ShipType
        /// </summary>
        [DataMember(Name = "shipType", IsRequired = true, EmitDefaultValue = true)]
        public ShipType ShipType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseShipRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected PurchaseShipRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseShipRequest" /> class.
        /// </summary>
        /// <param name="shipType">shipType (required).</param>
        /// <param name="waypointSymbol">The symbol of the waypoint you want to purchase the ship at. (required).</param>
        public PurchaseShipRequest(ShipType shipType = default, string? waypointSymbol = default)
        {
            this.ShipType = shipType;
            // to ensure "waypointSymbol" is required (not null)
            if (waypointSymbol == null)
            {
                throw new ArgumentNullException("waypointSymbol is a required property for PurchaseShipRequest and cannot be null");
            }

            this.WaypointSymbol = waypointSymbol;
        }

        /// <summary>
        /// The symbol of the waypoint you want to purchase the ship at.
        /// </summary>
        /// <value>The symbol of the waypoint you want to purchase the ship at.</value>
        [DataMember(Name = "waypointSymbol", IsRequired = true, EmitDefaultValue = true)]
        public string WaypointSymbol { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PurchaseShipRequest {\n");
            sb.Append("  ShipType: ").Append(ShipType).Append('\n');
            sb.Append("  WaypointSymbol: ").Append(WaypointSymbol).Append('\n');
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
            return this.Equals(input as PurchaseShipRequest);
        }

        /// <summary>
        /// Returns true if PurchaseShipRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of PurchaseShipRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PurchaseShipRequest input)
        {
            if (input == null)
            {
                return false;
            }

            return 
                (
                    this.ShipType == input.ShipType ||
                    this.ShipType.Equals(input.ShipType)
                ) && 
                (
                    this.WaypointSymbol == input.WaypointSymbol ||
                    (this.WaypointSymbol != null &&
                    this.WaypointSymbol.Equals(input.WaypointSymbol))
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
                hashCode = (hashCode * 59) + this.ShipType.GetHashCode();
                if (this.WaypointSymbol != null)
                {
                    hashCode = (hashCode * 59) + this.WaypointSymbol.GetHashCode();
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