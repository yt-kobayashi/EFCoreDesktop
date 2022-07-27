using CodeBehind.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBehind.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // データベースのファイルを指定している
            optionsBuilder.UseSqlite("Data Source=products.db");
            // 関連するデータを遅延読み込みする事を明示する
            // 親のエンティティにアクセスしたら、子のエンティティが自動で読み込まれる
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
