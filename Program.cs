using StadionReservTask.Data.DAL;
using StadionReservTask.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StadionReservTask
{
    class Program
    {
        static void Main(string[] args)
        {
            StadionDbContext dbContext = new StadionDbContext();

            bool check = true;
            string answer = "";
            string stadionName = "";
            string hourPriceStr = "";
            decimal hourPrice;
            string capacityStr;
            int capacity;

            while (check)
            {
                
                Console.WriteLine("1.Stadion elave et \n 2.Stadionlari goster \n " +
                    "3.Verilmish id-li stadionu goster\n 4.Verilmish id-li stadionu sil \n 0.Proqrami bitir");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        do
                        {
                            Console.WriteLine("Zehmet olmasa stadionun adini daxil edin: ");
                            stadionName = Console.ReadLine();
                        } while (String.IsNullOrEmpty(stadionName));
                        do
                        {
                            Console.WriteLine("Zehmet olmasa stadionun limitini daxil edin: ");
                            capacityStr = Console.ReadLine();
                        } while (!int.TryParse(capacityStr, out capacity));
                        do
                        {
                            Console.WriteLine("Zehmet olmasa stadionun saatliq qiymetini daxil edin :");
                            hourPriceStr = Console.ReadLine();
                        } while (!decimal.TryParse(hourPriceStr, out hourPrice));

                        Stadion stadium = new Stadion
                        {
                            Name = stadionName,
                            HourPrice = hourPrice,
                            Capacity = capacity,
                        };

                        dbContext.Stadions.Add(stadium);
                        dbContext.SaveChanges();
                        break;

                    case "2":
                        List<Stadion> Stadions = dbContext.Stadions.ToList();
                        foreach (var std in Stadions)
                        {
                            Console.WriteLine($"{std.Id}  |  {std.Name}  |  {std.HourPrice}   |   {std.Capacity}");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Zehmet olmasa Id daxil edin: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        var st = dbContext.Stadions.Find(id);
                        Console.WriteLine($"{st.Id}  |  {st.Name}  |  {st.HourPrice}   |   {st.Capacity}");
                        break;

                    case "4":
                        Console.WriteLine("Zehmet olmasa Id daxil edin: ");
                        int idR = Convert.ToInt32(Console.ReadLine());
                        var data = dbContext.Stadions.FirstOrDefault(x => x.Id == idR);
                        if (data != null)
                        {
                            dbContext.Stadions.Remove(data);
                        }
                        break;
                    case "0":
                        Console.WriteLine(" Proqram bitdi.");
                        check = false;
                        break;
                    default:
                        Console.WriteLine("Duzgun deyer daxil edin!");
                        break;
                }


            }

        }
    }
}
