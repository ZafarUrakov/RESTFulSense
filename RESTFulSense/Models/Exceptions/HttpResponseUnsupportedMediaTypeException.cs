// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Net.Http;

namespace RESTFulSense.Exceptions
{
    public class HttpResponseUnsupportedMediaTypeException : HttpResponseException
    {
        public HttpResponseUnsupportedMediaTypeException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }
    }
}
