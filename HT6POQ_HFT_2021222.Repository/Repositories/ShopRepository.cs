using HT6POQ_HFT_2021222.Repository.Data;
using HT6POQ_HFT_2021222.Repository.Interfaces;
using HT6POQ_HTF_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT6POQ_HFT_2021222.Repository.Repositories
{
    public class ShopRepository : IShopRepository
    {
        BookDbContext db;
        public ShopRepository(
            BookDbContext DB)
        {
            this.db = DB;
        }
        public void Create(Shop shop)
        {
            db.Shops.Add(shop);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var ShopToDelete = Read(id);
            db.Shops.Remove(ShopToDelete);
            db.SaveChanges();
        }

        public IQueryable<Shop> GetAll()
        {
            return db.Shops;
        }

        public Shop Read(int id)
        {
            return db.Shops.FirstOrDefault(t => t.Id == id);
        }

        public void Update(Shop shop)
        {
            var NewShop = Read(shop.Id);
            NewShop.Location = shop.Location;
            NewShop.Name = shop.Name;
            db.SaveChanges();
        }
    }
}
