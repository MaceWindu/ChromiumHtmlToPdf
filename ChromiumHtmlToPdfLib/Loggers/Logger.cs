﻿//
// Logger.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com>
//
// Copyright (c) 2017-2025 Magic-Sessions. (www.magic-sessions.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NON INFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using System;
using Microsoft.Extensions.Logging;

namespace ChromiumHtmlToPdfLib.Loggers;

/// <summary>
///     A helper class to share logging between the different classes
/// </summary>
internal class Logger
{
    #region Fields

    /// <summary>
    ///     When set then logging is written to this ILogger instance
    /// </summary>
    public ILogger? InternalLogger { get; set; }

    /// <summary>
    ///     A unique id that can be used to identify the logging of the converter when
    ///     calling the code from multiple threads and writing all the logging to the same file
    /// </summary>
    public string? InstanceId { get; set; }
    #endregion

    #region Constructor
    /// <summary>
    ///     Makes this object and sets all its needed properties
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="instanceId"></param>
    internal Logger(ILogger? logger, string? instanceId)
    {
        InternalLogger = logger;
        InstanceId = instanceId;
    }
    #endregion

    #region Log Methods
    /// <summary>
    ///     Writes a line to the <see cref="InternalLogger" /> with <see cref="LogLevel.Information"/>
    /// </summary>
    /// <param name="message">The message to write</param>
    /// <param name="args">Message arguments</param>
    public void Info(string message, params object?[] args)
    {
        if (InternalLogger == null) return;

        try
        {
            using var _ = InstanceId == null ? null : InternalLogger.BeginScope(InstanceId);
            InternalLogger.LogInformation(message, args);
        }
        catch (ObjectDisposedException)
        {
            // Ignore
        }
    }

    /// <summary>
    ///     Writes a line to the <see cref="InternalLogger" /> with <see cref="LogLevel.Warning"/>
    /// </summary>
    /// <param name="message">The message to write</param>
    /// <param name="args">Message arguments</param>
    public void Warn(string message, params object?[] args)
    {
        if (InternalLogger == null) return;

        try
        {
            using var _ = InstanceId == null ? null : InternalLogger.BeginScope(InstanceId);
            InternalLogger.LogWarning(message, args);
        }
        catch (ObjectDisposedException)
        {
            // Ignore
        }
    }

    /// <summary>
    ///     Writes a line to the <see cref="InternalLogger" /> with <see cref="LogLevel.Error"/>
    /// </summary>
    /// <param name="message">The message to write</param>
    /// <param name="args">Message arguments</param>
    public void Error(string message, params object?[] args)
    {
        if (InternalLogger == null) return;

        try
        {
            using var _ = InstanceId == null ? null : InternalLogger.BeginScope(InstanceId);
            InternalLogger.LogError(message, args);
        }
        catch (ObjectDisposedException)
        {
            // Ignore
        }
    }

    /// <summary>
    ///     Writes a line to the <see cref="InternalLogger" /> with <see cref="LogLevel.Error"/>
    /// </summary>
    /// <param name="ex">Exception to attach to log entry</param>
    /// <param name="message">The message to write</param>
    /// <param name="args">Message arguments</param>
    public void Error(Exception ex, string message, params object?[] args)
    {
        if (InternalLogger == null) return;

        try
        {
            using var _ = InstanceId == null ? null : InternalLogger.BeginScope(InstanceId);
            InternalLogger.LogError(ex, message, args);
        }
        catch (ObjectDisposedException)
        {
            // Ignore
        }
    }
    #endregion
}
