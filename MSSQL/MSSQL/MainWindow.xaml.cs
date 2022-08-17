using Microsoft.EntityFrameworkCore;
using MSSQL.Data;
using MSSQL.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace MSSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly MssqlDbContext _context = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Database.Migrate();
            _context.Telops.Load();
            _ = _context.Telops.ToList();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            TelopModel telop = new()
            {
                Content = DateTime.Now.ToString()
            };
            await _context.AddAsync(telop);
            await _context.SaveChangesAsync();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (_context.Telops == null) { return; }
            List<TelopModel> telops = await _context.Telops.ToListAsync();
            if (telops.Count == 0) { return; }

            TelopModel telop = telops[telops.Count - 1];
            _context.Remove(telop);
            await _context.SaveChangesAsync();
        }
    }
}
