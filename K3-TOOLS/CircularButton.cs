using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace K3_TOOLS
{
	class CircularButton : Button
	{
		protected override void OnPaint(PaintEventArgs pevent)
		{
			var graphicsPath = new GraphicsPath();
			graphicsPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
			Region = new System.Drawing.Region(graphicsPath);
			base.OnPaint(pevent);
		}
	}
}