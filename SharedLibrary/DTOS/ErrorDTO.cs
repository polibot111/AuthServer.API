using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.DTOS
{
    public class ErrorDTO
    {
        public List<String> Errors { get; private set; } = new List<string>();

        public bool IsShow { get; private set; }

        public ErrorDTO()
        {
            Errors = new List<string>();

        }
        public ErrorDTO(string error, bool isShow)
        {
            Errors.Add(error);
            isShow = true;
        }

        public ErrorDTO(List<string> errors, bool isShow)
        {
            Errors = errors;
            IsShow = isShow;
        }




        
    }
}
