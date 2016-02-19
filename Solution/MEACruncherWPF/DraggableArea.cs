using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;

namespace MEACruncher {
    public partial class DraggableArea : ContentControl {
        // HIDDEN FIELDS
        private bool _mouseDown;
        private Point _mousePos;
        private Point _borderPos;
        private Window _window;
        private TranslateTransform _trans;

        // CONSTRUCTORS
        public DraggableArea() {
            Initialized += DraggableArea_Initialized;
        }
        
        // EVENT HANDLERS
        private void DraggableArea_Initialized(object sender, System.EventArgs e) {
            if (Content is FrameworkElement)
                reset(Content as FrameworkElement);
        }
        private void DraggableArea_MouseDown(object sender, MouseButtonEventArgs e) {
            UIElement elem = (UIElement)sender;
            if (!elem.IsEnabled)
                return;

            _mouseDown = true;
            _mousePos = e.GetPosition(_window);
            _borderPos = new Point(_trans.X, _trans.Y);

            elem.CaptureMouse();
        }
        private void DraggableArea_MouseMove(object sender, MouseEventArgs e) {
            if (_mouseDown)
                drag(_trans, e.GetPosition(_window));
        }
        private void DraggableArea_MouseUp(object sender, MouseButtonEventArgs e) {
            UIElement elem = (UIElement)sender;
            if (!elem.IsEnabled)
                return;

            _mouseDown = false;
            elem.ReleaseMouseCapture();
        }

        // HIDDEN FUNCTIONS
        private void reset(FrameworkElement element) {
            _window = Window.GetWindow(element);
            _trans = getTranslateTransform(element);
            
            MouseDown += DraggableArea_MouseDown;
            MouseMove += DraggableArea_MouseMove;
            MouseUp   += DraggableArea_MouseUp;
        }
        private void drag(TranslateTransform transform, Point mousePosition) {
            // If it was found then translate the UIElement
            double dx = (mousePosition.X - _mousePos.X);
            double dy = (mousePosition.Y - _mousePos.Y);
            transform.X = _borderPos.X + dx;
            transform.Y = _borderPos.Y + dy;
        }
        private TranslateTransform getTranslateTransform(FrameworkElement element) {
            TranslateTransform trans = null;
            TransformGroup grp = element.RenderTransform as TransformGroup;

            // If the UIElement's RenderTransform is a TransformGroup, get the TranslateTransform part (creating it first if need be)
            if (grp != null) {
                trans = grp.Children.Where(t => t is TranslateTransform).SingleOrDefault() as TranslateTransform;
                if (trans == null) {
                    trans = new TranslateTransform();
                    grp.Children.Add(trans);
                }
            }

            // Otherwise, get the RenderTransform if its already a TranslateTransform, or first create a new TransformGroup and add this part if need be
            else {
                trans = element.RenderTransform as TranslateTransform;
                if (trans == null) {
                    grp = new TransformGroup();
                    grp.Children.Add(element.RenderTransform);
                    trans = new TranslateTransform();
                    grp.Children.Add(trans);
                    element.RenderTransform = grp;
                }
            }

            return trans;
        }
    }

}
