﻿using CongestionTaxCalculator.Infrastructure.Const;

namespace CongestionTaxCalculator.Application.Responses
{
    public class BaseCommandResponse
    {
        public object Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
       



        public void Success(object data = null , string message = null, List<string> errors = null)
        {
            IsSuccess = true;
            Message = message ?? DefaultConst.Success;
            Errors = errors;
            Data = data;
           
        }


        public void Failure(object data = null , string message = null , List<string> errors = null)
        {
            IsSuccess = false;
            Message = message ?? DefaultConst.Failure;
            Errors = errors;
            Data = data;
            
        }

    }
}
