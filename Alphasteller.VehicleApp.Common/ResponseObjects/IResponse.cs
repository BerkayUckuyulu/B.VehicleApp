using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ResponseObjects
{
    //Metot dönüşlerimizde ResponseTypedan,messagedan ve hatalardan oluşan bir obje dönebilmek için ResponseObject yapılanmasını kullandım.
    public interface IResponse
    {
        ResponseType ResponseType { get; set; }
        string Message { get; set; }
    }
}
