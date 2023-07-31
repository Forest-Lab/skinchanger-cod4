namespace skinchanger_cod4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = "C:\\Users\\dd\\Desktop\\pepe\\", b = "C:\\Users\\dd\\Desktop\\skins", c = "italian";
            functionality.changeskins(a,b,c);
        }
    }
}