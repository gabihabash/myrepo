using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PingYourPackage.API.Model.ResponseModels
{
    public class Result
    {
        public string Message { get; set; }
        public bool IsError { get; set; }

        public Result(string message, bool isError = false)
        {
            this.Message = message;
            this.IsError = isError;
        }
    }
}
