using System;
using System.Collections.Generic;

namespace Sleet.Shared.Models
{
    /// <summary>
    /// Translation�ǵ������룬��Ҫ����ʹ��
    /// </summary>
    public class Translation
    {
        public Guid Id { get; set; }
        public string Key { get ; set ; }
        public bool IsOriginalLanguage { get; set; }
        public Language Language { get; set; }
        public string Content { get; set; }
        public List<Suggestion> Suggestions { get; set; }
    }
}
