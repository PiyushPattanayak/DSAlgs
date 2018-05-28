using System;
namespace BasicAlgorithms.UnionFind
{
    public interface IUnionFind
    {
        int Count { get; }
        int Find(int p);
        bool Connected(int p, int q);
        void Union(int p, int q);
        void Print();
    }
}
