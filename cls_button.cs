﻿
namespace SWD4CS
{
    public partial class cls_button : Button
    {
        public cls_control_base ctrlBase;

        public cls_button(Control parent, Control backPanel, int index, int X = 0, int Y = 0)
        {
            InitializeComponent(index, X, Y);

            cls_form ctrl = (cls_form)parent;
            ctrl.CtrlItems.Add(this);
            ctrl.Controls.Add((cls_button)ctrl.CtrlItems[ctrl.CtrlItems.Count - 1]);
            ctrlBase = new cls_control_base(parent, this, backPanel);
        }

        public void Deleate(Control parent, cls_button ctrl)
        {
            parent.Controls.Remove(ctrl);
            ctrlBase.SetSelect(false);
            this.Dispose();
        }

    }
}