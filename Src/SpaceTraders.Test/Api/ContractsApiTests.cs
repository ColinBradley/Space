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
    ///  Class for testing ContractsApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class ContractsApiTests : IDisposable
    {
        private readonly ContractsApi mInstance;

        public ContractsApiTests()
        {
            mInstance = new ContractsApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of ContractsApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' ContractsApi
            //Assert.IsType<ContractsApi>(instance);
        }

        /// <summary>
        /// Test AcceptContract
        /// </summary>
        [Fact]
        public void AcceptContractTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string contractId = null;
            //var response = instance.AcceptContract(contractId);
            //Assert.IsType<AcceptContract200Response>(response);
        }

        /// <summary>
        /// Test DeliverContract
        /// </summary>
        [Fact]
        public void DeliverContractTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string contractId = null;
            //DeliverContractRequest? deliverContractRequest = null;
            //var response = instance.DeliverContract(contractId, deliverContractRequest);
            //Assert.IsType<DeliverContract200Response>(response);
        }

        /// <summary>
        /// Test FulfillContract
        /// </summary>
        [Fact]
        public void FulfillContractTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string contractId = null;
            //var response = instance.FulfillContract(contractId);
            //Assert.IsType<FulfillContract200Response>(response);
        }

        /// <summary>
        /// Test GetContract
        /// </summary>
        [Fact]
        public void GetContractTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string contractId = null;
            //var response = instance.GetContract(contractId);
            //Assert.IsType<GetContract200Response>(response);
        }

        /// <summary>
        /// Test GetContracts
        /// </summary>
        [Fact]
        public void GetContractsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? page = null;
            //int? limit = null;
            //var response = instance.GetContracts(page, limit);
            //Assert.IsType<GetContracts200Response>(response);
        }
    }
}
