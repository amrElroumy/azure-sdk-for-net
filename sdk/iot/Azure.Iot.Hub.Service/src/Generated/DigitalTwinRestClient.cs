// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Iot.Hub.Service.Models;

namespace Azure.Iot.Hub.Service
{
    internal partial class DigitalTwinRestClient
    {
        private string host;
        private string apiVersion;
        private ClientDiagnostics _clientDiagnostics;
        private HttpPipeline _pipeline;

        /// <summary> Initializes a new instance of DigitalTwinRestClient. </summary>
        public DigitalTwinRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "https://fully-qualified-iothubname.azure-devices.net", string apiVersion = "2020-03-13")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }

            this.host = host;
            this.apiVersion = apiVersion;
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        internal HttpMessage CreateGetComponentsRequest(string digitalTwinId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/digitalTwins/", false);
            uri.AppendPath(digitalTwinId, true);
            uri.AppendPath("/interfaces", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            return message;
        }

        /// <summary>  For IoT Hub VNET related features(https://docs.microsoft.com/en-us/azure/iot-hub/virtual-network-support) please use API version &apos;2020-03-13&apos;.These features are currently in general availability in the East US, West US 2, and Southcentral US regions only. We are actively working to expand the availability of these features to all regions by end of month May. For rest of the APIs please continue using API version &apos;2019-10-01&apos;. </summary>
        /// <param name="digitalTwinId"> Digital Twin ID. Format of digitalTwinId is DeviceId[~ModuleId]. ModuleId is optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DigitalTwinInterfaces>> GetComponentsAsync(string digitalTwinId, CancellationToken cancellationToken = default)
        {
            if (digitalTwinId == null)
            {
                throw new ArgumentNullException(nameof(digitalTwinId));
            }

            using var message = CreateGetComponentsRequest(digitalTwinId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DigitalTwinInterfaces value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = DigitalTwinInterfaces.DeserializeDigitalTwinInterfaces(document.RootElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary>  For IoT Hub VNET related features(https://docs.microsoft.com/en-us/azure/iot-hub/virtual-network-support) please use API version &apos;2020-03-13&apos;.These features are currently in general availability in the East US, West US 2, and Southcentral US regions only. We are actively working to expand the availability of these features to all regions by end of month May. For rest of the APIs please continue using API version &apos;2019-10-01&apos;. </summary>
        /// <param name="digitalTwinId"> Digital Twin ID. Format of digitalTwinId is DeviceId[~ModuleId]. ModuleId is optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DigitalTwinInterfaces> GetComponents(string digitalTwinId, CancellationToken cancellationToken = default)
        {
            if (digitalTwinId == null)
            {
                throw new ArgumentNullException(nameof(digitalTwinId));
            }

            using var message = CreateGetComponentsRequest(digitalTwinId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DigitalTwinInterfaces value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = DigitalTwinInterfaces.DeserializeDigitalTwinInterfaces(document.RootElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateUpdateComponentRequest(string digitalTwinId, DigitalTwinInterfacesPatch interfacesPatchInfo, string ifMatch)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/digitalTwins/", false);
            uri.AppendPath(digitalTwinId, true);
            uri.AppendPath("/interfaces", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            if (ifMatch != null)
            {
                request.Headers.Add("If-Match", ifMatch);
            }
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(interfacesPatchInfo);
            request.Content = content;
            return message;
        }

        /// <summary>  For IoT Hub VNET related features(https://docs.microsoft.com/en-us/azure/iot-hub/virtual-network-support) please use API version &apos;2020-03-13&apos;.These features are currently in general availability in the East US, West US 2, and Southcentral US regions only. We are actively working to expand the availability of these features to all regions by end of month May. For rest of the APIs please continue using API version &apos;2019-10-01&apos;. </summary>
        /// <param name="digitalTwinId"> Digital Twin ID. Format of digitalTwinId is DeviceId[~ModuleId]. ModuleId is optional. </param>
        /// <param name="interfacesPatchInfo"> Multiple interfaces desired properties to update. </param>
        /// <param name="ifMatch"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DigitalTwinInterfaces>> UpdateComponentAsync(string digitalTwinId, DigitalTwinInterfacesPatch interfacesPatchInfo, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            if (digitalTwinId == null)
            {
                throw new ArgumentNullException(nameof(digitalTwinId));
            }
            if (interfacesPatchInfo == null)
            {
                throw new ArgumentNullException(nameof(interfacesPatchInfo));
            }

            using var message = CreateUpdateComponentRequest(digitalTwinId, interfacesPatchInfo, ifMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DigitalTwinInterfaces value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = DigitalTwinInterfaces.DeserializeDigitalTwinInterfaces(document.RootElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary>  For IoT Hub VNET related features(https://docs.microsoft.com/en-us/azure/iot-hub/virtual-network-support) please use API version &apos;2020-03-13&apos;.These features are currently in general availability in the East US, West US 2, and Southcentral US regions only. We are actively working to expand the availability of these features to all regions by end of month May. For rest of the APIs please continue using API version &apos;2019-10-01&apos;. </summary>
        /// <param name="digitalTwinId"> Digital Twin ID. Format of digitalTwinId is DeviceId[~ModuleId]. ModuleId is optional. </param>
        /// <param name="interfacesPatchInfo"> Multiple interfaces desired properties to update. </param>
        /// <param name="ifMatch"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DigitalTwinInterfaces> UpdateComponent(string digitalTwinId, DigitalTwinInterfacesPatch interfacesPatchInfo, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            if (digitalTwinId == null)
            {
                throw new ArgumentNullException(nameof(digitalTwinId));
            }
            if (interfacesPatchInfo == null)
            {
                throw new ArgumentNullException(nameof(interfacesPatchInfo));
            }

            using var message = CreateUpdateComponentRequest(digitalTwinId, interfacesPatchInfo, ifMatch);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DigitalTwinInterfaces value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = DigitalTwinInterfaces.DeserializeDigitalTwinInterfaces(document.RootElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetComponentRequest(string digitalTwinId, string interfaceName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/digitalTwins/", false);
            uri.AppendPath(digitalTwinId, true);
            uri.AppendPath("/interfaces/", false);
            uri.AppendPath(interfaceName, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            return message;
        }

        /// <summary>  For IoT Hub VNET related features(https://docs.microsoft.com/en-us/azure/iot-hub/virtual-network-support) please use API version &apos;2020-03-13&apos;.These features are currently in general availability in the East US, West US 2, and Southcentral US regions only. We are actively working to expand the availability of these features to all regions by end of month May. For rest of the APIs please continue using API version &apos;2019-10-01&apos;. </summary>
        /// <param name="digitalTwinId"> Digital Twin ID. Format of digitalTwinId is DeviceId[~ModuleId]. ModuleId is optional. </param>
        /// <param name="interfaceName"> The interface name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<DigitalTwinInterfaces>> GetComponentAsync(string digitalTwinId, string interfaceName, CancellationToken cancellationToken = default)
        {
            if (digitalTwinId == null)
            {
                throw new ArgumentNullException(nameof(digitalTwinId));
            }
            if (interfaceName == null)
            {
                throw new ArgumentNullException(nameof(interfaceName));
            }

            using var message = CreateGetComponentRequest(digitalTwinId, interfaceName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DigitalTwinInterfaces value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = DigitalTwinInterfaces.DeserializeDigitalTwinInterfaces(document.RootElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary>  For IoT Hub VNET related features(https://docs.microsoft.com/en-us/azure/iot-hub/virtual-network-support) please use API version &apos;2020-03-13&apos;.These features are currently in general availability in the East US, West US 2, and Southcentral US regions only. We are actively working to expand the availability of these features to all regions by end of month May. For rest of the APIs please continue using API version &apos;2019-10-01&apos;. </summary>
        /// <param name="digitalTwinId"> Digital Twin ID. Format of digitalTwinId is DeviceId[~ModuleId]. ModuleId is optional. </param>
        /// <param name="interfaceName"> The interface name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<DigitalTwinInterfaces> GetComponent(string digitalTwinId, string interfaceName, CancellationToken cancellationToken = default)
        {
            if (digitalTwinId == null)
            {
                throw new ArgumentNullException(nameof(digitalTwinId));
            }
            if (interfaceName == null)
            {
                throw new ArgumentNullException(nameof(interfaceName));
            }

            using var message = CreateGetComponentRequest(digitalTwinId, interfaceName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DigitalTwinInterfaces value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = DigitalTwinInterfaces.DeserializeDigitalTwinInterfaces(document.RootElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetDigitalTwinModelRequest(string modelId, bool? expand)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/digitalTwins/models/", false);
            uri.AppendPath(modelId, true);
            if (expand != null)
            {
                uri.AppendQuery("expand", expand.Value, true);
            }
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            return message;
        }

        /// <summary>  For IoT Hub VNET related features(https://docs.microsoft.com/en-us/azure/iot-hub/virtual-network-support) please use API version &apos;2020-03-13&apos;.These features are currently in general availability in the East US, West US 2, and Southcentral US regions only. We are actively working to expand the availability of these features to all regions by end of month May. For rest of the APIs please continue using API version &apos;2019-10-01&apos;. </summary>
        /// <param name="modelId"> Model id Ex: &lt;example&gt;urn:contoso:TemperatureSensor:1&lt;/example&gt;. </param>
        /// <param name="expand">
        /// Indicates whether to expand the device capability model&apos;s interface definitions inline or not.
        /// 
        /// This query parameter ONLY applies to Capability model.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<object, DigitalTwinGetDigitalTwinModelHeaders>> GetDigitalTwinModelAsync(string modelId, bool? expand = null, CancellationToken cancellationToken = default)
        {
            if (modelId == null)
            {
                throw new ArgumentNullException(nameof(modelId));
            }

            using var message = CreateGetDigitalTwinModelRequest(modelId, expand);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new DigitalTwinGetDigitalTwinModelHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        object value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = document.RootElement.GetObject();
                        }
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                case 204:
                    return ResponseWithHeaders.FromValue<object, DigitalTwinGetDigitalTwinModelHeaders>(null, headers, message.Response);
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary>  For IoT Hub VNET related features(https://docs.microsoft.com/en-us/azure/iot-hub/virtual-network-support) please use API version &apos;2020-03-13&apos;.These features are currently in general availability in the East US, West US 2, and Southcentral US regions only. We are actively working to expand the availability of these features to all regions by end of month May. For rest of the APIs please continue using API version &apos;2019-10-01&apos;. </summary>
        /// <param name="modelId"> Model id Ex: &lt;example&gt;urn:contoso:TemperatureSensor:1&lt;/example&gt;. </param>
        /// <param name="expand">
        /// Indicates whether to expand the device capability model&apos;s interface definitions inline or not.
        /// 
        /// This query parameter ONLY applies to Capability model.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<object, DigitalTwinGetDigitalTwinModelHeaders> GetDigitalTwinModel(string modelId, bool? expand = null, CancellationToken cancellationToken = default)
        {
            if (modelId == null)
            {
                throw new ArgumentNullException(nameof(modelId));
            }

            using var message = CreateGetDigitalTwinModelRequest(modelId, expand);
            _pipeline.Send(message, cancellationToken);
            var headers = new DigitalTwinGetDigitalTwinModelHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        object value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = document.RootElement.GetObject();
                        }
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                case 204:
                    return ResponseWithHeaders.FromValue<object, DigitalTwinGetDigitalTwinModelHeaders>(null, headers, message.Response);
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateInvokeComponentCommandRequest(string digitalTwinId, string interfaceName, string commandName, object payload, int? connectTimeoutInSeconds, int? responseTimeoutInSeconds)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/digitalTwins/", false);
            uri.AppendPath(digitalTwinId, true);
            uri.AppendPath("/interfaces/", false);
            uri.AppendPath(interfaceName, true);
            uri.AppendPath("/commands/", false);
            uri.AppendPath(commandName, true);
            uri.AppendQuery("api-version", apiVersion, true);
            if (connectTimeoutInSeconds != null)
            {
                uri.AppendQuery("connectTimeoutInSeconds", connectTimeoutInSeconds.Value, true);
            }
            if (responseTimeoutInSeconds != null)
            {
                uri.AppendQuery("responseTimeoutInSeconds", responseTimeoutInSeconds.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(payload);
            request.Content = content;
            return message;
        }

        /// <summary> Invoke a digital twin interface command. </summary>
        /// <param name="digitalTwinId"> The String to use. </param>
        /// <param name="interfaceName"> The String to use. </param>
        /// <param name="commandName"> The String to use. </param>
        /// <param name="payload"> The any to use. </param>
        /// <param name="connectTimeoutInSeconds"> Connect timeout in seconds. </param>
        /// <param name="responseTimeoutInSeconds"> Response timeout in seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<object, DigitalTwinInvokeComponentCommandHeaders>> InvokeComponentCommandAsync(string digitalTwinId, string interfaceName, string commandName, object payload, int? connectTimeoutInSeconds = null, int? responseTimeoutInSeconds = null, CancellationToken cancellationToken = default)
        {
            if (digitalTwinId == null)
            {
                throw new ArgumentNullException(nameof(digitalTwinId));
            }
            if (interfaceName == null)
            {
                throw new ArgumentNullException(nameof(interfaceName));
            }
            if (commandName == null)
            {
                throw new ArgumentNullException(nameof(commandName));
            }
            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            using var message = CreateInvokeComponentCommandRequest(digitalTwinId, interfaceName, commandName, payload, connectTimeoutInSeconds, responseTimeoutInSeconds);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new DigitalTwinInvokeComponentCommandHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        object value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = document.RootElement.GetObject();
                        }
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Invoke a digital twin interface command. </summary>
        /// <param name="digitalTwinId"> The String to use. </param>
        /// <param name="interfaceName"> The String to use. </param>
        /// <param name="commandName"> The String to use. </param>
        /// <param name="payload"> The any to use. </param>
        /// <param name="connectTimeoutInSeconds"> Connect timeout in seconds. </param>
        /// <param name="responseTimeoutInSeconds"> Response timeout in seconds. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<object, DigitalTwinInvokeComponentCommandHeaders> InvokeComponentCommand(string digitalTwinId, string interfaceName, string commandName, object payload, int? connectTimeoutInSeconds = null, int? responseTimeoutInSeconds = null, CancellationToken cancellationToken = default)
        {
            if (digitalTwinId == null)
            {
                throw new ArgumentNullException(nameof(digitalTwinId));
            }
            if (interfaceName == null)
            {
                throw new ArgumentNullException(nameof(interfaceName));
            }
            if (commandName == null)
            {
                throw new ArgumentNullException(nameof(commandName));
            }
            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            using var message = CreateInvokeComponentCommandRequest(digitalTwinId, interfaceName, commandName, payload, connectTimeoutInSeconds, responseTimeoutInSeconds);
            _pipeline.Send(message, cancellationToken);
            var headers = new DigitalTwinInvokeComponentCommandHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        object value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        if (document.RootElement.ValueKind == JsonValueKind.Null)
                        {
                            value = null;
                        }
                        else
                        {
                            value = document.RootElement.GetObject();
                        }
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}