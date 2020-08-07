using System;
using System.Collections.Generic;
using System.Text;

namespace OpenU.Api
{
    public class OpenuMessage
    {
        public List<int> SendTypes { get; set; }
        public string SmsContent { get; set; }
        public DateTime SendDate { get; set; }
        public string Id { get; set; }
        public int UniqueId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int SendType { get; set; }
        public int Type { get; set; }
        public string Content { get; set; }
        public int ContentType { get; set; }
        public bool MarkedAsRead { get; set; }
        public List<OpenuMessageFile> Files { get; set; }
    }

    public class OpenuMessageFile
    {
        public int UniqueId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public int Line { get; set; }
    }
}
