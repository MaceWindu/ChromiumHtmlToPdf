﻿//
// ChromeException.cs
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
using System.Runtime.Serialization;
using ChromiumHtmlToPdfLib.Protocol;

namespace ChromiumHtmlToPdfLib.Exceptions;

/// <summary>
///     Raised when an error is returned from Chromium
/// </summary>
[Serializable]
public class ChromiumException : Exception
{
    /// <summary>
    ///     Returns the error code that is returned from Chromium
    /// </summary>
    public double Code { get; }

    /// <summary>
    ///     Raised when an error is returned from Chromium
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected ChromiumException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    /// <summary>
    ///     Raised when an error is returned from Chromium
    /// </summary>
    internal ChromiumException()
    {
    }

    /// <summary>
    ///     Raised when an error is returned from Chromium
    /// </summary>
    /// <param name="error"></param>
    internal ChromiumException(Error error) : base(error.InnerError.Message)
    {
        Code = error.InnerError.Code;
    }

    /// <summary>
    ///     Raised when an error is returned from Chromium
    /// </summary>
    /// <param name="message"></param>
    internal ChromiumException(string message) : base(message)
    {
    }

    /// <summary>
    ///     Raised when an error is returned from Chromium
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    internal ChromiumException(string message, Exception innerException) : base(message, innerException)
    {
    }
}