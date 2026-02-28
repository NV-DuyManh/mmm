using System;
using System.Windows;
using System.Windows.Controls;

namespace Cinema
{
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void BtnPhim_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PagePhim();
        }

        private void BtnSanPham_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new qlsp();
        }

        private void BtnSuatChieu_Click(object sender, RoutedEventArgs e)
        {
            // Nút này cũng đã chạy đúng
            MainFrame.Content = new QLSuatChieu();
        }

        private void BtnTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new QLTaiKhoan();
        }

        private void BtnDangXuat_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}