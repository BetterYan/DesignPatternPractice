using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Bridge
{
    public interface IRenderer
    {
        void RenderCircle(float radius);

        void RenderSquare(float width, float height);

        //etc...
    }

    public abstract class Shape
    {
        protected IRenderer renderer;

        public Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public abstract void Draw();

        public abstract void Resize(float factor);
    }

    public class Circle : Shape
    {
        private float radius;

        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }

        public override void Draw()
        {
            renderer.RenderCircle(radius);
        }

        public override void Resize(float factor)
        {
            this.radius *= factor;
        }
    }

    public class CircleRender : IRenderer
    {
        public void RenderCircle(float radius)
        {
            //Something to render the circle;
        }

        public void RenderSquare(float width, float height)
        {
            throw new NotImplementedException();
        }
    }

    public static class Test
    {
        public static void Execute()
        {
            var circleRender = new CircleRender();
            var circle = new Circle(circleRender, 5);
            circle.Draw();
            circle.Resize(2);
            circle.Draw();
        }

        public static void ExecuteWithIoc()
        {
            //define the IoC globally somewhere
            var cb = new ContainerBuilder();
            cb.RegisterType<CircleRender>().As<IRenderer>();
            cb.Register((c, p) => new Circle(c.Resolve<IRenderer>(), p.Positional<float>(0)));
            using var c = cb.Build();

            //take IoC into use
            var circle = c.Resolve<Circle>(new PositionalParameter(0, 5.0f));
            circle.Draw();
            circle.Resize(2);
            circle.Draw();
            //We can see that the bridge pattern is no more than the application of the dependency inversion principle;
            //The best approach to Bridge is still active avoidance, but if that is not possible,
            //simply abstract away both hierarchies and find a way of connecting them.
        }
    }
}