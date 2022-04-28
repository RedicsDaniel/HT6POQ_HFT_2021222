using HT6POQ_HFT_2021222.Logic.Interfaces;
using HT6POQ_HFT_2021222.Repository.Interfaces;
using HT6POQ_HTF_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT6POQ_HFT_2021222.Logic.Logics
{
    public class ShopLogic : IShopLogic
    {
        IShopRepository sr;

        public ShopLogic(IShopRepository sr)
        {
            this.sr = sr;
        }

        public void Create(Shop shop)
        {
            if (shop == null || shop.Name == "")
            {
                throw new ArgumentException("Cant create!");
            }
            sr.Create(shop);
        }

        public void Delete(int id)
        {
            sr.Delete(id);
        }

        public IEnumerable<Shop> GetAll()
        {
            return sr.GetAll();
        }

        public Shop Read(int id)
        {
            return sr.Read(id);
        }

        public void Update(Shop shop)
        {
            sr.Update(shop);
        }
    }
}
