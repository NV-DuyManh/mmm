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
            // Nút này của Việt đã chạy đúng (gọi trang PagePhim)
            MainFrame.Content = new PagePhim();
        }

        private void BtnSanPham_Click(object sender, RoutedEventArgs e)
        {
            // SỬA TẠI ĐÂY: Thay MessageBox bằng lệnh gọi trang bắp nước của bạn
            // Lưu ý: Bạn phải đảm bảo đã copy file qlsp.xaml và qlsp.xaml.cs 
            // từ nhánh của bạn sang thư mục dự án này thì mới không bị gạch đỏ nhé.
            MainFrame.Content = new qlsp();
        }

        private void BtnSuatChieu_Click(object sender, RoutedEventArgs e)
        {
            // Nút này cũng đã chạy đúng
            MainFrame.Content = new QLSuatChieu();
        }

        private void BtnTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng Quản lý tài khoản đang được xây dựng!", "Thông báo");
        }

        private void BtnDangXuat_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}