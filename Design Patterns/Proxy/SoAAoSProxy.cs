using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Proxy
{
    //CompositeProxy
    class Monster
    {
        public byte Age;
        public int X, Y;
    }

    public class Monsters
    {
        private readonly int size;
        private byte[] age;
        private int[] x, y;

        public Monsters(int size)
        {
            this.size = size;
            age = new byte[size];
            x = new int[size];
            y = new int[size];
        }

        public struct MonsterPxoxy
        {
            private readonly Monsters monsters;
            private readonly int index;

            public MonsterPxoxy(Monsters monsters, int index)
            {
                this.monsters = monsters;
                this.index = index;
            }

            public ref byte Age => ref monsters.age[index];
            public ref int x => ref monsters.x[index];
            public ref int y => ref monsters.y[index];
        }

        public IEnumerator<MonsterPxoxy> GetEnumerator()
        {
            for (int pos = 0; pos < size; pos++)
                yield return new MonsterPxoxy(this, pos);
        }
    }
}
