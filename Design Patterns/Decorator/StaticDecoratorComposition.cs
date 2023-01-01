using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Decorator.Static
{
    public abstract class Shape
    {
        public abstract string AsString();
    }

    public class Circle : Shape
    {
        private float radius;

        public Circle() : this(0)
        {
        }

        public Circle(float radius)
        {
            this.radius = radius;
        }

        public override string AsString() => $"A cricle with radius {radius}";

        public void Resize(float factor)
        {
            radius *= factor;
        }
    }

    public class ColoredShape : Shape
    {
        private Shape shape;
        private string color;

        public ColoredShape(Shape shape, string color)
        {
            this.shape = shape;
            this.color = color;
        }

        public override string AsString()
        {
            return $"{shape.AsString()} has the color {color}";
        }
    }

    public class Square : Shape
    {
        private float side;

        public Square() : this(0)
        {
        }

        public Square(float side)
        {
            this.side = side;
        }

        public override string AsString() => $"A square with side {side}";
    }

    public class TransparentShape<T> : Shape where T : Shape, new()
    {
        T shape = new T();
        private float transparency;

        public TransparentShape() : this(0f)
        {

        }

        public TransparentShape(float transparency)
        {
            this.transparency = transparency;
        }

        public override string AsString()
        {
            return $"{shape.AsString()} has transparency of {transparency * 100}%";
        }
    }

    public class ColoredShape<T> : Shape where T : Shape, new()
    {
        T shape = new T();
        private string color;

        public ColoredShape() : this("black")
        {

        }

        public ColoredShape(string color)
        {
            this.color = color;
        }

        public override string AsString()
        {
            return $"{shape.AsString()} has the color {color}";
        }
    }
}
