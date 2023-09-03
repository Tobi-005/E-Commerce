
using SQLitePCL;

namespace API.Errors
{
    public class APIResponse
    {
        public APIResponse(int statuscode, string message=null)
        {
            this.Statuscode = statuscode;
            this.Message = message ?? GetDefaultMessage(statuscode);

        }

        

        public int Statuscode { get; set; }

        public string Message { get; set; }

        private string GetDefaultMessage(int statuscode)
        {
            return statuscode switch
            {
                400 => " A Bad Request you have made",
                401 => "You are not authorized ",
                404 => "Resource not found",
                500 => "Errors are part of dark side, error leads to anger, anger leads to hate, hate leads to change, change needs to happen",
                _ => null
            };
        }
    }
}