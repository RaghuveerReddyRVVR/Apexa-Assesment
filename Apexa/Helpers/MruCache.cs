namespace Apexa.Helpers
{
    public class MruCache<K, V>
    {
        private readonly int _capacity;
        private readonly Dictionary<K, LinkedListNode<(K key, V value)>> _cache;
        private readonly LinkedList<(K key, V value)> _recencyList;

        public MruCache(int capacity = 5)
        {
            _capacity = capacity;
            _cache = new Dictionary<K, LinkedListNode<(K key, V value)>>();
            _recencyList = new LinkedList<(K key, V value)>();
        }

        public V Get(K key)
        {
            if (_cache.TryGetValue(key, out var node))
            {
                _recencyList.Remove(node);
                _recencyList.AddFirst(node);
                return node.Value.value;
            }
            throw new KeyNotFoundException();
        }

        public void Put(K key, V value)
        {
            if (_cache.ContainsKey(key))
            {
                var node = _cache[key];
                _recencyList.Remove(node);
                node.Value = (key, value);
                _recencyList.AddFirst(node);
            }
            else
            {
                if (_cache.Count >= _capacity)
                {
                    var leastRecent = _recencyList.Last;
                    _recencyList.RemoveLast();
                    _cache.Remove(leastRecent.Value.key);
                }

                var newNode = new LinkedListNode<(K key, V value)>((key, value));
                _recencyList.AddFirst(newNode);
                _cache[key] = newNode;
            }
        }

        public void Delete(K key)
        {
            if (_cache.TryGetValue(key, out var node))
            {
                _recencyList.Remove(node);
                _cache.Remove(key);
            }
        }
    }
}
