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

        // 關閉視窗
        private void title_Closed(object sender, EventArgs e)
        {
            string data = "";
            foreach(TodoItem item in TodoItemList.Children)
            {
                data += "|" + item.TimeTb.Text + "|" + item.ItemnameTb.Text + "|" + item.PayTb.Text + "\r\n";
            }
            System.IO.File.WriteAllText(@"C:\Users\pc-01\Desktop\cc.txt", data);
        }

        // 讀取存檔
        private void title_Loaded(object sender, RoutedEventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\pc-01\Desktop\cc.txt");
            foreach(string line in lines)
            {
                string[] parts = line.Split('|');
                TodoItem item = new TodoItem();

                // 金額的運算
                item.PayTb.Text = parts[3];
                money +=int.Parse( parts[3]);
                AllmoneyTb.Text = money.ToString(); 

                TodoItemList.Children.Add(item);
            }
        }

        // 移動窗口
        private void title_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void title_MouseEnter(object sender, MouseEventArgs e)
        {
            int pay=0;
            foreach(TodoItem item in TodoItemList.Children)
            {
                pay += int.Parse(item.PayTb.Text);
                AllmoneyTb.Text = pay.ToString();
            }
        }
    }
}
