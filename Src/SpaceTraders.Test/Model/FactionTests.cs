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
    ///  Class for testing Faction
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class FactionTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for Faction
        //private Faction instance;

        public FactionTests()
        {
            // TODO uncomment below to create an instance of Faction
            //instance = new Faction();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of Faction
        /// </summary>
        [Fact]
        public void FactionInstanceTest()
        {
            // TODO uncomment below to test "IsType" Faction
            //Assert.IsType<Faction>(instance);
        }

        /// <summary>
        /// Test the property 'Symbol'
        /// </summary>
        [Fact]
        public void SymbolTest()
        {
            // TODO unit test for the property 'Symbol'
        }

        /// <summary>
        /// Test the property 'Name'
        /// </summary>
        [Fact]
        public void NameTest()
        {
            // TODO unit test for the property 'Name'
        }

        /// <summary>
        /// Test the property 'Description'
        /// </summary>
        [Fact]
        public void DescriptionTest()
        {
            // TODO unit test for the property 'Description'
        }

        /// <summary>
        /// Test the property 'Headquarters'
        /// </summary>
        [Fact]
        public void HeadquartersTest()
        {
            // TODO unit test for the property 'Headquarters'
        }

        /// <summary>
        /// Test the property 'Traits'
        /// </summary>
        [Fact]
        public void TraitsTest()
        {
            // TODO unit test for the property 'Traits'
        }

        /// <summary>
        /// Test the property 'IsRecruiting'
        /// </summary>
        [Fact]
        public void IsRecruitingTest()
        {
            // TODO unit test for the property 'IsRecruiting'
        }
    }
}
