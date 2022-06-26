using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_MVC.Models
{
    public class ThreadSafeCatalog
    {
        public record Good(Guid Id, string Name);

        private readonly ConcurrentDictionary<Guid /*Id*/, Good> _goodsDict = new();

        public int Count => _goodsDict.Count;
        public void Add(Good good)
        {
            _goodsDict.TryAdd(good.Id, good);
        }



        public void Remove(Good good)
        {
            _goodsDict.TryRemove(good.Id, out _);
        }

        public IReadOnlyCollection<Good> All => _goodsDict.Values.ToArray();
    }
}
