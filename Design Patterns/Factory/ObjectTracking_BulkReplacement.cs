using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Factory
{
    public class ObjectTracking_BulkReplacement
    {
        public interface ITheme
        {
            string TextColor { get; }
            string BrgColor { get; }
        }

        public class LightTheme : ITheme
        {
            public string TextColor => "black";

            public string BrgColor => "white";
        }

        public class DarkTheme : ITheme
        {
            public string TextColor => "white";

            public string BrgColor => "dark grey";
        }

        public class TrackingThemeFactory
        {
            private readonly List<WeakReference<ITheme>> themes = new();

            public ITheme CreateTheme(bool dark)
            {
                ITheme theme = dark ? new DarkTheme() : new LightTheme();
                themes.Add(new WeakReference<ITheme>(theme));
                return theme;
            }

            public string Info
            {
                get
                {
                    var sb = new StringBuilder();
                    foreach (var reference in themes)
                    {
                        if (reference.TryGetTarget(out var theme))
                        {
                            bool dark = theme is DarkTheme;
                            sb.Append(dark ? "Dark" : "Light")
                                .AppendLine(" theme");
                        }
                    }
                    return sb.ToString();
                }
            }
        }

        public class Ref<T> where T : class
        {
            public T Value;

            public Ref(T value)
            {
                Value = value;
            }
        }

        public class ReplacableThemeFactory
        {
            private readonly List<WeakReference<Ref<ITheme>>> themes = new();

            private ITheme CreateThemeImpl(bool dark)
            {
                return dark ? new DarkTheme() : new LightTheme();
            }

            public Ref<ITheme> CreateTheme(bool dark)
            {
                var r = new Ref<ITheme>(CreateThemeImpl(dark));
                themes.Add(new(r));
                return r;
            }

            public void ReplaceTheme(bool dark)
            {
                foreach (var wr in themes)
                {
                    if (wr.TryGetTarget(out var reference))
                    {
                        reference.Value = CreateThemeImpl(dark);
                    }
                }
            }
        }
    }
}
