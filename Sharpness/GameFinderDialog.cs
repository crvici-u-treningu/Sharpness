using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharpness
{
    public partial class GameFinderDialog : Form
    {
        public Type Result { private set; get; } = null;

        public GameFinderDialog(List<Type> types)
        {
            InitializeComponent();

            this.gameMainList.Items.AddRange(types.ToArray());
        }

        private void gameMainList_DoubleClick(object sender, EventArgs e)
        {
            this.Result = this.gameMainList.SelectedItem as Type;
            this.Close();
        }
    }
}
