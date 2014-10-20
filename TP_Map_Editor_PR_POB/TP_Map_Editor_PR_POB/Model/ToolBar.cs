using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Map_Editor_PR_POB.Controller
{
    class ToolBar
    {
        static private ToolBar instance;

        private ToolBarControl activeToolBarControl;
        public ToolBarControl ActiveToolBarControl
        {
            get { return this.activeToolBarControl; }
            set
            {
                this.activeToolBarControl = value;
                Changed(this, new EventArgs());
            }
        }

        public List<ToolBarControl> toolControls;

        public static ToolBar GetInstance()
        {
            if (instance == null)
            {
                instance = new ToolBar();
            }
            return instance;
        }

        public ToolBar()
        {
            toolControls = new List<ToolBarControl>();
        }

        public event EventHandler Changed;
    }
}
