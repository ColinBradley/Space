/*
 * SpaceTraders API
 *
 * SpaceTraders is an open-universe game and learning platform that offers a set of HTTP endpoints to control a fleet of ships and explore a multiplayer universe.  The API is documented using [OpenAPI](https://github.com/SpaceTradersAPI/api-docs). You can send your first request right here in your browser to check the status of the game server.  ```json http {   \"method\": \"GET\",   \"url\": \"https://api.spacetraders.io/v2\", } ```  Unlike a traditional game, SpaceTraders does not have a first-party client or app to play the game. Instead, you can use the API to build your own client, write a script to automate your ships, or try an app built by the community.  We have a [Discord channel](https://discord.com/invite/jh6zurdWk5) where you can share your projects, ask questions, and get help from other players.   
 *
 * The version of the OpenAPI document: 2.0.0
 * Contact: joel@spacetraders.io
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using Xunit;

using System;

namespace SpaceTraders.Test.Model
{
    /// <summary>
    ///  Class for testing ShipRefine201ResponseData
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class ShipRefine201ResponseDataTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for ShipRefine201ResponseData
        //private ShipRefine201ResponseData instance;

        public ShipRefine201ResponseDataTests()
        {
            // TODO uncomment below to create an instance of ShipRefine201ResponseData
            //instance = new ShipRefine201ResponseData();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of ShipRefine201ResponseData
        /// </summary>
        [Fact]
        public void ShipRefine201ResponseDataInstanceTest()
        {
            // TODO uncomment below to test "IsType" ShipRefine201ResponseData
            //Assert.IsType<ShipRefine201ResponseData>(instance);
        }

        /// <summary>
        /// Test the property 'Cargo'
        /// </summary>
        [Fact]
        public void CargoTest()
        {
            // TODO unit test for the property 'Cargo'
        }

        /// <summary>
        /// Test the property 'Cooldown'
        /// </summary>
        [Fact]
        public void CooldownTest()
        {
            // TODO unit test for the property 'Cooldown'
        }

        /// <summary>
        /// Test the property 'Produced'
        /// </summary>
        [Fact]
        public void ProducedTest()
        {
            // TODO unit test for the property 'Produced'
        }

        /// <summary>
        /// Test the property 'Consumed'
        /// </summary>
        [Fact]
        public void ConsumedTest()
        {
            // TODO unit test for the property 'Consumed'
        }
    }
}