using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Decorator.Dynamic
{
    public interface IShape
    {
        string AsString();
    }

    public class Circle : IShape
    {
        private float radius;

        public Circle(float radius)
        {
            this.radius = radius;
        }

        public string AsString() => $"A cricle with radius {radius}";

        public void Resize(float factor)
        {
            radius *= factor;
        }
    }

    public class ColoredShape : IShape
    {
        private IShape shape;
        private string color;

        public ColoredShape(IShape shape, string color)
        {
            this.shape = shape;
            this.color = color;
        }

        public string AsString()
        {
            return $"{shape.AsString()} has the color {color}";
        }
    }

    public class TransparentShape : IShape
    {
        IShape shape;
        float transparency;

        public TransparentShape(IShape shape, float transparency)
        {
            this.shape = shape;
            this.transparency = transparency;
        }

        public string AsString()
        {
            return $"{shape.AsString()} has {transparency * 100.0}% transparency";
        }
    }

    public class Square : IShape
    {
        private float side;

        public Square(float side)
        {
            this.side = side;
        }

        public string AsString() => $"A square with side {side}";
    }
}
