using System.Collections.Generic;
using System.ComponentModel;

namespace WuxiaReader.Shared
{
    public class Chapter : INotifyPropertyChanged
    {
        public Chapter(int number, List<ChapterElement> elements)
        {
            Number = number;
            Elements = elements;
        }

        public int Number { get; }
        public List<ChapterElement> Elements { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    
    public class ChapterComparer : Comparer<Chapter>
    {
        private static ChapterComparer _instance;
        public static ChapterComparer Comparer => _instance ??= new ChapterComparer();
        
        public override int Compare(Chapter x, Chapter y)
        {
            return (x, y) switch
            {
                (Chapter a, Chapter b) => a.Number.CompareTo(b.Number),
                (null, null) => 0,
                (_, null) => 1,
                (null, _) => -1
            };
        }
    }
}