using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MyPaint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolStripLabel1.Text = "";
            dic["RECT"] = new RectCreator();
            dic["ELLIPSE"] = new EllipseCreator();
            dic["Group"] = new GroupCreator();
            dic["SELECT"] = null;
        }

        Picture pic = new Picture();
        Graphics gr;
        //int ButtNo = 0;
        Creator current = null; // Текущий выбранный элемент на панели
        Group tmpGroup = new Group();

        Dictionary<string, Creator> dic = new Dictionary<string, Creator>();

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            toolStripLabel1.Text = "";

            if (e.Button == MouseButtons.Right)
            {
                Refresh();
                return;
            }
            
            if (current != null)
            {
                Figure f = current.Create();
                //f.Resize(60, 60);
                f.Move(e.X, e.Y);
                f.Draw(gr);
                pic.Add(f);
                Refresh();
            }
            else
            {
                Figure f = pic.Select(e.X, e.Y);
                if (tmpGroup.Contains(f))
                {
                    // Если выбрана фигура, которая состоит в группе
                    pic.tmpGrp = tmpGroup;
                    pic.manip.Attach(pic.tmpGrp);
                    toolStripLabel1.Text = "Данная фигура принадлежит выбранной группе";
                    return;
                }

                if (f == null)
                    toolStripLabel1.Text = "Ничего не выбрано";
                else
                {
                    toolStripLabel1.Text = "Выбрана " + f.ToString() + " " + pic.manip.ActivePoint.ToString();
                    if (System.Windows.Forms.Control.ModifierKeys == Keys.Control)
                    {
                        // КТРЛ зажат
                        Figure ff = pic.tmpGrp.GetFigure(e.X, e.Y);

                        if (ff == null)
                        {
                            // Если данной фигуры нет в группе
                            pic.tmpGrp.Add(f);
                        }
                        else
                        {
                            pic.tmpGrp.Remove(ff);
                        }
                        pic.manip.Attach(pic.tmpGrp);

                    } else
                    {
                        pic.tmpGrp = new Group();
                    }
                }
                Refresh();
            }
            oldx = e.X;
            oldy = e.Y;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            pic.Draw(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gr = panel1.CreateGraphics();
        }

        private void toolStripButtonClick(object sender, EventArgs e)
        {
            if (sender is ToolStripButton)
            {
                ToolStripButton btn = sender as ToolStripButton;
                current = dic[btn.Text];
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // Кнопка выбора Rectangle

            //ButtNo = 1;
            current = new RectCreator();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // Кнопка выбора Ellipse

            //ButtNo = 2;
            current = new EllipseCreator();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Кнопка SELECT

            toolStripLabel1.Text = "";
            current = null;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        float oldx, oldy;

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            pic.manip.Update();
            Refresh();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }



        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Кнопка групировки
            //Group tmpGroup;

            int a = pic.tmpGrp.GetCount();
            tmpGroup = pic.tmpGrp;
           // pic.tmpGrp = null;
        }

        private void ungroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Кнопка ангрупировик
            tmpGroup = new Group();
        }

        private void addToPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Add to panel
            ToolStripButton btn = new ToolStripButton();
            toolStrip1.Items.Add(btn);
            btn.Text = "NewFigure" + toolStrip1.Items.Count.ToString();
            ProtoCreator cr = new ProtoCreator(pic.manip.selected);
            dic[btn.Text] = cr;
            btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btn.Click += this.toolStripButtonClick;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {                
                pic.manip.Drag(e.X - oldx, e.Y - oldy);
                pic.manip.Update();
                Refresh();
            }
            oldx = e.X;
            oldy = e.Y;
        }
    }
}
