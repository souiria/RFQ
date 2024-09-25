using Microsoft.AspNetCore.Http;

namespace Edi.Common.ApplicationInsights;

public class CorrelationMessageHeaders
{
    ///<summary>
    ///SetMessageHeaders: Set headers on the MassTransit Bus for Application Insights correlation with remote service. Use in-line, on the Message bus request
    ///</summary>
    public SendContext SetMessageHeaders(string telemetryComment, IOperationHolder<DependencyTelemetry> operation, SendContext context)
    {
        operation.Telemetry.Type = "MessageBus";
        operation.Telemetry.Data = telemetryComment;
        //  _telemetry.Context.Operation.Id
        var authId = operation.Telemetry.Context.User.AuthenticatedUserId;
        var userId = operation.Telemetry.Context.User.Id;
        var rootId = operation.Telemetry.Context.Operation.Id;
        var parentId = operation.Telemetry.Id;
        var sessionId = operation.Telemetry.Context.Session.Id;
        //Add headers to the request 'send context'
        context.Headers.Set("auth_id", authId);
        context.Headers.Set("user_id", userId);
        context.Headers.Set("rootId", rootId);
        context.Headers.Set("parentId", parentId);
        context.Headers.Set("session_id", sessionId); return context;
    }

    ///<summary>
    ///GetMessageHeaders: Gets the Application Insights header information from the incoming http request,
    ///and then adds the correlation to the supplied TelemetryClient.
    ///Returns: TelemetryClient
    ///</summary>
    public TelemetryClient GetRequestHeaders(HttpRequest request, TelemetryClient telemetry)
    {
        var tester = request.Headers;
        var authid = request.Headers.ContainsKey("auth_id") ? request.Headers["auth_id"][0] : null;
        var userid = request.Headers.ContainsKey("user_id") ? request.Headers["user_id"][0] : null;
        var sessionid = request.Headers.ContainsKey("session_id") ? request.Headers["session_id"][0] : null;
        telemetry.Context.User.AuthenticatedUserId = authid;
        telemetry.Context.User.Id = authid;
        telemetry.Context.Session.Id = sessionid;
        return telemetry;
    }

    ///<summary>
    ///SetMessageHeaders.: Get the incoming request headers from the MassTransit Bus for Application Insights correlation. Returns RequestTelemetry for StartOperation
    ///</summary>
    ///
    public RequestTelemetry CreateRequestTelemetrywithCorrelationHeaders(string operationName, Headers messageHeaders)
    {
        //Get headers and do Dependency logging to AI
        string? auth_id = null;
        string? user_id = null;
        string? rootId = null;
        string? parentId = null;
        string? session_Id = null; if (messageHeaders.TryGetHeader("auth_id", out object authid))
        { auth_id = authid.ToString(); }
        if (messageHeaders.TryGetHeader("user_id", out object userid))
        { user_id = userid.ToString(); }
        if (messageHeaders.TryGetHeader("rootId", out object rootid))
        { rootId = rootid.ToString(); }
        if (messageHeaders.TryGetHeader("parentId", out object parentid))
        { parentId = parentid.ToString(); }
        if (messageHeaders.TryGetHeader("session_id", out object sessionid))
        { session_Id = sessionid.ToString(); }
        // After the message is dequeued from the queue, create RequestTelemetry to track its processing.
        RequestTelemetry requestTelemetry = new RequestTelemetry { Name = operationName };
        // It might also make sense to get the name from the message.
        if (rootId != null)
        {
            requestTelemetry.Context.Operation.Id = Convert.ToString(rootId);
            requestTelemetry.Context.Operation.ParentId = parentId;
            requestTelemetry.Context.User.AuthenticatedUserId = auth_id;
            requestTelemetry.Context.User.Id = user_id;
            requestTelemetry.Context.Session.Id = session_Id;
        }
        return requestTelemetry;
    }

    ///<summary>
    ///SetMessageHeaders.: Get the incoming request headers from the MassTransit Bus for Application Insights correlation. Returns DependencyTelemetry for StartOperation
    ///</summary>
    public DependencyTelemetry CreateDependencyTelemetrywithCorrelationHeaders(string operationName, Headers messageHeaders)
    {
        //Get headers and do Dependency logging to AI
        string? auth_id = null;
        string? user_id = null;
        string? rootId = null;
        string? parentId = null;
        string? session_Id = null; if (messageHeaders.TryGetHeader("auth_id", out object authid))
        { auth_id = authid.ToString(); }
        if (messageHeaders.TryGetHeader("user_id", out object userid))
        { user_id = userid.ToString(); }
        if (messageHeaders.TryGetHeader("rootId", out object rootid))
        { rootId = rootid.ToString(); }
        if (messageHeaders.TryGetHeader("parentId", out object parentid))
        { parentId = parentid.ToString(); }
        if (messageHeaders.TryGetHeader("session_id", out object sessionid))
        { session_Id = sessionid.ToString(); }
        // After the message is dequeued from the queue, create RequestTelemetry to track its processing.
        DependencyTelemetry dependencyTelemetry = new DependencyTelemetry { Name = operationName };
        // It might also make sense to get the name from the message.
        if (rootId != null)
        {
            dependencyTelemetry.Context.Operation.Id = Convert.ToString(rootId);
            dependencyTelemetry.Context.Operation.ParentId = parentId;
            dependencyTelemetry.Context.User.AuthenticatedUserId = auth_id;
            dependencyTelemetry.Context.User.Id = user_id;
            dependencyTelemetry.Context.Session.Id = session_Id;
        }
        return dependencyTelemetry;
    }
}
