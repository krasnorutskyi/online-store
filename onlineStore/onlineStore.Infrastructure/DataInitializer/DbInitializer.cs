using onlineStore.Core.Entities;
using onlineStore.Infrastructure.ApplicationContext;

namespace onlineStore.Infrastructure.DataInitializer
{
    public class DbInitializer
    {
        public static void Initialize(EFContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            
            var smartWatches = new Category() {Name = "Smart Watches"};
            var laptops = new Category() {Name = "Laptops"};
            var phones = new Category() {Name = "Phones"};
            var headphones = new Category() {Name = "Headphones"};
            var tvs = new Category() {Name = "TV's"};
            
            var Categories = new List<Category>()
            {
                smartWatches,
                headphones,
                laptops,
                phones,
                tvs
            };

            var Items = new List<Item>()
            {
                new Item() {Category = phones, Name = "Apple iPhone 13", Price = 801, Image = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-13-midnight-select-2021?wid=940&hei=1112&fmt=png-alpha&.v=1645572315913"},
                new Item() {Category = phones, Name = "Samsung Galaxy S22", Price = 790, Image = "https://fscl01.fonpit.de/devices/22/2222-w320h320.png"},
                new Item() {Category = phones, Name = "Google Pixel 6", Price = 735, Image = "https://www.meintrendyhandy.de/images/Google-Pixel-6-Pro-128GB-Stormy-Black-GA03164-GB-21102021-01-p.jpg"},
                new Item() {Category = phones, Name = "Apple iPhone 13 Mini", Price = 725, Image = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-13-mini-blue-select-2021?wid=470&hei=556&fmt=jpeg&qlt=95&.v=1645572315986"},
                new Item() {Category = headphones, Name = "Bose QuietComfort 45", Price = 350 , Image = "https://m.media-amazon.com/images/I/51JbsHSktkL._AC_SX355_.jpg"},
                new Item() {Category = headphones, Name = "Bose Headphones 700", Price = 278, Image = "https://m.media-amazon.com/images/I/61UzY7vPUIL._AC_SX522_.jpg"},
                new Item() {Category = headphones, Name = "Sony WH-1000XM4", Price = 275, Image = "https://gzhls.at/i/63/64/2346364-n0.jpg"},
                new Item() {Category = headphones, Name = "Sennheiser HD 350BT", Price = 99, Image = "https://m.media-amazon.com/images/I/71jsrUhfSlS._AC_SL1500_.jpg"},
                new Item() {Category = laptops, Name = "HP EliteBook 850", Price = 1299, Image = "https://media.nbb-cdn.de/images/products/720000/720177/Cadillac_15_Silver_W10P_02_2_f523.png?size=2800"},
                new Item() {Category = laptops, Name = "Microsoft Surface Laptop 4", Price = 1449, Image = "https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RE4LEgb?ver=421a&q=90&m=6&h=705&w=1253&b=%23FFFFFFFF&f=jpg&o=f&p=140&aim=true"},
                new Item() {Category = laptops, Name = "Apple MacBook Pro with Apple M1", Price = 1412, Image = "https://res-5.cloudinary.com/grover/image/upload/e_trim/c_limit,f_auto,fl_png8.lossy,h_1280,q_auto,w_1280/v1605174579/j4qcx1javf2ws6seb1qr.png"},
                new Item() {Category = laptops, Name = "HP ZBook Studio 15 G8", Price = 3799, Image = "https://www.notebookcheck.com/uploads/tx_nbc2/center_facing.jpg"},
                new Item() {Category = smartWatches, Name = "Apple Watch Series 7", Price = 517, Image = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/MKU93_VW_34FR+watch-41-alum-starlight-nc-7s_VW_34FR_WF_CO?wid=1400&hei=1400&trim=1,0&fmt=p-jpg&qlt=95&.v=1632171039000,1631661270000"},
                new Item() {Category = smartWatches, Name = "Xiaomi Mi Watch Smart Watch", Price = 120, Image = "https://www.tradeinn.com/f/13814/138141518/xiaomi-mi-watch-smartwatch.jpg"},
                new Item() {Category = smartWatches, Name = "Samsung Galaxy Watch 4", Price = 269, Image = "https://assets.mmsrg.com/isr/166325/c1/-/ASSET_MMS_86406169/fee_325_225_png"},
                new Item() {Category = smartWatches, Name = "Apple Watch SE", Price = 432, Image = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/MKU83_VW_34FR+watch-40-alum-spacegray-nc-se_VW_34FR_WF_CO_GEO_DE?wid=1400&hei=1400&trim=1,0&fmt=p-jpg&qlt=95&.v=1632171038000,1630713084000"},
                new Item() {Category = tvs, Name = "Samsung Neo QLED 4K TV QN90A 65 Inch", Price = 1455, Image = "https://images.samsung.com/is/image/samsung/p6pim/de/gq65qn90aatxzg/gallery/de-neo-qled-qn90a-gq65qn90aatxzg-532532599?$650_519_PNG$"},
                new Item() {Category = tvs, Name = "Samsung QLED 4K Q70A TV 65 Inch ", Price = 1245, Image = "https://m.media-amazon.com/images/I/811eZPTYdfS._AC_SX450_.jpg"},
                new Item() {Category = tvs, Name = "Sony KD-75X81J 75 Inch 4K UHD HDR Smart TV", Price = 1250, Image = "https://www.city-tv-hifi.de/media/image/b6/66/d7/Sony-KD75X81JAE-X81J-City-Tv-HiFi-Ansicht2_600x600.png"},
                new Item() {Category = tvs, Name = "Sony Bravia XR50X90JAEP TV 50' 4K UHD", Price = 899, Image = "https://www.sony.de/image/79f8e14a8cbf19eb2eae7065820c8855?fmt=pjpeg&bgcolor=FFFFFF&bgc=FFFFFF&wid=2515&hei=1320"}
            };

            context.Categories.AddRange(Categories);
            context.Items.AddRange(Items);
            context.SaveChanges();
        }
    }
}