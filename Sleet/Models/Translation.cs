using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sleet.Models {
    public class Translation {
        public string Key { get => GetKey(); set => throw new ArgumentException("Key cannot change!"); }
        public bool OriginalLanguage { get => IsOriginalLanguage(); set => OriginalLanguage = value; }
        public LanguageCode Language { get => GetLanguageCode(); set => Language = value; }
        public string Content { get => GetContent(); set => Content = value; }

        public bool IsOriginalLanguage() => OriginalLanguage;
        [Obsolete]
        public void SetOriginalLanguage(bool boolean) => OriginalLanguage = boolean;

        public LanguageCode GetLanguageCode() => Language;

        public string GetContent() => Content;

        public string GetKey() => Key;

        public KeyValuePair<string, string> GetKeyValuePair() => new(Key, Content);

    }

    public enum LanguageCode {
        ZhCn,
        ZhTw,
        EnUs
    }
}
