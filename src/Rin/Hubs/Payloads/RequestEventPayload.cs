﻿using Rin.Core;
using Rin.Core.Storage;

namespace Rin.Hubs.Payloads
{
    public class RequestEventPayload
    {
        public string Id { get; private set; }
        public bool IsCompleted { get; private set; }
        public string Method { get; private set; }
        public string Path { get; private set; }
        public int ResponseStatusCode { get; private set; }

        public RequestEventPayload(HttpRequestRecord record)
        {
            Id = record.Id;
            IsCompleted = record.IsCompleted;
            Method = record.Method;
            Path = record.Path;
            ResponseStatusCode = record.ResponseStatusCode;
        }
    }
}
