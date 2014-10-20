using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_Map_Editor_PR_POB
{
    public partial class NewMap: Form
    {
        public static int HEIGHT = 0;
        public static int WIDTH = 0;

        public NewMap()
        {
            InitializeComponent();
            HEIGHT = 0;
            WIDTH = 0;

            this.KeyPress += NewMap_KeyPress;
        }

        /// <summary>
        /// click sur le bouton btnCreate si on appuit sur entré
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NewMap_KeyPress(object sender, KeyPressEventArgs e)
        {
                if(e.KeyChar == (char)Keys.Enter)
            {
                btnCreate_Click(sender, e);
            }
        }

        /// <summary>
        /// valide les valeurs des textbox et ferme le formulaire s'il sont valide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            int tempWidth;
            int tempHeight;

            if(int.TryParse(txtWidth.Text, out tempWidth) && int.TryParse(txtHeight.Text, out tempHeight))
            {
                if(tempWidth >= 10 && tempHeight >= 3)
                {
                    HEIGHT = tempHeight;
                    WIDTH = tempWidth;
                    this.Hide();
                    this.Close();
                }
            }
        }

        /// <summary>
        /// empeche d'écrire autre chose que des chiffre dans le form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


    }
}
