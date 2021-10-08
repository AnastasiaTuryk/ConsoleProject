using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        public List<T> Data { get; } = new List<T>();
        public void Add(T item)
        {
            Data.Add(item);
        }
        public void Sort()
        {
            Data.Sort();
        }
    }
}
