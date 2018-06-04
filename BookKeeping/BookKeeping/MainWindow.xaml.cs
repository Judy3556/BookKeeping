using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookKeeping
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        int money;
        public MainWindow()
        {
            InitializeComponent();
        }

        // 新增列表框
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            TodoItem item = new TodoItem();
            TodoItemList.Children.Add(item);


        }

        // 視窗移動
        private void title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        //關閉視窗
        private void title_Closed(object sender, EventArgs e)
        {
            string data = "";
            List<String> datas = new List<string>();
            foreach(TodoItem item in TodoItemList.Children)
            {
                data += "|" + item.TimeTb + "|" + item.ItemnameTb + "|" + item.PayTb + "\r\n";
                datas.Add(data);
            }
            System.IO.File.WriteAllLines(@"C:\Users\pc-01\Desktop\cc", datas);
        }
    }
}
