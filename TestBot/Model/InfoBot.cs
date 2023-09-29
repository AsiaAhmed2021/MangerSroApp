using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBot.Model
{
    public class InfoBot
    {
        public string UserId { get; set; }
        public string Passwrod { get; set; }
        public string Charname { get; set; }
        public string AllyUser { get; set; }
        public override string ToString()
        {
            return $"{Charname} | UserID:{UserId} | UserAll:{AllyUser}";
        }

        public string StrDli => this.ToString();
    }
}
