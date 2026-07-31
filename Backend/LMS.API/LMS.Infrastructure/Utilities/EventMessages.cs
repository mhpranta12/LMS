using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.Utilities
{
    public class EventMessages
    {
        public string Insert(string name)
        {
            return $"" + name + " added successfully.";
        }
        public string DataExists(string name)
        {
            return $"" + name + " already exists.";
        }
        public string Update(string name)
        {
            return $"" + name + " updated successfully.";
        }
        public string Delete(string name)
        {
            return $"" + name + " deleted successfully.";
        }
        public string Notfound(string name)
        {
            return $"" + name + " not found.";
        }
        public string UnAuthorized(string name)
        {
            return $"User is not authorized to view particular type of " + name + ".";
        }
        public string Required = "Some fields are required";
        public string Get = "Get successfully";
        public string Error = "Something went wrong";
        public string Message(string name)
        {
            return $"" + name + "";
        }
    }
}
