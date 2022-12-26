using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Adapter
{
    //Vector2f, Vector3i

    public interface IInteger
    {
        int Value { get; }
    }

    public class Two : IInteger
    {
        public int Value => 2;
    }

    public class Three : IInteger
    {
        public int Value => 3;
    }

    public class Vector<TSelf, T, D>
        where D : IInteger, new()
        where TSelf : Vector<TSelf, T, D>, new ()
    {
        public T this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }

        protected T[] data;

        public Vector()
        {
            data = new T[new D().Value];
        }

        public Vector(params T[] values)
        {
            var requiredSize = new D().Value;
            data = new T[requiredSize];

            var providedSize = values.Length;

            for (int i = 0; i < Math.Min(requiredSize, providedSize); i++)
            {
                data[i] = values[i];
            }
        }

        public static TSelf Create(params T[] values)
        {
            var result = new TSelf();

            var requiredSize = new D().Value;
            result.data = new T[requiredSize];

            var providedSize = values.Length;

            for (int i = 0; i < Math.Min(requiredSize, providedSize); i++)
            {
                result.data[i] = values[i];
            }

            return result;
        }
    }

    public class VectorOfInt<D> : Vector<VectorOfInt<D>, int, D>
        where D : IInteger, new()
    {
        public VectorOfInt()
        {
        }

        public VectorOfInt(params int[] values) : base(values)
        {
        }

        public static VectorOfInt<D> operator +
            (VectorOfInt<D> left, VectorOfInt<D> right)
        {
            var result = new VectorOfInt<D>();
            var dim = new D().Value;

            for (int i = 0; i < dim; i++)
            {
                result[i] = left[i] + right[i];
            }

            return result;
        }
    }

    public class VectorOfFloat<TSelf, D> : Vector<TSelf, float, D>
    where D : IInteger, new()
    where TSelf : Vector<TSelf, float, D>, new()
    {
    }

    public class Vector3f : VectorOfFloat<Vector3f, Three>
    {

    }

    public class Vector2i : VectorOfInt<Two>
    {
        public Vector2i()
        {
        }

        public Vector2i(params int[] values) : base(values)
        {
        }
    }
}
