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
using Xunit;
using SpaceTraders.Api;
// uncomment below to import models
//using SpaceTraders.Model;

namespace SpaceTraders.Test.Api
{
    /// <summary>
    ///  Class for testing SystemsApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class SystemsApiTests : IDisposable
    {
        private readonly SystemsApi mInstance;

        public SystemsApiTests()
        {
            mInstance = new SystemsApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of SystemsApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' SystemsApi
            //Assert.IsType<SystemsApi>(instance);
        }

        /// <summary>
        /// Test GetJumpGate
        /// </summary>
        [Fact]
        public void GetJumpGateTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string systemSymbol = null;
            //string waypointSymbol = null;
            //var response = instance.GetJumpGate(systemSymbol, waypointSymbol);
            //Assert.IsType<GetJumpGate200Response>(response);
        }

        /// <summary>
        /// Test GetMarket
        /// </summary>
        [Fact]
        public void GetMarketTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string systemSymbol = null;
            //string waypointSymbol = null;
            //var response = instance.GetMarket(systemSymbol, waypointSymbol);
            //Assert.IsType<GetMarket200Response>(response);
        }

        /// <summary>
        /// Test GetShipyard
        /// </summary>
        [Fact]
        public void GetShipyardTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string systemSymbol = null;
            //string waypointSymbol = null;
            //var response = instance.GetShipyard(systemSymbol, waypointSymbol);
            //Assert.IsType<GetShipyard200Response>(response);
        }

        /// <summary>
        /// Test GetSystem
        /// </summary>
        [Fact]
        public void GetSystemTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string systemSymbol = null;
            //var response = instance.GetSystem(systemSymbol);
            //Assert.IsType<GetSystem200Response>(response);
        }

        /// <summary>
        /// Test GetSystemWaypoints
        /// </summary>
        [Fact]
        public void GetSystemWaypointsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string systemSymbol = null;
            //int? page = null;
            //int? limit = null;
            //var response = instance.GetSystemWaypoints(systemSymbol, page, limit);
            //Assert.IsType<GetSystemWaypoints200Response>(response);
        }

        /// <summary>
        /// Test GetSystems
        /// </summary>
        [Fact]
        public void GetSystemsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? page = null;
            //int? limit = null;
            //var response = instance.GetSystems(page, limit);
            //Assert.IsType<GetSystems200Response>(response);
        }

        /// <summary>
        /// Test GetWaypoint
        /// </summary>
        [Fact]
        public void GetWaypointTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string systemSymbol = null;
            //string waypointSymbol = null;
            //var response = instance.GetWaypoint(systemSymbol, waypointSymbol);
            //Assert.IsType<GetWaypoint200Response>(response);
        }
    }
}
