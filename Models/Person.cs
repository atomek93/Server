using System;

namespace ASPNetCoreWebAPI.Models
{
    public class Person
    {
        public string Nev { get; set; }
        public string Lakcim { get; set; }
        public string Tajszam { get; set; }
        public string Panasz { get; set; }
        public DateTime Idopont { get; set; }

        public override string ToString()
        {
            return $"{Nev} {Tajszam} {Idopont:yyyy.MM.dd. hh:mm:ss}";
        }
    }
}