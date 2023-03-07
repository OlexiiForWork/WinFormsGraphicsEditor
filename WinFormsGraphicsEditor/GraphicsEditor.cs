using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using WinFormsGraphicsEditor.Servises;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;
using WinFormsGraphicsEditor.Helpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace WinFormsGraphicsEditor
{
    public partial class GraphicsEditor : Form
    {
        private readonly IDraw _draw;
        private bool _drawing = false;
        private DrawType _drawType;

        public GraphicsEditor(IDraw draw)
        {
            InitializeComponent();
            _draw = draw ?? throw new ArgumentNullException(nameof(draw));
            _drawType = DrawType.None;
            //toolStripProgressBar1.Size = new Size(statusStrip1.Size.Width - 20, 16);
            timer1.Enabled = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            _draw.Drawing(e.Graphics);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_drawType != DrawType.None)
                {
                    _drawing = true;
                    _draw.StartPoint(e.Location);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(panel2, e.Location, ToolStripDropDownDirection.BelowRight);
            }

        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (_drawing)
            {
                switch (_drawType)
                {
                    case DrawType.Rectangle:
                        _draw.Rectangle(e.Location, true);
                        break;
                    case DrawType.Line:
                        _draw.Line(e.Location, true);
                        break;
                    case DrawType.Pensil:
                        _draw.Pencil(e.Location);
                        break;
                    case DrawType.Ellips:
                        _draw.Ellipse(e.Location, true);
                        break;
                }

                var gr = panel2.CreateGraphics();
                _draw.Drawing(gr);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            if (_drawing)
            {
                _drawing = false;
                switch (_drawType)
                {
                    case DrawType.Rectangle:
                        _draw.Rectangle(e.Location);
                        break;
                    case DrawType.Line:
                        _draw.Line(e.Location);
                        break;
                    case DrawType.Pensil:
                        _draw.Pencil(e.Location);
                        break;
                    case DrawType.Ellips:
                        _draw.Ellipse(e.Location);
                        break;
                }

                var gr = panel2.CreateGraphics();
                _draw.Drawing(gr);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            _drawType = DrawType.Rectangle;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _drawType = DrawType.Pensil;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            _drawType = DrawType.Line;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            _drawType = DrawType.Ellips;
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void BackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = _draw.GetBackgroundColor();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _draw.SetBackgroundColor(colorDialog1.Color);

                var gr = panel2.CreateGraphics();
                _draw.Drawing(gr);
            }
        }

        private void PenColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var defaultPen = _draw.GetDefaultPen();
            colorDialog1.Color = defaultPen.Color;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                var newPen = new Pen(colorDialog1.Color, defaultPen.Width);
                //var newPen = new Pen(colorDialog1.Color, 1);
                _draw.SetDefaultPen(newPen);
            }
        }

        private void SizeLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (LineSizeDialog dialog = new LineSizeDialog())
            {
                var defaultPen = _draw.GetDefaultPen();
                dialog.PenWidth = defaultPen.Width;
                DialogResult result = dialog.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    var newPen = new Pen(defaultPen.Color, dialog.PenWidth);
                    _draw.SetDefaultPen(newPen);
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _draw.SaveInBmp(dialog.FileName);
                }
            }

        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _draw.LoadFromBmp(dialog.FileName);
                    var gr = panel2.CreateGraphics();
                    _draw.Drawing(gr);
                }
            }
        }

        private void CanselDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_draw.CanCancelDrawnDown())
            {
                _draw.CancelDrawnDown();
                var gr = panel2.CreateGraphics();
                _draw.Drawing(gr);
            }
        }

        private void CanselUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_draw.CanCancelDrawnUp())
            {
                _draw.CancelDrawnUp();
                var gr = panel2.CreateGraphics();
                _draw.Drawing(gr);
            }

        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _draw.Clear();
            var gr = panel2.CreateGraphics();
            _draw.Drawing(gr);
        }

        private void ProgressHandler(Task task)
        {
            //ColorInversionToolStripMenuItem.Enabled = false;    
            //toolStripProgressBar1.Enabled = true;

            //task.Start();


            timer1.Enabled = false;
            statusStrip1.Items.Clear();
            //toolStripProgressBar1.Enabled = false;
            //toolStripProgressBar1.Value = 0;
            ColorInversionToolStripMenuItem.Enabled = true;
            var gr = panel2.CreateGraphics();
            _draw.Drawing(gr);
        }

        private void ColorInversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            ColorInversionToolStripMenuItem.Enabled = false;
            
            var toolStripProgressBar = new ToolStripProgressBar();
            toolStripProgressBar.Size = new Size(statusStrip1.Size.Width-20, 16);
            statusStrip1.Items.Add(toolStripProgressBar);
            toolStripProgressBar.Enabled = true;

            Task colorInv = new Task(() =>
            {
                _draw.ColorInversion();
            });
            Task progress = new Task(() =>
            {
                colorInv.Start();
                colorInv.Wait();
                this.Invoke(ProgressHandler, new[] { colorInv });
            });
            progress.Start();
        }

        private void statusStrip1_ClientSizeChanged(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   
            if (statusStrip1.Items.Count>0)
            {
                var item = (ToolStripProgressBar)statusStrip1.Items[0];
                if (item.Value != item.Maximum)
                {
                    item.PerformStep();
                }
                else
                {
                    item.Value = 0;
                }
            }

        }
    }
}