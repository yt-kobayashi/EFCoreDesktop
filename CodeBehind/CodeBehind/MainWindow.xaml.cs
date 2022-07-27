using CodeBehind.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace CodeBehind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ProductContext _context = new();
        private CollectionViewSource categoryViewSource;

        public MainWindow()
        {
            InitializeComponent();
            categoryViewSource = (CollectionViewSource)FindResource(nameof(categoryViewSource));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Database.EnsureCreated();

            // カテゴリデータの読み込み
            // 遅延読み込みで、カテゴリテーブルに紐づけられているプロダクトテーブルも読み込まれる
            _context.Categories.Load();
            categoryViewSource.Source = _context.Categories.Local.ToObservableCollection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 画面上に紐づいているデータをデータベースに保存する
            // 変更とかは勝手に検出してくれる
            _context.SaveChanges();

            // 表示の強制再読み込み
            categoryDataGrid.Items.Refresh();
            productsDataGrid.Items.Refresh();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _context.Dispose();
            base.OnClosing(e);
        }
    }
}
