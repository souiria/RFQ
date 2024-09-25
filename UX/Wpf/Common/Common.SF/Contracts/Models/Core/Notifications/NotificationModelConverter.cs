using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Core.Notifications;

namespace Common.SF.Contracts.Models.Core.Notifications
{
    /// <summary>
    /// A static class that converts a model into a notification message
    /// </summary>
    /// <typeparam name="T">The type of the model</typeparam>
    public static class NotificationModelConverter<T>
    {
        /// <summary>
        /// <para>Convert the model into a notification message.</para>
        /// Uses the model naming convention "[GlobalMaster]Model" and CrudOperationType  to generate an appropriate notification message.
        /// </summary>
        /// <param name="model">The model to be converted</param>
        /// <returns>The generated notification</returns>
        public static Notification ConvertModel(T model)
        {
            var modelType = typeof(T).Name.Remove(typeof(T).Name.IndexOf("Model"));
            modelType = string.Concat(modelType.Select(c => char.IsUpper(c) ? " " + c.ToString() : c.ToString())).TrimStart();
            CrudOperationType operation = (CrudOperationType)typeof(T).GetProperty("CrudOperationType").GetValue(model);
            string header = "";
            string body = "";
            switch (operation)
            {
                case CrudOperationType.Create:
                    header = $"A new {modelType} has been added";
                    body = $"A new {modelType.ToLower()} has been created in the {modelType} Master.\n\n" +
                        $"This is an automated message. This can be disabled from the Harness One subscription screen.";
                    break;

                case CrudOperationType.Delete:
                    header = $"A {modelType} has been deleted";
                    body = $"A {modelType.ToLower()} has been removed from the {modelType} Master.\n\n" +
                        $"If you believe this was a mistake, please contact the {modelType.ToLower()} administrator.\n\n" +
                        $"This is an automated message. This can be disabled from the Harness One subscription screen."; ;
                    break;

                case CrudOperationType.Update:
                    header = $"A {modelType} has been updated";
                    body = $"A {modelType.ToLower()} has been updated in the {modelType} Master.\n\n" +
                        $"If you believe this was a mistake, please contact the {modelType.ToLower()} administrator.\n\n" +
                        $"This is an automated message. This can be disabled from the Harness One subscription screen."; ;
                    break;

                default:
                    break;
            }

            return new Notification
            {
                Header = header,
                Body = body,
                DateSent = DateTime.UtcNow,
                // Origin = modelType,
                Id = Guid.NewGuid(),
                IsRead = false
            };
        }

        public static IEnumerable<Notification> ConvertModels(IEnumerable<T> models)
        {
            foreach (var model in models)
            {
                yield return ConvertModel(model);
            }
        }

        public static IEnumerable<SubscriptionChannel> CreatesCrudChannels(ServiceContext Context)
        {
            var service = Context.ServiceName.Segments[Context.ServiceName.Segments.Count() - 1];
            var s = service.Substring(0, service.LastIndexOf('.'));
            var function = s.Substring(s.LastIndexOf('.') + 1);
            service = service.Substring(service.LastIndexOf('.') + 1);
            service = string.Concat(service.Select(c => char.IsUpper(c) ? " " + c.ToString() : c.ToString())).TrimStart();
            string modelType = typeof(T).Name;
            if (typeof(T).Name.IndexOf("Model") >= 0)
                modelType = modelType.Remove(typeof(T).Name.IndexOf("Model"));

            modelType = string.Concat(modelType.Select(c => char.IsUpper(c) ? " " + c.ToString() : c.ToString())).TrimStart();

            return new List<SubscriptionChannel>
            {
                    new SubscriptionChannel
                    {
                        Channel = $"{service.Replace(" ", "")}CreateChannel",
                        Description = $"When a {modelType.ToLower()} is added",
                        ServiceName = $"{service}",
                        FunctionName = $"{function}",
                        EventType = "Data Changes",
                        CrudOperationType = CrudOperationType.Create
                    },
                    new SubscriptionChannel
                    {
                        Channel = $"{service.Replace(" ", "")}UpdateChannel",
                        Description = $"When a {modelType.ToLower()} is updated",
                        ServiceName = $"{service}",
                        FunctionName = $"{function}",
                        EventType = "Data Changes",
                        CrudOperationType = CrudOperationType.Create
                    },
                    new SubscriptionChannel
                    {
                        Channel = $"{service.Replace(" ", "")}DeleteChannel",
                        Description = $"When a {modelType.ToLower()} is deleted",
                        ServiceName = $"{service}",
                        FunctionName = $"{function}",
                        EventType = "Data Changes",
                        CrudOperationType = CrudOperationType.Create
                    }
            };
        }
    }
}
