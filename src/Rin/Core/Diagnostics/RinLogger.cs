﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Rin.Core.Storage;
using Rin.Features;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rin.Core.Diagnostics
{
    internal class RinLogger : ILogger
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RinLogger(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var recording = httpContext?.Features.Get<IRinRequestRecordingFeature>();
            if (recording == null) return;

            recording.Record.Traces.Enqueue(new TraceLogRecord(DateTime.Now, logLevel, formatter(state, exception)));
        }
    }
}
