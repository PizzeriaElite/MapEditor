using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_Map_Editor_PR_POB.Controller;

namespace TP_Map_Editor_PR_POB
{
    public partial class FormEditor
    {
        //On en fait une sous-classe: On doit passer explicitement par la référence de classe, mais on a accès à tout ce qui est privé.
        public class ControllerToolBar
        {

            private readonly ToolBarControl vue;
            private Controller controller;

            public ControllerToolBar(ToolBarControl vue, Controller control)
            {
                this.vue = vue;
                this.controller = control;

                vue.Click += new EventHandler(vue_Click);
            }


            /// <summary>
            /// Au clic d'un contrôle de la barre d'outil, le contrôle est assigné à la barre d'outil singleton comme le control actif.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void vue_Click(object sender, EventArgs e)
            {
                if((TP_Map_Editor_PR_POB.Controller.ToolBar.GetInstance().ActiveToolBarControl == (ToolBarControl)sender))
                {
                    TP_Map_Editor_PR_POB.Controller.ToolBar.GetInstance().ActiveToolBarControl = null;
                }
                else
                {
                    TP_Map_Editor_PR_POB.Controller.ToolBar.GetInstance().ActiveToolBarControl = ((ToolBarControl)sender);
                    controller.createNewTile();
                }
            }
        }
    }
}
