using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsGraphicsEditor.Servises
{
    public interface IDraw
    {
        public void Drawing(Graphics gr, bool onlyLast = false);
        public void StartPoint(Point point);
        public Point GetStartPoint();
        public void SetDefaultPen(Pen pen);
        public Pen GetDefaultPen();
        public void SetBackgroundColor(Color color);
        public Color GetBackgroundColor();
        public void Line(Point lastPoint, bool Draft = false);
        public void Pencil(Point point);
        public void Rectangle(Point lastPoint, bool Draft = false);
        public void Ellipse(Point lastPoint, bool Draft = false);
        public void SaveInBmp(string fileName);
        public void LoadFromBmp(string fileName);
        public void CancelDrawnDown();
        public bool CanCancelDrawnDown();
        public void CancelDrawnUp();
        public bool CanCancelDrawnUp();
        public void Clear();
        public void ColorInversion();
        public void SetTimeSleep(int time);
    }
}
