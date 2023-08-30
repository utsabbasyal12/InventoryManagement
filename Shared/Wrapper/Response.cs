﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Wrapper
{
    public class Response : IResponse
    {
        public Response()
        {

        }
        public string? Messages { get; set; }
        public bool Succeeded { get; set; }

        public static IResponse Fail()
        {
            return new Response { Succeeded = false };
        }

        public static IResponse Fail(string? message)
        {
            return new Response { Succeeded = false, Messages = message };
        }

        public static Task<IResponse> FailAsync()
        {
            return Task.FromResult(Fail());
        }

        public static Task<IResponse> FailAsync(string? message)
        {
            return Task.FromResult(Fail(message));
        }
        
        public static IResponse Success()
        {
            return new Response { Succeeded = true };
        }

        public static IResponse Success(string message)
        {
            return new Response { Succeeded = true, Messages = message };
        }

        public static Task<IResponse> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public static Task<IResponse> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
        }
    }

    public class Response<T> : Response, IResponse<T>
    {
        public Response()
        {
        }
        public T Data { get; set; }

        public new static Response<T> Fail()
        {
            return new Response<T> { Succeeded = false };
        }

        public new static Response<T> Fail(string? message)
        {
            return new Response<T> { Succeeded = false, Messages = message };
        }

        public new static Task<Response<T>> FailAsync()
        {
            return Task.FromResult(Fail());
        }

        public new static Task<Response<T>> FailAsync(string? message)
        {
            return Task.FromResult(Fail(message));
        }

        public new static Response<T> Success()
        {
            return new Response<T> { Succeeded = true };
        }

        public new static Response<T> Success(string? message)
        {
            return new Response<T> { Succeeded = true, Messages = message };
        }

        public static Response<T> Success(T data)
        {
            return new Response<T> { Succeeded = true, Data = data };
        }

        public static Response<T> Success(T data, string? message)
        {
            return new Response<T> { Succeeded = true, Data = data, Messages = message };
        }
        public new static Task<Response<T>> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public new static Task<Response<T>> SuccessAsync(string? message)
        {
            return Task.FromResult(Success(message));
        }

        public static Task<Response<T>> SuccessAsync(T data)
        {
            return Task.FromResult(Success(data));
        }

        public static Task<Response<T>> SuccessAsync(T data, string? message)
        {
            return Task.FromResult(Success(data, message));
        }
    }
}
