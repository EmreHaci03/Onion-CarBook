using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.AppUserResults
{
    public class GetCheckAppUserQueryResult
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }
        public bool IsExist { get; set; }
    }
}
