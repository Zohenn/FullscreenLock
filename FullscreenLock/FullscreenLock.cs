using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullscreenLock
{
    public partial class FullscreenLock : Form
    {
        public FullscreenLock()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FullscreenLock));

            this.ni = new NotifyIcon();
            this.ni.Icon = (Icon)resources.GetObject("$this.Icon");
            //this.ni.DoubleClick += delegate (object sender, EventArgs e) {
            //    this.Show();
            //    this.WindowState = FormWindowState.Normal;
            //    this.ni.Visible = false;
            //};

            this.contextMenu = new ContextMenu();
            this.contextMenu.MenuItems.Add(this.contextMenuExit);
            this.contextMenuExit.Click += new EventHandler(this.onExitClick);
            this.ni.ContextMenu = this.contextMenu;

            this.c = new Checker();
        }

        private NotifyIcon ni;
        private ContextMenu contextMenu;
        private MenuItem contextMenuExit = new MenuItem {
            Index = 0,
            Text = "Exit"
        };
        private Checker c;

        private void onExitClick(object sender, EventArgs e) {
            this.Close();
        }

        protected override void OnShown(EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
            this.ni.Visible = true;

            base.OnShown(e);
        }
    }
}
