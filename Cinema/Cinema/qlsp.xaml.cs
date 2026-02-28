using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Cinema
{
    public partial class qlsp : Page
    {
        // 1. Kết nối với Database của nhóm bạn
        DBRapPhimEntities1 db = new DBRapPhimEntities1();

        public qlsp()
        {
            InitializeComponent();
            LoadDuLieu(); // Gọi hàm lấy dữ liệu từ SQL khi mở trang
        }

        // Hàm này lôi toàn bộ sản phẩm từ SQL lên bảng bên phải
        private void LoadDuLieu()
        {
            try
            {
                // Lấy danh sách sản phẩm thật từ Database
                var danhSach = db.sanphams.ToList();
                dgProducts.ItemsSource = danhSach;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể load dữ liệu: " + ex.Message);
            }
        }

        // 2. Xử lý nút THÊM MỚI
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên và Giá!", "Thông báo");
                return;
            }

            try
            {
                // Bước "phiên dịch" để không bị lỗi SQL (CHECK constraint)
                string loaiHienThi = cmbCategory.Text;
                string loaiSQL = "DoAn"; // Mặc định

                if (loaiHienThi == "Nước ngọt") loaiSQL = "NuocUong";
                else if (loaiHienThi == "Combo") loaiSQL = "Combo";

                // Tạo đối tượng sản phẩm mới
                sanpham spMoi = new sanpham()
                {
                    ten_san_pham = txtName.Text,
                    gia_ban = decimal.Parse(txtPrice.Text),
                    loai = loaiSQL
                };

                // Lưu vào Database
                db.sanphams.Add(spMoi);
                db.SaveChanges();

                MessageBox.Show("Thêm thành công rổi nè!", "Thông báo");

                LoadDuLieu(); // Cập nhật lại cái bảng bên phải ngay lập tức
                btnClear_Click(null, null); // Xóa trắng các ô nhập để nhập món mới
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        // 3. Nút Nhập lại (Clear)
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            txtPrice.Clear();
            cmbCategory.SelectedIndex = 0;
        }

        // Các hàm khung để app không báo lỗi CS1061
        private void btnEdit_Click(object sender, RoutedEventArgs e) { }
        private void btnDelete_Click(object sender, RoutedEventArgs e) { }
        private void dgProducts_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
    }
}