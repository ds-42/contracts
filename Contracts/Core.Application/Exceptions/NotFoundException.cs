using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Exceptions;

public class NotFoundException : BaseException
{
    public NotFoundException(string message) : base(new { Message = message }, HttpStatusCode.Forbidden)
    {
    }
}


