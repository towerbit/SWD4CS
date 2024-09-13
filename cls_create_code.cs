using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace SWD4CS
{
    public class cls_create_code
    {
        private static FILE_INFO fileInfo;
        private static cls_userform? userForm;

        // ********************************************************************************************
        // internal Function 
        // ********************************************************************************************
        internal static string Create_SourceCode(FILE_INFO fInfo, cls_userform form)
        {
            fileInfo = fInfo;
            userForm = form;
            //string source = "";
            var sbSource = new StringBuilder();
            List<string> lstSuspend = new();
            List<string> lstResume = new();
            string space = "";
            space = !fileInfo.source_base[0].Contains(";") ? space.PadLeft(8) : space.PadLeft(4);

            Create_Code_Instance(sbSource, space);
            Create_Code_Suspend_Resume(sbSource, lstSuspend, lstResume, space);

            // suspend
            for (int i = 0; i < lstSuspend.Count; i++) { sbSource.Append(lstSuspend[i]); }

            Create_Code_Property(sbSource, space);

            Create_Code_FormProperty(sbSource, space);
            Create_Code_FormAddControl(sbSource, space);

            // resume
            for (int i = 0; i < lstResume.Count; i++) { sbSource.Append(lstResume[i]); }

            Create_Code_EventDeclaration(sbSource, space);

            if (!fileInfo.source_base[0].Contains(";")) { sbSource.AppendLine("    }"); }

            sbSource.AppendLine("}");
            sbSource.AppendLine();

            // events function
            Create_Code_FuncDeclaration(sbSource);
            return sbSource.ToString();
        }

        // ********************************************************************************************
        // private Function 
        // ********************************************************************************************
        private static void Create_Code_Instance(StringBuilder sbSource, string space)
        {
            // Instance
            for (int i = 0; i < fileInfo.source_base.Count; i++) { sbSource.AppendLine(fileInfo.source_base[i]); }
            sbSource.AppendLine(space + "{");
            //return source;
        }

        private static void Create_Code_Suspend_Resume(StringBuilder sbSource, List<string> lstSuspend, List<string> lstResume, string space)
        {
            string[] className_group1 = new string[] { "DataGridView", "PictureBox", "SplitContainer", "TrackBar" };
            string[] className_group2 = new string[] { "GroupBox", "Panel", "StatusStrip", "TabControl", "TabPage", "FlowLayoutPanel", "TableLayoutPanel" };

            // Suspend & resume
            foreach (var item in userForm!.CtrlItems)
            {
                sbSource.AppendLine($"{space}    this.{item.ctrl!.Name} = new System.Windows.Forms.{item.className}();");

                if (className_group1.Contains(item.className))
                {
                    lstSuspend.Add($"{space}    ((System.ComponentModel.ISupportInitialize)(this.{item.ctrl!.Name})).BeginInit();{Environment.NewLine}");
                    lstResume.Add($"{space}    ((System.ComponentModel.ISupportInitialize)(this.{item.ctrl!.Name})).EndInit();{Environment.NewLine}");
                }
                if (className_group2.Contains(item.className))
                {
                    lstSuspend.Add($"{space}    this.{item.ctrl!.Name}.SuspendLayout();{Environment.NewLine}");
                    lstResume.Add($"{space}    this.{item.ctrl!.Name}.ResumeLayout(false);{Environment.NewLine}");
                }
                if (item.className == "SplitContainer")
                {
                    lstSuspend.Add($"{space}    this.{item.ctrl!.Name}.Panel1.SuspendLayout();{Environment.NewLine}");
                    lstSuspend.Add($"{space}    this.{item.ctrl!.Name}.Panel2.SuspendLayout();{Environment.NewLine}");
                    lstSuspend.Add($"{space}    this.{item.ctrl!.Name}.SuspendLayout();{Environment.NewLine}");
                    lstResume.Add($"{space}    this.{item.ctrl!.Name}.Panel1.ResumeLayout(false);{Environment.NewLine}");
                    lstResume.Add($"{space}    this.{item.ctrl!.Name}.Panel2.ResumeLayout(false);{Environment.NewLine}");
                    lstResume.Add($"{space}    this.{item.ctrl!.Name}.ResumeLayout(false);{Environment.NewLine}");
                }
            }
            lstSuspend.Add($"{space}    this.SuspendLayout();{Environment.NewLine}");
            lstResume.Add($"{space}    this.ResumeLayout(false);{Environment.NewLine}");
            //return source;
        }

        private static void Create_Code_Property(StringBuilder sbSource, string space)
        {
            for (int i = 0; i < userForm!.CtrlItems.Count; i++)
            {
                string memCode = "";
                Control ctrl = userForm.CtrlItems[i].ctrl!;
                Component comp = userForm.CtrlItems[i].nonCtrl!;
                Type ctlType = comp.GetType() == typeof(Component) ? ctrl.GetType() : comp.GetType();

                sbSource.AppendLine($"{space}    //");
                sbSource.AppendLine($"{space}    // {ctrl.Name}");
                sbSource.AppendLine($"{space}    //");
                Create_Code_AddControl(sbSource, space, i);

                foreach (PropertyInfo item in ctlType.GetProperties())
                {
                    if (!IsReadOnlyProperty(item) && HideProperty(item.Name))
                    {
                        Get_Code_Property(sbSource, ref memCode, item, userForm.CtrlItems[i], space);
                    }
                }
                if (memCode != "") { sbSource.Append(memCode); }
                Create_Code_EventsDec(sbSource, space, userForm.CtrlItems[i]);
            }
            //return source;
        }

        private static void Create_Code_FormProperty(StringBuilder sbSource, string space)
        {
            // form-property
            sbSource.AppendLine($"{space}    //");
            sbSource.AppendLine($"{space}    // form");
            sbSource.AppendLine($"{space}    //");

            Type formType = typeof(Form);
            var formProperties = userForm!.GetType().GetProperties().Where(prop => !IsReadOnlyProperty(prop) && HideProperty(prop.Name));

            foreach (PropertyInfo item in formProperties)
            {
                object? userFormValue = item.GetValue(userForm);
                object? baseFormValue = item.GetValue(new Form());

                if (userFormValue != null && baseFormValue != null && userFormValue.ToString() != baseFormValue.ToString())
                {
                    string str1 = $"{space}    this.{item.Name}";
                    string strProperty = Property2String(userForm, item);

                    if (!string.IsNullOrEmpty(strProperty) && item.Name != "Name" && item.Name != "Location")
                    {
                        sbSource.AppendLine( str1 + strProperty);
                    }
                }
            }
            Create_Code_FormEventsDec(sbSource, space, userForm);
            //return source;
        }

        private static bool IsReadOnlyProperty(PropertyInfo item)
        {
            var attributes = item.GetCustomAttributes(typeof(ReadOnlyAttribute), false);
            return attributes.Length > 0;
        }

        private static void Create_Code_FormAddControl(StringBuilder sbSource, string space)
        {
            // AddControl
            foreach (var ctrlItem in userForm!.CtrlItems.Where(i => i.ctrl!.Parent == userForm))
            {
                sbSource.AppendLine( $"{space}    this.Controls.Add(this.{ctrlItem.ctrl!.Name});");
            }
            //return source;
        }

        private static void Create_Code_EventDeclaration(StringBuilder sbSource, string space)
        {
            sbSource.AppendLine($"{space}}} ");
            sbSource.AppendLine();
            sbSource.AppendLine($"{space}#endregion");
            sbSource.AppendLine();

            // declaration
            foreach (var ctrlItem in userForm!.CtrlItems)
            {
                Type type = ctrlItem.nonCtrl!.GetType();
                string typeName1 = ctrlItem.ctrl!.GetType().ToString();
                string typeName2 = ctrlItem.nonCtrl!.GetType().ToString();
                string dec = type == typeof(Component) ? typeName1 : typeName2;
                sbSource.AppendLine($"{space}private {dec} {ctrlItem.ctrl!.Name};");
            }
            //return source;
        }

        public const string FLAG_FUNC_DECLARATION = "// --- Remove the following code if you don't need to create/auto-save it to\r\n";

        private static void Create_Code_FuncDeclaration(StringBuilder sbSource)
        {
            sbSource.Append(FLAG_FUNC_DECLARATION);
            sbSource.AppendLine($"// {userForm!.viewName}.cs generated by SWD4CS");
            sbSource.AppendLine("using System;");
            sbSource.AppendLine("using System.Drawing;");
            sbSource.AppendLine("using System.Windows.Forms;");
            sbSource.AppendLine();
            sbSource.AppendLine("namespace WinFormsApp");
            sbSource.AppendLine("{");
            sbSource.AppendLine($"    public class {userForm!.viewName}");
            sbSource.AppendLine("    {");
            sbSource.AppendLine($"        public {userForm!.viewName}()");
            sbSource.AppendLine("        {");
            sbSource.AppendLine("            InitializeComponent();");
            sbSource.AppendLine("        }");
            sbSource.AppendLine();
            // control
            for (int i = 0; i < userForm!.CtrlItems.Count; i++)
            {
                for (int j = 0; j < userForm.CtrlItems[i].decFunc.Count; j++)
                {
                    sbSource.AppendLine($"        {userForm.CtrlItems[i].decFunc[j]}");
                    sbSource.AppendLine("        {{");
                    sbSource.AppendLine("        ");
                    sbSource.AppendLine("        }}");
                    sbSource.AppendLine();
                }
            }

            // form
            foreach (string decFunc in userForm.decFunc)
            {
                sbSource.AppendLine($"        {decFunc}");
                sbSource.AppendLine("        {");
                sbSource.AppendLine("        ");
                sbSource.AppendLine("        }");
                sbSource.AppendLine();
            }
            sbSource.AppendLine("    }");
            sbSource.AppendLine("}");
            //return source;
        }

        private static void Create_Code_AddControl(StringBuilder sbSource, string space, int i)
        {
            // AddControl
            Control ctrl1 = userForm!.CtrlItems[i].ctrl!;

            for (int j = 0; j < userForm.CtrlItems.Count; j++)
            {
                Control ctrl2 = userForm.CtrlItems[j].ctrl!;

                if (ctrl1!.Name == ctrl2!.Parent!.Name)
                {
                    sbSource.AppendLine( $"{space}    this.{ctrl1.Name}.Controls.Add(this.{ctrl2.Name});");
                }
                else if (ctrl1.Name == ctrl2.Parent!.Parent!.Name)
                {
                    if (ctrl2.Parent!.Name.Contains("Panel1"))
                    {
                        sbSource.AppendLine($"{space}    this.{ctrl1.Name}.Panel1.Controls.Add(this.{ctrl2.Name});");
                    }
                    else if (ctrl2.Parent!.Name.Contains("Panel2"))
                    {
                        sbSource.AppendLine($"{space}    this.{ctrl1!.Name}.Panel2.Controls.Add(this.{ctrl2.Name});");
                    }
                }
            }
            //return source;
        }

        private static void Get_Code_Property(StringBuilder sbSource, ref string memCode, PropertyInfo item, cls_controls ctrlItems, string space)
        {
            Component? comp = (ctrlItems.nonCtrl!.GetType() == typeof(Component)) ? ctrlItems.ctrl : ctrlItems.nonCtrl;
            Component? baseCtrl = GetBaseCtrl(ctrlItems);

            if (item.GetValue(comp) == null || item.GetValue(baseCtrl) == null) { return; }
            if (item.GetValue(comp)!.ToString() == item.GetValue(baseCtrl)!.ToString()) { return; }

            string str1 = space + "    this." + ctrlItems.ctrl!.Name + "." + item.Name;
            string strProperty = Property2String(comp!, item);

            if (strProperty == "") { return; }

            bool flag = item.Name != "SplitterDistance" && item.Name != "Anchor";
            if (flag) { sbSource.AppendLine(str1 + strProperty); }
            else { memCode += str1 + strProperty + Environment.NewLine; }
        }

        private static void Create_Code_EventsDec(StringBuilder sbSource, string space, cls_controls cls_ctrl)
        {
            int cnt = cls_ctrl.decHandler.Count;
            for (int i = 0; i < cnt; i++)
            { sbSource.AppendLine(space + "    " + cls_ctrl.decHandler[i]); }
            //return source;
        }

        private static void Create_Code_FormEventsDec(StringBuilder sbSource, string space, cls_userform userForm)
        {
            int cnt = userForm.decHandler.Count;
            for (int i = 0; i < cnt; i++) { sbSource.AppendLine(space + "    " + userForm.decHandler[i]); }
            //return source;
        }

        private static string AnchorStyles2String(object? propertyinfo)
        {
            string strProperty;
            string[] split = propertyinfo!.ToString()!.Split(',');
            Type type = propertyinfo.GetType();
            string str2 = propertyinfo.ToString()!;

            if (split.Length == 1) { strProperty = " = " + type.ToString() + "." + str2 + ";"; }
            else
            {
                string ancho = "";
                for (int j = 0; j < split.Length; j++)
                {
                    if (j == 0) { ancho = "(" + type.ToString() + "." + split[j].Trim(); }
                    else { ancho = "(" + ancho + " | " + type.ToString() + "." + split[j].Trim() + ")"; }
                }
                ancho = "((" + type.ToString() + ")" + ancho + "));";
                strProperty = " = " + ancho;
            }
            return strProperty;
        }

        private static string Property2String(Component ctrl, PropertyInfo item)
        {
            object value = item.GetValue(ctrl)!;
            if (value == null) { return ""; }

            Type type = value.GetType();
            switch (type.Name)
            {
                case nameof(System.Drawing.Point):
                    Point point = (Point)value;
                    return $" = new {type}({point.X},{point.Y});";
                case nameof(System.Drawing.Size):
                    Size size = (Size)value;
                    return $" = new {type}({size.Width},{size.Height});";
                case nameof(System.String):
                    return $" =  \"{value}\";";
                case nameof(System.Boolean):
                    return $" =  {value.ToString()!.ToLower()};";
                case nameof(System.Windows.Forms.AnchorStyles):
                    return AnchorStyles2String(value);
                case nameof(System.Int32):
                    return $" = {(int)value};";
                case nameof(System.Drawing.Color):
                    return $" = {Property2Color(value.ToString()!)};";
                case nameof(System.Drawing.Font):
                    Control ctl = (Control)ctrl;
                    return $" = {Property2Font(ctl.Font)};";
                case nameof(System.Windows.Forms.DockStyle):
                case nameof(System.Drawing.ContentAlignment):
                case nameof(System.Windows.Forms.ScrollBars):
                case nameof(System.Windows.Forms.HorizontalAlignment):
                case nameof(System.Windows.Forms.FormWindowState):
                case nameof(System.Windows.Forms.FixedPanel):
                case nameof(System.Windows.Forms.PictureBoxSizeMode):
                case nameof(System.Windows.Forms.View):
                case nameof(System.Windows.Forms.Orientation):
                case nameof(System.Windows.Forms.FormBorderStyle):
                case nameof(System.Windows.Forms.AutoScaleMode):
                case nameof(System.Windows.Forms.TableLayoutPanelCellBorderStyle):
                case nameof(System.Windows.Forms.FormStartPosition):
                    return $" = {type}.{value};";
            }
            return "";
        }

        private static Component? GetBaseCtrl(cls_controls ctrl)
        {
            Type type = ctrl.nonCtrl!.GetType() == typeof(Component) ? ctrl.ctrl!.GetType() : ctrl.nonCtrl.GetType();
            return (Component)Activator.CreateInstance(type)!;
        }

        private static bool HideProperty(string itemName)
        {
            List<string> propertyName = new()
            {
                // "AccessibilityObject",
                // "BindingContext",
                // "Parent",
                // "TopLevelControl",
                // "DataSource",
                // "FirstDisplayedCell",
                // "Item",
                // "TopItem",
                // "Rtf",
                // "ParentForm",
                // "SelectedTab",
                "Top",
                "Left",
                "Right",
                "Bottom",
                "Width",
                "Height",
                "CanSelect",
                "Created",
                "IsHandleCreated",
                "PreferredSize",
                "Visible",
                // "Enable",
                "ClientSize",
                "UseVisualStyleBackColor",
                "PreferredHeight",
                // "ColumnCount",
                // "FirstDisplayedScrollingColumnIndex",
                // "FirstDisplayedScrollingRowIndex",
                // "NewRowIndex",
                "RowCount",
                "HasChildren",
                "PreferredWidth",
                // "SingleMonthSize",
                "TextLength",
                // "SelectedIndex",
                "TabCount",
                "VisibleCount",
                "DesktopLocation",
                "AutoScale",
                // "CanFocus",
                // "IsMirrored",
                // "SelectionStart",
                "ContextMenuDefaultLocation",
                // "CanUndo",
                "CompanyName",
                "ProductName",
                "ProductVersion",
                "TopLevel",
                // "Tag",
                // "Site",
                // "Container",
                "Name",
                ""
            };
            return !propertyName.Contains(itemName);
        }

        private static readonly string[] SystemColorName = new string[]
        {
            "ActiveBorder",
            "ActiveCaption",
            "ActiveCaptionText",
            "AppWorkspace",
            "ButtonFace",
            "ButtonHighlight",
            "ButtonShadow",
            "Control",
            "ControlDark",
            "ControlDarkDark",
            "ControlLight",
            "ControlLightLight",
            "ControlText",
            "Desktop",
            "GradientActiveCaption",
            "GradientInactiveCaption",
            "GrayText",
            "Highlight",
            "HighlightText",
            "HotTrack",
            "InactiveBorder",
            "InactiveCaption",
            "InactiveCaptionText",
            "Info",
            "InfoText",
            "Menu",
            "MenuBar",
            "MenuHighlight",
            "MenuText",
            "ScrollBar",
            "Window",
            "WindowFrame",
            "WindowText",
        };

        private static readonly string[] ColorName = new string[]
        {
            "Black",
            "DimGray",
            "Gray",
            "DarkGray",
            "Silver",
            "LightGray",
            "Gainsboro",
            "WhiteSmoke",
            "White",
            "RosyBrown",
            "IndianRed",
            "Brown",
            "Firebrick",
            "LightCoral",
            "Maroon",
            "DarkRed",
            "Red",
            "Snow",
            "MistyRose",
            "Salmon",
            "Tomato",
            "DarkSalmon",
            "Coral",
            "OrangeRed",
            "LightSalmon",
            "Sienna",
            "SeaShell",
            "Chocolate",
            "SaddleBrown",
            "SandyBrown",
            "PeachPuff",
            "Peru",
            "Linen",
            "Bisque",
            "DarkOrange",
            "BurlyWood",
            "Tan",
            "AntiqueWhite",
            "NavajoWhite",
            "BlanchedAlmond",
            "PapayaWhip",
            "Moccasin",
            "Orange",
            "Wheat",
            "OldLace",
            "FloralWhite",
            "DarkGoldenrod",
            "Goldenrod",
            "Cornsilk",
            "Gold",
            "Khaki",
            "LemonChiffon",
            "PaleGoldenrod",
            "DarkKhaki",
            "Beige",
            "LightGoldenrodYellow",
            "Olive",
            "Yellow",
            "LightYellow",
            "Ivory",
            "OliveDrab",
            "YellowGreen",
            "DarkOliveGreen",
            "GreenYellow",
            "Chartreuse",
            "LawnGreen",
            "DarkSeaGreen",
            "ForestGreen",
            "LimeGreen",
            "LightGreen",
            "PaleGreen",
            "DarkGreen",
            "Green",
            "Lime",
            "Honeydew",
            "SeaGreen",
            "MediumSeaGreen",
            "SpringGreen",
            "MintCream",
            "MediumSpringGreen",
            "MediumAquamarine",
            "Aquamarine",
            "Turquoise",
            "LightSeaGreen",
            "MediumTurquoise",
            "DarkSlateGray",
            "PaleTurquoise",
            "Teal",
            "DarkCyan",
            "Cyan",
            "Aqua",
            "LightCyan",
            "Azure",
            "DarkTurquoise",
            "CadetBlue",
            "PowderBlue",
            "LightBlue",
            "DeepSkyBlue",
            "SkyBlue",
            "LightSkyBlue",
            "SteelBlue",
            "AliceBlue",
            "DodgerBlue",
            "SlateGray",
            "LightSlateGray",
            "LightSteelBlue",
            "CornflowerBlue",
            "RoyalBlue",
            "MidnightBlue",
            "Lavender",
            "Navy",
            "DarkBlue",
            "MediumBlue",
            "Blue",
            "GhostWhite",
            "SlateBlue",
            "DarkSlateBlue",
            "MediumSlateBlue",
            "MediumPurple",
            "BlueViolet",
            "Indigo",
            "DarkOrchid",
            "DarkViolet",
            "MediumOrchid",
            "Thistle",
            "Plum",
            "Violet",
            "Purple",
            "DarkMagenta",
            "Fuchsia",
            "Magenta",
            "Orchid",
            "MediumVioletRed",
            "DeepPink",
            "HotPink",
            "LavenderBlush",
            "PaleVioletRed",
            "Crimson",
        };

        private static string Property2Color(string color)
        {
            color = color.Replace("Color [", "").Replace("]", "");
            if (color == "Transparent") { return "Color.Transparent"; }

            int index = Array.IndexOf(SystemColorName, color);
            if (index >= 0) { return $"System.Drawing.SystemColors.{color}"; }

            index = Array.IndexOf(ColorName, color);
            if (index >= 0) { return $"System.Drawing.Color.{color}"; }

            string[] split = color.Split(new char[] { 'A', 'R', 'G', 'B', '=', ',' }, StringSplitOptions.RemoveEmptyEntries);
            return $"System.Drawing.Color.FromArgb({split[2]}, {split[4]}, {split[6]})";
        }

        private static string Property2Font(Font font)
        {
            string strSize = font.Size + "F, ";
            string strStyle = "System.Drawing.FontStyle." + font.Style.ToString() + ", System.Drawing.GraphicsUnit.Point)";
            string strProperty = "new System.Drawing.Font(\"" + font.Name + "\", " + strSize + strStyle;
            return strProperty;
        }
    }
}