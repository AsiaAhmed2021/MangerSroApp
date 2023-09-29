using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangerSroApp.ExtensionsClass
{
    internal class ControllerViews
    {
        internal static List<Control> BlockMessage(string Type, MethodInvoker methodInvoker = null)
        {
            var ListControl = new List<Control>();
            var buttonSave = new Button();
            var textNotice = new TextBox();

            ListControl.Add(buttonSave = new Button()
            {
                Dock = DockStyle.Bottom,
                ForeColor = Color.White,
                BackColor = Color.Black,
                Text = "Save"
            });

            ListControl.Add(textNotice = new ComText("Message"));

            buttonSave.Click += delegate
            {
                ExtensionsClass.Extensions.SetFunToolEvent(Message: textNotice.Text, Type: Type);
                if (methodInvoker != null)
                    methodInvoker.Invoke();
            };

            return ListControl;
        }

        internal static List<Control> BlockMessageAndTarget(string Type, MethodInvoker methodInvoker = null)
        {
            var ListControl = new List<Control>();
            var buttonSave = new Button();
            var textNotice = new TextBox();
            var User = new ComboBox();

            ListControl.Add(textNotice = new ComText("Message"));

            ListControl.Add(User = new ComboBox() { Dock = DockStyle.Top, ForeColor = Color.White, BackColor = Color.Black, Text = "Select User" });

            foreach (var item in SqlHelper.GetUsersByModels()) { User.Items.Add(item.name); }

            ListControl.Add(buttonSave = new ComBtn("Save") { Dock = DockStyle.Bottom });

            buttonSave.Click += delegate
            {
                if (User.SelectedIndex > -1)
                {
                    Extensions.SetFunToolEvent(Message: textNotice.Text, Target: User.Text.ToString(), Type: Type);
                    if (methodInvoker != null)
                        methodInvoker.Invoke();
                }
            };
            return ListControl;
        }

        public static List<Control> BlockTarget(string Type, MethodInvoker methodInvoker = null)
        {
            var ListControl = new List<Control>();
            var buttonSave = new Button();
            var User = new ComboBox();
            ListControl.Add(User = new ComboBox() { Dock = DockStyle.Top, ForeColor = Color.White, BackColor = Color.Black, Text = "Select User" });
            foreach (var item in SqlHelper.GetUsersByModels()) { User.Items.Add(item.name); }
            ListControl.Add(buttonSave = new Button() { Dock = DockStyle.Bottom, ForeColor = Color.White, BackColor = Color.Black, Text = "Save" });
            buttonSave.Click += delegate
            {
                if (User.SelectedIndex > -1)
                {
                    ExtensionsClass.Extensions.SetFunToolEvent(Target: User.Text.ToString(), Type: Type);
                    if (methodInvoker != null)
                        methodInvoker.Invoke();
                }
            };

            return ListControl;
        }

        public static List<Control> BlockLoadMonster(string Type, MethodInvoker methodInvoker = null)
        {
            var ListControl = new List<Control>();
            var buttonSave = new Button();
            var textNotice = new TextBox();
            var textammont = new TextBox();

            ListControl.Add(buttonSave = new ComBtn("Save") { Dock = DockStyle.Bottom });
            ListControl.Add(textammont = new ComText("ammont"));
            ListControl.Add(textNotice = new ComText("Ref Mob name"));

            buttonSave.Click += delegate
            {
                string IDMonster = "";
                using (var db = new DotNet.VSRO_SHARDEntities())
                {

                    IDMonster = db.Database.SqlQuery<int>(@"
select top 1 ID from VSRO_SHARD.dbo._RefObjCommon where 
CodeName128 not like '%MOB_THIEF_%' 
and CodeName128  like '%'+@p0+'%' 
and  CodeName128 not like '%MOB_HUNTER_%'
and  CodeName128 not like '%MOB_EU_THIEF_%'
and  CodeName128 not like '%MOB_CH_THIEF_%'
and  CodeName128 not like '%MOB_CH_HUNTER_%'
and  CodeName128 not like '%MOB_EU_HUNTER_%'
", textNotice.Text).FirstOrDefault().ToString();
                }

                if (!string.IsNullOrEmpty(IDMonster))
                {
                    ExtensionsClass.Extensions.SetFunToolEvent(RefMobID: IDMonster, Amount: textammont.Text, Type: Type);
                    if (methodInvoker != null)
                        methodInvoker.Invoke();
                }
            };

            return ListControl;
        }

        internal static List<Control> BlockCreateStall(string Type, MethodInvoker methodInvoker = null)
        {
            var ListControl = new List<Control>();
            var buttonSave = new Button();
            var textTool0 = new TextBox();
            var textTool1 = new TextBox();

            ListControl.Add(buttonSave = new ComBtn("Save") { Dock = DockStyle.Bottom, });
            ListControl.Add(textTool0 = new ComText("StallTitle"));
            ListControl.Add(textTool1 = new ComText("StallGreating"));

            buttonSave.Click += delegate
            {
                Extensions.SetFunToolEvent(Message: textTool0.Text, StallTitle: textTool0.Text, StallGreating: textTool1.Text, Type: Type);
                if (methodInvoker != null) { methodInvoker.Invoke(); }
            };

            return ListControl;
        }

        public static List<Control> BlockCapPVP(string Type, MethodInvoker methodInvoker = null)
        {
            var ListControl = new List<Control>();
            var buttonSave = new Button();
            var User = new ComboBox();

            ListControl.Add(User = new ComboBox() { Dock = DockStyle.Top, ForeColor = Color.White, BackColor = Color.Black, Text = "Color Cap" });

            User.Items.Add("Red");
            User.Items.Add("Black");
            User.Items.Add("Blue");
            User.Items.Add("White");
            User.Items.Add("Yellow");

            ListControl.Add(buttonSave = new ComBtn("Save") { Dock = DockStyle.Bottom });

            buttonSave.Click += delegate
            {
                if (User.SelectedIndex > -1)
                {
                    ExtensionsClass.Extensions.SetFunToolEvent(CapeColor: User.Text.ToString(), Type: Type);
                    if (methodInvoker != null)
                        methodInvoker.Invoke();
                }
            };

            return ListControl;
        }

        private class ComText : TextBox
        {
            public ComText(string placeholderText)
            {
                Dock = DockStyle.Top;
                ForeColor = Color.White;
                BackColor = Color.Black;
                PlaceholderText = placeholderText;
                BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private class ComBtn : Button
        {
            public ComBtn(string placeholderText)
            {
                Dock = DockStyle.Top;
                ForeColor = Color.White;
                BackColor = Color.Black;
                Text = placeholderText;
                this.FlatStyle = FlatStyle.Flat;
            }
        }

    }
}
