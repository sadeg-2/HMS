using System.Collections.Generic;

namespace HMS.Core.Dtos
{
    public class Meta
    {
        public int page { get; set; }
        public int pages { get; set; }
        public int perpage { get; set; }
        public int total { get; set; }
        public string sort { get; set; }
        public string field { get; set; }
    }

    public class ResponseDto
    {
        public Meta meta { get; set; }
        public object data { get; set; }
    }
}
