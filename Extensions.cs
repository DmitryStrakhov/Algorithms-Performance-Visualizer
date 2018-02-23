using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithms_Performance_Visualizer {
    public static class PointExtensions {
        public static Point OffsetWith(this Point @this, int x, int y) {
            return new Point(@this.X + x, @this.Y + y);
        }
        public static Point OffsetWith(this Point @this, Point point) {
            return OffsetWith(@this, point.X, point.Y);
        }
        public static Point OffsetWith(this Point @this, int offset) {
            return new Point(@this.X + offset, @this.Y + offset);
        }
        public static Rectangle CreateRect(this Point @this, Size size) {
            return CreateRect(@this, size.Width, size.Height);
        }
        public static Rectangle CreateRect(this Point @this, int width, int height) {
            return new Rectangle(@this.X - width / 2, @this.Y - height / 2, width, height);
        }
    }

    public static class RectangleExtensions {
        public static Rectangle CheckRect(this Rectangle @this) {
            Rectangle rect = @this;
            rect.X = Math.Max(0, rect.X);
            rect.Y = Math.Max(0, rect.Y);
            rect.Width = Math.Max(0, rect.Width);
            rect.Height = Math.Max(0, rect.Height);
            return rect;
        }
        public static Rectangle ApplyPadding(this Rectangle @this, Padding padding) {
            Rectangle rect = @this;
            rect.X += padding.Left;
            rect.Y += padding.Top;
            rect.Width -= padding.Horizontal;
            rect.Height -= padding.Vertical;
            return rect.CheckRect();
        }
        public static Rectangle InflateWith(this Rectangle @this, int x, int y) {
            return Rectangle.Inflate(@this, x, y);
        }
        public static Point GetPivot(this Rectangle @this) {
            return new Point(@this.X + @this.Width / 2, @this.Y + @this.Height / 2);
        }
        public static bool HasZeroDimension(this Rectangle @this) {
            return @this.Width == 0 || @this.Height == 0;
        }
        public static Rectangle OffsetWith(this Rectangle @this, int x, int y) {
            return new Rectangle(@this.X + x, @this.Y + y, @this.Width, @this.Height);
        }
    }

    public static class PaddingExtensions {
        public static Padding CheckPadding(this Padding @this) {
            Padding padding = @this;
            padding.Left = Math.Max(0, padding.Left);
            padding.Right = Math.Max(0, padding.Right);
            padding.Top = Math.Max(0, padding.Top);
            padding.Bottom = Math.Max(0, padding.Bottom);
            return padding;
        }
    }

    public static class ControlExtensions {
        public static void Bind<T>(this Control control, string propertyName, T dataSource, string dataMember, DataSourceUpdateMode updateMode = DataSourceUpdateMode.OnPropertyChanged, ConvertEventHandler parseDelegate = null, ConvertEventHandler formatDelegate = null) {
            Binding binding = control.DataBindings.Add(propertyName, dataSource, dataMember, true, updateMode);
            if(parseDelegate != null) {
                binding.Parse += parseDelegate;
            }
            if(formatDelegate != null) {
                binding.Format += formatDelegate;
            }
        }
        public static T GetControl<T>(this Control view, string instanceName) where T : Control {
            FieldInfo fieldInfo = GetFieldCore(view.GetType(), instanceName);
            if(fieldInfo == null) {
                throw new InvalidOperationException();
            }
            return (T)fieldInfo.GetValue(view);
        }
        static FieldInfo GetFieldCore(Type type, string instanceName) {
            Type targetType = type;
            while(targetType != typeof(object)) {
                FieldInfo fieldInfo = targetType.GetField(instanceName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if(fieldInfo != null)
                    return fieldInfo;
                targetType = targetType.BaseType;
            }
            return null;
        }
    }

    public abstract class EquatableObject<T> where T : EquatableObject<T> {
        public EquatableObject() {
        }
        public override sealed bool Equals(object obj) {
            T other = obj as T;
            return other != null && EqualsTo(other);
        }
        public override int GetHashCode() {
            return base.GetHashCode();
        }
        protected abstract bool EqualsTo(T other);
    }

    public static class EnumerableExtensions {
        public static void ForEach<T>(this IEnumerable<T> @this, Action<T> action) {
            foreach(var item in @this) {
                action(item);
            }
        }
        public static T[] DoClone<T>(this T[] @this) {
            return (T[])@this.Clone();
        }
    }

    public class MathUtils {
        public static int Round(double value) {
            return (int)(value + (value >= 0 ? 0.5 : -0.5));
        }
    }
}
