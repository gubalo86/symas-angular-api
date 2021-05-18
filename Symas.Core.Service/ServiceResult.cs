using System;
using System.Collections.Generic;
using System.Text;

namespace Symas.Core.Service
{
    public static class ServiceResultEnumExtension
    {
        public static bool IsEquals(this Enum value, Enum compareTo) =>
            (value.GetType() == compareTo.GetType() || value.ToString() == compareTo.ToString());
    }

    public class ServiceResult<TModel> where TModel : class
    {
        public bool IsSuccessful { get; } = false;
        public bool IsFound { get; } = false;

        public TModel Data { get; }
        public ServiceErrorResultModel Error { get; set; }

        private ServiceResult(
            bool success,
            bool found,
            TModel data = null,
            ServiceErrorResultModel error = null)
        {
            IsSuccessful = success;
            IsFound = found;
            Data = data;
            Error = error;
        }

        public bool ContainsError(Enum value) =>
            (Error?.Code.GetType() == value.GetType() || Error?.Code.ToString() == value.ToString());

        public void Throw()
        {
            if (IsSuccessful) return;

            throw new ServiceResultException(Error.Code ?? ServiceResultError.UndefinedError, Error.Exception);
        }

        public static ServiceResult<TModel> Success() =>
          ServiceResult<TModel>.Success(null);

        public static ServiceResult<TModel> Success(TModel data) =>
          new ServiceResult<TModel>(true, true, data);

        public static ServiceResult<TModel> NotFound() =>
            new ServiceResult<TModel>(
                false,
                false,
                null,
                new ServiceErrorResultModel(
                    ServiceResultError.NotFound,
                    new Exception("Not Found")));

        public static ServiceResult<TModel> NoResults() =>
            new ServiceResult<TModel>(true, true);

        public static ServiceResult<TModel> Failure(string message = "") =>
          ServiceResult<TModel>.Failure(ServiceResultError.UndefinedError, new Exception(message));

        public static ServiceResult<TModel> Failure(Enum code) =>
          ServiceResult<TModel>.Failure(code, null);

        public static ServiceResult<TModel> Failure(Exception exception) =>
          ServiceResult<TModel>.Failure(ServiceResultError.UndefinedError, exception);

        public static ServiceResult<TModel> Failure(Enum code, Exception exception) =>
          new ServiceResult<TModel>(
            false,
            false,
            null,
            new ServiceErrorResultModel(code, exception));
    }

    public class ServiceErrorResultModel
    {
        public Enum Code { get; }
        public Exception Exception { get; set; }

        public ServiceErrorResultModel(Enum code, Exception exception)
        {
            Code = code;
            Exception = exception;
        }
    }
}
