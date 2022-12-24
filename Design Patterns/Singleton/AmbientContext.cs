using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Singleton
{
    public sealed class BuildingContext : IDisposable
    {
        private static Stack<BuildingContext> stack = new Stack<BuildingContext>();
        public int WallHeight;

        static BuildingContext()
        {
            stack.Push(new BuildingContext(0));
        }

        public BuildingContext(int wallHeight)
        {
            WallHeight = wallHeight;
            stack.Push(this);
        }

        public static BuildingContext Current => stack.Peek();

        public void Dispose()
        {
            if (stack.Count > 1)
                stack.Pop();
        }
    }

    public class Building
    {
        public List<Wall> Walls = new List<Wall>();
    }

    public class Wall
    {
        public Point Start, End;
        public int Height;

        public Wall(Point start, Point end)
        {
            Start = start;
            End = end;
            Height = BuildingContext.Current.WallHeight;
        }
    }

    public struct Point
    {
        private int x, y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
