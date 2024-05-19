using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListManager
{
    public interface IListManager<T>
    {
        int Count { get; }

        bool Add(T type);

        bool ChangeAt(T type, int index);

        void DeleteAll();

        bool DeleteAt(int index);

        T GetAt(int index);

        string[] ToStringArray();

        List<String> ToStringList();
    }
}
