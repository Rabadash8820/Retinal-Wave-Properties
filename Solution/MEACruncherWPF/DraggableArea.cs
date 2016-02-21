using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;

namespace MEACruncher {
    public partial class DraggableArea : ContentControl {
        // HIDDEN FIELDS
        private bool _mouseDown;
        private Point _posOutThere;
        private Point _startOutThere;
        private int _rightBound, _leftBound, _topBound, _bottomBound;
        private FrameworkElement _bounds;
        private TranslateTransform _trans;

        // CONSTRUCTORS
        public DraggableArea() {
            // Postpone initialization until all child elements are created
            Initialized += DraggableArea_Initialized;
        }
        
        // EVENT HANDLERS
        private void DraggableArea_Initialized(object sender, EventArgs e) {
            init();
        }
        private void DraggableArea_MouseDown(object sender, MouseButtonEventArgs e) {
            // Do nothing if the source element is disabled
            UIElement elem = (UIElement)sender;
            if (!elem.IsEnabled)
                return;
            
            // Cache the mouse's position in here (inside this DraggableArea) and out there (in the bounding region)
            _startOutThere = new Point(_trans.X, _trans.Y);
            _posOutThere = e.GetPosition(_bounds);

            // Cache values for later bounds-checking
            Point posInHere = e.GetPosition(this);
            _leftBound = (int)posInHere.X;
            _rightBound = (int)(_bounds.ActualWidth - (this.RenderSize.Width - posInHere.X));
            _topBound = (int)posInHere.Y;
            _bottomBound = (int)(_bounds.ActualHeight - (this.RenderSize.Height - posInHere.Y));

            // Capture Mouse
            _mouseDown = true;
            elem.CaptureMouse();
        }
        private void DraggableArea_MouseMove(object sender, MouseEventArgs e) {
            if (_mouseDown)
                drag(_trans, e.GetPosition(_bounds));
        }
        private void DraggableArea_MouseUp(object sender, MouseButtonEventArgs e) {
            // Do nothing if the source element is disabled
            UIElement elem = (UIElement)sender;
            if (!elem.IsEnabled)
                return;

            // Release Mouse
            _mouseDown = false;
            elem.ReleaseMouseCapture();
        }

        // HIDDEN FUNCTIONS
        private void init() {
            // Cache this DraggableArea's bounding region and its TranslateTransform (might need to be created first)
            _bounds = this.Parent as FrameworkElement;
            _trans = getTranslateTransform(this);
            
            // Register mouse events
            MouseDown += DraggableArea_MouseDown;
            MouseMove += DraggableArea_MouseMove;
            MouseUp   += DraggableArea_MouseUp;
        }
        private void drag(TranslateTransform transform, Point mousePosition) {
            // Drag in the x-direction, within the bounding region
            if (_leftBound <= mousePosition.X && mousePosition.X < _rightBound) {
                double dx = mousePosition.X - _posOutThere.X;
                transform.X = _startOutThere.X + dx;
            }

            // Drag in the y-direction, within the bounding region
            if (_topBound <= mousePosition.Y && mousePosition.Y < _bottomBound) {
                double dy = (mousePosition.Y - _posOutThere.Y);
                transform.Y = _startOutThere.Y + dy;
            }
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

            // Otherwise, get the RenderTransform if its already a TranslateTransform,
            // or first create a new TransformGroup and add the TranslateTransform part if need be
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
