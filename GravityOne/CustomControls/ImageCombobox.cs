using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GravityOne.CustomControls
{
    public class ImageCombo : ComboBox
    {
        private ImageList lstImages = new ImageList();

        public ImageCombo()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
        }

        public ImageList ImageList
        {
            get
            {
                return lstImages;
            }

            set
            {
                lstImages = value;
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            if (e.Index < 0)

                e.Graphics.DrawString(this.Text, e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + lstImages.ImageSize.Width, e.Bounds.Top);

            else
            {
                if (this.Items[e.Index].GetType() == typeof(ImageComboItem))
                {
                    ImageComboItem icItem = (ImageComboItem)this.Items[e.Index];
                    Color forecolor = (icItem.ForeColor != Color.FromKnownColor(KnownColor.Transparent)) ? icItem.ForeColor : e.ForeColor;
                    Font font = icItem.Indicate ? new Font(e.Font, FontStyle.Bold) : e.Font;

                    if (icItem.ImageIndex != -1)
                    {   
 //                       e.Graphics.DrawString(icItem.ItemText, font, new SolidBrush(forecolor), e.Bounds.Left + lstImages.ImageSize.Width, e.Bounds.Top);
                        this.ImageList.Draw(e.Graphics, e.Bounds.Left, e.Bounds.Top, icItem.ImageIndex);
                    }
                    else
                        e.Graphics.DrawString(icItem.ItemText, font, new SolidBrush(forecolor), e.Bounds.Left + lstImages.ImageSize.Width, e.Bounds.Top);
                }
                else
                    e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + lstImages.ImageSize.Width, e.Bounds.Top);
            }

            base.OnDrawItem(e);
        }

    }
}
