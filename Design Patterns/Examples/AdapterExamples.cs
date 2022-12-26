using Design_Patterns.Adapter;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AdapterExamples
{
    private static readonly List<VectorObject> vectorObjects = new List<VectorObject>()
    {
        new VectorRectangle(1,1,10,10),
        new VectorRectangle(3,3,6,6)
    };

    public static void TestVectorRaster()
    {
        Convert();
        Convert();

        void DrawPoint(Point p)
        {
            Console.Write(".");
        }

        void Convert()
        {
            foreach (var vo in vectorObjects)
            {
                foreach (var line in vo)
                {
                    var adapter = new LineToPointAdapter(line);
                    adapter.ForEach(DrawPoint);
                }
            }
        }
    }

    public static void TestGenericValueAdapter()
    {
        var v = new Vector2i();
        v[0] = 0;

        var vv = new Vector2i();

        var result = v + vv;
    }
}