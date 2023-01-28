using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Observer
{
    public class Button
    {
        public event EventHandler Clicked;

        public void Fire()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Window
    {
        public Window(Button button)
        {
            //Avaiblable in .NET Framework
            //WeakEventManager<Button, EventArgs>
                //.AddHandler(button, "Clicked", ButtonClicked);
            button.Clicked += ButtonClicked;
        }

        private void ButtonClicked(object? sender, EventArgs e)
        {
            Console.WriteLine("Button clicked (Window Handler)");
        }

        ~Window()
        {
            Console.WriteLine("Window finalize");
        }
    }
}
