﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Archemy.Helper.Models
{
    public class ResultViewModel
    {
        public ResultViewModel()
        {
            IsError = false;
            StatusCode = 200;
            Message = "Completed";
        }

        public bool IsError { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object ModelError { get; set; }
    }
}
