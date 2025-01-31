// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Analytics.Synapse.Artifacts.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse.Artifacts
{
    /// <summary> The SqlScript service client. </summary>
    public partial class SqlScriptClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal SqlScriptRestClient RestClient { get; }
        /// <summary> Initializes a new instance of SqlScriptClient for mocking. </summary>
        protected SqlScriptClient()
        {
        }
        /// <summary> Initializes a new instance of SqlScriptClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The workspace development endpoint, for example https://myworkspace.dev.azuresynapse.net. </param>
        /// <param name="apiVersion"> Api Version. </param>
        internal SqlScriptClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint, string apiVersion = "2019-06-01-preview")
        {
            RestClient = new SqlScriptRestClient(clientDiagnostics, pipeline, endpoint, apiVersion);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Creates or updates a Sql Script. </summary>
        /// <param name="sqlScriptName"> The sql script name. </param>
        /// <param name="sqlScript"> Sql Script resource definition. </param>
        /// <param name="ifMatch"> ETag of the SQL script entity.  Should only be specified for update, for which it should match existing entity or can be * for unconditional update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SqlScriptResource>> CreateOrUpdateSqlScriptAsync(string sqlScriptName, SqlScriptResource sqlScript, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SqlScriptClient.CreateOrUpdateSqlScript");
            scope.Start();
            try
            {
                return await RestClient.CreateOrUpdateSqlScriptAsync(sqlScriptName, sqlScript, ifMatch, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates or updates a Sql Script. </summary>
        /// <param name="sqlScriptName"> The sql script name. </param>
        /// <param name="sqlScript"> Sql Script resource definition. </param>
        /// <param name="ifMatch"> ETag of the SQL script entity.  Should only be specified for update, for which it should match existing entity or can be * for unconditional update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SqlScriptResource> CreateOrUpdateSqlScript(string sqlScriptName, SqlScriptResource sqlScript, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SqlScriptClient.CreateOrUpdateSqlScript");
            scope.Start();
            try
            {
                return RestClient.CreateOrUpdateSqlScript(sqlScriptName, sqlScript, ifMatch, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a sql script. </summary>
        /// <param name="sqlScriptName"> The sql script name. </param>
        /// <param name="ifNoneMatch"> ETag of the sql compute entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SqlScriptResource>> GetSqlScriptAsync(string sqlScriptName, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SqlScriptClient.GetSqlScript");
            scope.Start();
            try
            {
                return await RestClient.GetSqlScriptAsync(sqlScriptName, ifNoneMatch, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a sql script. </summary>
        /// <param name="sqlScriptName"> The sql script name. </param>
        /// <param name="ifNoneMatch"> ETag of the sql compute entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SqlScriptResource> GetSqlScript(string sqlScriptName, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SqlScriptClient.GetSqlScript");
            scope.Start();
            try
            {
                return RestClient.GetSqlScript(sqlScriptName, ifNoneMatch, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a Sql Script. </summary>
        /// <param name="sqlScriptName"> The sql script name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeleteSqlScriptAsync(string sqlScriptName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SqlScriptClient.DeleteSqlScript");
            scope.Start();
            try
            {
                return await RestClient.DeleteSqlScriptAsync(sqlScriptName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a Sql Script. </summary>
        /// <param name="sqlScriptName"> The sql script name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response DeleteSqlScript(string sqlScriptName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SqlScriptClient.DeleteSqlScript");
            scope.Start();
            try
            {
                return RestClient.DeleteSqlScript(sqlScriptName, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists sql scripts. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<SqlScriptResource> GetSqlScriptsByWorkspaceAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SqlScriptResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SqlScriptClient.GetSqlScriptsByWorkspace");
                scope.Start();
                try
                {
                    var response = await RestClient.GetSqlScriptsByWorkspaceAsync(cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SqlScriptResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SqlScriptClient.GetSqlScriptsByWorkspace");
                scope.Start();
                try
                {
                    var response = await RestClient.GetSqlScriptsByWorkspaceNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists sql scripts. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<SqlScriptResource> GetSqlScriptsByWorkspace(CancellationToken cancellationToken = default)
        {
            Page<SqlScriptResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SqlScriptClient.GetSqlScriptsByWorkspace");
                scope.Start();
                try
                {
                    var response = RestClient.GetSqlScriptsByWorkspace(cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SqlScriptResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SqlScriptClient.GetSqlScriptsByWorkspace");
                scope.Start();
                try
                {
                    var response = RestClient.GetSqlScriptsByWorkspaceNextPage(nextLink, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Renames a sqlScript. </summary>
        /// <param name="sqlScriptName"> The sql script name. </param>
        /// <param name="request"> proposed new name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sqlScriptName"/> or <paramref name="request"/> is null. </exception>
        public virtual async Task<SqlScriptRenameSqlScriptOperation> StartRenameSqlScriptAsync(string sqlScriptName, ArtifactRenameRequest request, CancellationToken cancellationToken = default)
        {
            if (sqlScriptName == null)
            {
                throw new ArgumentNullException(nameof(sqlScriptName));
            }
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            using var scope = _clientDiagnostics.CreateScope("SqlScriptClient.StartRenameSqlScript");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.RenameSqlScriptAsync(sqlScriptName, request, cancellationToken).ConfigureAwait(false);
                return new SqlScriptRenameSqlScriptOperation(_clientDiagnostics, _pipeline, RestClient.CreateRenameSqlScriptRequest(sqlScriptName, request).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Renames a sqlScript. </summary>
        /// <param name="sqlScriptName"> The sql script name. </param>
        /// <param name="request"> proposed new name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sqlScriptName"/> or <paramref name="request"/> is null. </exception>
        public virtual SqlScriptRenameSqlScriptOperation StartRenameSqlScript(string sqlScriptName, ArtifactRenameRequest request, CancellationToken cancellationToken = default)
        {
            if (sqlScriptName == null)
            {
                throw new ArgumentNullException(nameof(sqlScriptName));
            }
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            using var scope = _clientDiagnostics.CreateScope("SqlScriptClient.StartRenameSqlScript");
            scope.Start();
            try
            {
                var originalResponse = RestClient.RenameSqlScript(sqlScriptName, request, cancellationToken);
                return new SqlScriptRenameSqlScriptOperation(_clientDiagnostics, _pipeline, RestClient.CreateRenameSqlScriptRequest(sqlScriptName, request).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
