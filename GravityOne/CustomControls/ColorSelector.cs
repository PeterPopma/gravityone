using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GravityOne.CustomControls
{
    class ColorSelector : ComboBox
    {
        public ColorSelector()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Draws the items into the ColorSelector object
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            Image image = Resources.colorscheme1;

            switch (e.Index)
            {
                case 0:
                    image = Resources.colorscheme1;
                    break;
                case 1:
                    image = Resources.colorscheme2;
                    break;
                case 2:
                    image = Resources.colorscheme3;
                    break;
                case 3:
                    image = Resources.colorscheme4;
                    break;
            }

            e.Graphics.DrawImage(image, e.Bounds.Left, e.Bounds.Top);
            // Draw the value (in this case, the color name)
            //e.Graphics.DrawString(item.Value, e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + item.Image.Width, e.Bounds.Top + 2);

            base.OnDrawItem(e);
        }
    }
}
