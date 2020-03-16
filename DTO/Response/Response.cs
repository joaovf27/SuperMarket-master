using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Response
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public string GetErrorMessage()
        {
            StringBuilder builder = new StringBuilder();
            foreach (string item in this.Errors)
            {
                builder.Append(item);
            }
            return builder.ToString();
        }
        public bool HasErrors()
        {
            return this.Errors.Count > 0;
        }
        public Response()
        {
            this.Errors = new List<string>();
        }
    }
}
