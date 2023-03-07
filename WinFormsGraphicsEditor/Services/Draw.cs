using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WinFormsGraphicsEditor.Servises
{
    public class Draw : IDraw
    {
        class DrawPathComponent
        {
            public Pen pen { get; set; }
            public GraphicsPath graphicsPath { get; set; }
        }

        private List<DrawPathComponent> _components {  get; set; }
        private List<DrawPathComponent> _undoneChangesComponents { get; set; }
        private Point _startPoint { get; set; }
        private bool _createPath { get; set; }
        private Color _color { get; set; }
        private Pen _defaultPen { get; set; }
        private System.Drawing.Image? _sevedImage { get; set; }
        private int _stopTime { get; set; }
        private DrawPathComponent? _draftPath { get; set; }
        public Draw()
        {
            _components = new List<DrawPathComponent>();
            _undoneChangesComponents = new List<DrawPathComponent>();
            _startPoint = Point.Empty;
            _color = Color.WhiteSmoke;
            _draftPath = null;
            _defaultPen = Pens.Black;
            _sevedImage = null;
            _stopTime = 1000;
        }
        public void Line(Point lastPoint, bool Draft = false)
        {
            if (_startPoint == Point.Empty)
            {
                return;
            }
            GraphicsPath line = new GraphicsPath();
            line.AddLine(_startPoint, lastPoint);
            
            if (Draft)
            {
                _draftPath = new DrawPathComponent();
                _draftPath.pen = _defaultPen;
                _draftPath.graphicsPath = line;
            }
            else
            {
                _draftPath = null;
                AddElement(_defaultPen, line);
            }
            
        }
        public void AddElement(Pen pen, GraphicsPath graphicsPath)
        {
            _components.Add(new DrawPathComponent() { pen = pen, graphicsPath = graphicsPath });
        }
        public void Drawing(Graphics gr, bool onlyLast = false)
        {
            if (onlyLast)
            {
                if (_components.Any())
                {
                    var component = _components[_components.Count - 1];
                    gr.DrawPath(component.pen, component.graphicsPath); 
                }
                return;
            }

            if (_draftPath != null)
            {
                
                gr.SetClip(_draftPath.graphicsPath.GetBounds());
                //gr.DrawPath(_draftPath.pen, _draftPath.graphicsPath);
            }


            gr.Clear(_color);
            if (_sevedImage != null)
            {
                gr.DrawImage(_sevedImage, new PointF(0.0F, 0.0F));
            }
           

            foreach (var component in _components) 
            {
                gr.DrawPath(component.pen, component.graphicsPath);
            }

            if (_draftPath != null)
            {
                gr.ResetClip();
                gr.DrawPath(_draftPath.pen, _draftPath.graphicsPath);
            }
        }

        public void StartPoint(Point point)
        {
            _startPoint = point;
            _createPath = true;
        }

        public Point GetStartPoint()
        {
            return _startPoint;
        }

        public void Pencil(Point point)
        {
            if (_startPoint == Point.Empty)
            {
                return;
            }

            if (_createPath)
            {
                GraphicsPath lines = new GraphicsPath();
                lines.AddLine(_startPoint, point);
                AddElement(_defaultPen, lines);
                _createPath = false;
            }
            else
            {
                _components[_components.Count-1].graphicsPath.AddLine(_startPoint, point);
            }

            _startPoint = point;

        }

        public void Rectangle(Point lastPoint, bool Draft = false)
        {
            if (_startPoint == Point.Empty)
            {
                return;
            }
            GraphicsPath rectangle = new GraphicsPath();
            var rect = new Rectangle(_startPoint, new Size(lastPoint.X - _startPoint.X, lastPoint.Y - _startPoint.Y));
            rectangle.AddRectangle(rect);

            if (Draft)
            {
                _draftPath = new DrawPathComponent();
                _draftPath.pen = _defaultPen;
                _draftPath.graphicsPath = rectangle;
            }
            else
            {
                _draftPath = null;
                AddElement(_defaultPen, rectangle);
            }
        }

        public void Ellipse(Point lastPoint, bool Draft = false)
        {
            if (_startPoint == Point.Empty)
            {
                return;
            }
            GraphicsPath circle = new GraphicsPath();
            var rect = new Rectangle(_startPoint, new Size(lastPoint.X - _startPoint.X, lastPoint.Y - _startPoint.Y));
            circle.AddEllipse(rect);

            if (Draft)
            {
                _draftPath = new DrawPathComponent();
                _draftPath.pen = _defaultPen;
                _draftPath.graphicsPath = circle;
            }
            else
            {
                _draftPath = null;
                AddElement(_defaultPen, circle);
            }
        }

        public void SetDefaultPen(Pen pen)
        {
            _defaultPen = pen;
        }

        public Pen GetDefaultPen()
        {
            return _defaultPen;
        }

        public void SetBackgroundColor(Color color)
        {
            _color = color;
        }

        public Color GetBackgroundColor()
        {
            return _color;
        }
        private Rectangle SizeOfTheDrawingArea()
        {
            var rectangle = new RectangleF();
            foreach (var component in _components)
            {
                var tempRect = component.graphicsPath.GetBounds();
                rectangle = RectangleF.Union(rectangle, tempRect);
            }

            if (_draftPath != null)
            {
                rectangle = RectangleF.Union(rectangle, _draftPath.graphicsPath.GetBounds());
            }

            if (_sevedImage != null)
            {
                var tempRect = new RectangleF(new Point(0, 0), _sevedImage.Size);
                rectangle = RectangleF.Union(rectangle, tempRect);
            }

            Rectangle sizeRectangle = System.Drawing.Rectangle.Round(rectangle);
            return sizeRectangle;
        }
        public void SaveInBmp(string fileName)
        {
            var bmpRectangle = SizeOfTheDrawingArea();
            Bitmap PictureImg = new Bitmap(bmpRectangle.Width+2, bmpRectangle.Height+2);
            Graphics graphics = Graphics.FromImage(PictureImg);
            this.Drawing(graphics);
            PictureImg.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
            var image = System.Drawing.Image.FromFile(fileName);
            graphics.Dispose();

            _sevedImage = image;
            _draftPath = null;
            _components.Clear();
            _undoneChangesComponents.Clear();
        }

        public void LoadFromBmp(string fileName)
        {
            var image = System.Drawing.Image.FromFile(fileName);
            _sevedImage = image;
            _draftPath = null;
            _components.Clear();
            _undoneChangesComponents.Clear();
        }

        public void CancelDrawnDown()
        {
            if(_components.Count > 0)
            { 
                var buff = _components[_components.Count -1]; 
                _undoneChangesComponents.Add(buff);
                _components.RemoveAt(_components.Count - 1);
            }
        }

        public bool CanCancelDrawnDown()
        {
            return _components.Any();
        }

        public void CancelDrawnUp()
        {
            if (_undoneChangesComponents.Count > 0)
            {
                var buff = _undoneChangesComponents[_undoneChangesComponents.Count - 1];
                _components.Add(buff);
                _undoneChangesComponents.RemoveAt(_undoneChangesComponents.Count - 1);
            }
        }

        public bool CanCancelDrawnUp()
        {
            return _undoneChangesComponents.Any();
        }

        public void Clear()
        {
            _sevedImage = null;
            _draftPath = null;
            _components.Clear();
            _undoneChangesComponents.Clear();
        }

        public void ColorInversion()
        {
            _color = Color.FromArgb(_color.A, 0xFF - _color.R, 0xFF - _color.G, 0xFF - _color.B);

            if (_sevedImage != null)
            {
                var bitmap = new Bitmap(_sevedImage);
                for(int i = 0; i < bitmap.Width; i++ )
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        var color = bitmap.GetPixel( i, j);
                        color = Color.FromArgb(color.A, 0xFF - color.R, 0xFF - color.G, 0xFF - color.B);
                        bitmap.SetPixel(i, j, color);
                        _sevedImage = (System.Drawing.Image)bitmap;
                    }
                }
            }
            Thread.Sleep(_stopTime);
            //Task.Delay(_stopTime);

            if (_draftPath != null)
            {
                var color = _draftPath.pen.Color;
                color = Color.FromArgb(color.A, 0xFF - color.R, 0xFF - color.G, 0xFF - color.B);
                var sizePen = _draftPath.pen.Width;
                _draftPath.pen = new Pen(color, sizePen);
            }
            Thread.Sleep(_stopTime);
            //Task.Delay(_stopTime);

            foreach (var component in _components)
            {
                var color = component.pen.Color;
                color = Color.FromArgb(color.A, 0xFF - color.R, 0xFF - color.G, 0xFF - color.B);
                var sizePen = component.pen.Width;
                component.pen = new Pen(color, sizePen);
            }
            Thread.Sleep(_stopTime);
            //Task.Delay(_stopTime);

            foreach (var component in _undoneChangesComponents)
            {
                var color = component.pen.Color;
                color = Color.FromArgb(color.A, 0xFF - color.R, 0xFF - color.G, 0xFF - color.B);
                var sizePen = component.pen.Width;
                component.pen = new Pen(color, sizePen);
            }
            Thread.Sleep(_stopTime);
            //Task.Delay(_stopTime);
        }

        public void SetTimeSleep(int time)
        {
            _stopTime = time;
        }
    }
}
